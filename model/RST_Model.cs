using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Events;
using Autodesk.Revit.Exceptions;
using Autodesk.Revit.UI;
using ReuseSchemeTool.model.revit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ReuseSchemeTool.model
{
    public class RST_Model : Observable
    {

        // ATTRIBUTES
        private static RST_Model instance;
        private List<Observer> observers;
        private JSONSerializer<List<FrameDecorator>> jsonSerializer;
        private List<Element> frameElements;
        private List<Frame> steelFrames;
        private List<ExistingSteelFrame> existingSteelFrames;
        private List<ProposedSteelFrame> proposedSteelFrames;
        public Autodesk.Revit.UI.UIApplication uiApp;
        public Autodesk.Revit.UI.UIDocument uiDoc;
        public Autodesk.Revit.DB.Document dbDoc;
        private ReuseRatingCalculator reuseRatingCalculator;
        private FrameConverter frameConverter;


        private const string MODEL_NAME = "Reuse Scheme Tool";
        private const string MODEL_VERSION = "Version: " + "1.0.0";
        private const string MODEL_COPYRIGHT = "Copyright @ Buro Happold Ltd Inc.2024";
        private const string MODEL_AUTHOR = "Giorgio Carlo Roberto Albieri";
        private const string MODEL_OWNER = "Buro Happold Ltd";




        // STATIC METHOD .getInstance()
        public static RST_Model getInstance()
        {
            if (instance==null) return new RST_Model();
            return instance;
        }

        // CONSTRUCTOR - Private
        private RST_Model() 
        { 
            this.observers= new List<Observer>();
            this.jsonSerializer= new JSONSerializer<List<FrameDecorator>>();
            this.existingSteelFrames = new List<ExistingSteelFrame>();
            this.proposedSteelFrames = new List<ProposedSteelFrame>();
        
        }


        public void initialize(Autodesk.Revit.UI.UIApplication uiApp, ReuseRatingCalculator reuseRatingCalculator)
        {
            if (uiApp == null) throw new MissingInputsException("Revit UI Application is missing/not valid.");
            this.uiApp = uiApp;
            this.uiDoc = uiApp.ActiveUIDocument;
            this.dbDoc = uiDoc.Document;
            this.reuseRatingCalculator= reuseRatingCalculator;
            frameConverter = new FrameConverter(dbDoc);
        }

        public void runScheming()
        {

            /* 1. BUILD REVIT COLLECTOR FILTERS */

            // StructuralType Filters
            ElementStructuralTypeFilter filterBeams = new ElementStructuralTypeFilter(Autodesk.Revit.DB.Structure.StructuralType.Beam);
            ElementStructuralTypeFilter filterColumns = new ElementStructuralTypeFilter(Autodesk.Revit.DB.Structure.StructuralType.Column);
            ElementStructuralTypeFilter filterBraces = new ElementStructuralTypeFilter(Autodesk.Revit.DB.Structure.StructuralType.Brace);
            // List of Filters
            List<ElementFilter> filtersList = new List<ElementFilter>() { filterBeams, filterColumns, filterBraces };
            // Logical Or Filter
            LogicalOrFilter filterStrFrames = new LogicalOrFilter(filtersList);

            /* 2. EXTRACT REVIT STRUCTURAL FRAMES*/

            // FilteredElementCollector
            FilteredElementCollector elemCollector = new FilteredElementCollector(this.dbDoc);
            frameElements = elemCollector.OfClass(typeof(FamilyInstance)).WherePasses(filterStrFrames).ToList();

            /* 3. CONVERT REVIT TO SOFTWARE-AGNOSTIC FRAME OBJECTS */
            steelFrames = frameElements.Select(elem => frameConverter.getFrameObj(elem)).ToList();
            existingSteelFrames = steelFrames.Select(sframe => new ExistingSteelFrame(sframe)).ToList();

            /* 4. CALCULATE REUSE RATING FOR SOFTWARE-AGNOSTIC STEEL FRAME OBJECTS */
            existingSteelFrames.ForEach(esframe => this.reuseRatingCalculator.calculateRating(esframe));

            existingSteelFrames.Sort((x, y) => x.getFrame().getUniqueId().CompareTo(y.getFrame().getUniqueId()));



        }


        public void UpdateReuseRatings()
        {
            Transaction revitTransaction = null;

            try
            {

                //Start New Transaction
                if (!dbDoc.IsModifiable)
                {
                    revitTransaction = new Transaction(dbDoc, "Reuse Rating");
                    revitTransaction.Start();
                }

                frameElements.ForEach(frameEl =>
                {
                    String frameElId = frameEl.Id.ToString();

                    int index = existingSteelFrames.Select(esf => esf.getFrame().getUniqueId()).ToList()
                                                 .BinarySearch(frameElId);
                    ReuseRating reuseRating = existingSteelFrames[index].getReuseRating();

                    frameEl.LookupParameter("BHE_Survey Information").Set(reuseRating.ToString());
                });

                if (revitTransaction != null) { 
                    // Close and Dispose Transaction
                    revitTransaction.Commit();
                    revitTransaction.Dispose();
                }

            } catch (Exception ex) {

                if (revitTransaction != null) { 
                    
                    revitTransaction.RollBack();

                    TaskDialog.Show("ERROR MESSAGES", ex.Message);

                    // Close and Dispose Transaction
                    revitTransaction.Commit();
                    revitTransaction.Dispose();
                }
            }


        }


        public void buildRevitViews()
        {
            Transaction revitTransaction = null;

            try
            {

                //Start New Transaction
                if (!dbDoc.IsModifiable)
                {
                    revitTransaction = new Transaction(dbDoc, "Reuse Rating");
                    revitTransaction.Start();
                }

                View view = ViewsFactory.getInstance().create(dbDoc, RevitViewType.THREE_D, "Reuse Scheme");

                List<BuiltInCategory> categoriesList = new List<BuiltInCategory>()
                    { BuiltInCategory.OST_StructuralColumns, BuiltInCategory.OST_StructuralFraming};
                List<String> materialsList = new List<String>() { "Steel" };
                ViewFiltersFactory.getInstance().createNewFilter(view, categoriesList, materialsList, "BHE_Survey Information");

                ViewSheetBuilder.initialise(ViewSheet.CreatePlaceholder(dbDoc));
                ViewSheetBuilder.buildTitleBlock("Project JIOM - HOI - A0 - Project North");

                ViewportLocationOnSheet location = new ViewportLocationOnSheet(SheetColumn.C01, SheetRow.R01);
                ViewportSizeOnSheet size = new ViewportSizeOnSheet(SheetColumn.C06, SheetRow.R04);
                ViewSheetBuilder.buildViewPort(view,location, size);

                if (revitTransaction != null)
                {
                    // Close and Dispose Transaction
                    revitTransaction.Commit();
                    revitTransaction.Dispose();
                }

            }
            catch (Exception ex)
            {
                if (revitTransaction != null)
                {
                    revitTransaction.RollBack();

                    TaskDialog.Show("ERROR MESSAGES", ex.Message);

                    // Close and Dispose Transaction
                    revitTransaction.Commit();
                    revitTransaction.Dispose();
                }
            }

        }


        public void setRevitUIApp(Autodesk.Revit.UI.UIApplication uiApp)
        {
            if (uiApp == null) throw new MissingInputsException("Revit UI Application is missing/not valid.");
            this.uiApp = uiApp;
        }

        // METHODS

        public void registerObserver(Observer o){this.observers.Add(o);}
        public void removeObserver(Observer o){this.observers.Remove(o);}
        public void notifyObservers(){this.observers.ForEach(o=>o.update());}


        public string getModelName() { return MODEL_NAME; }
        public string getModelVersion() { return MODEL_VERSION; }
        public string getModelCopyRight() { return MODEL_COPYRIGHT; }
        public string getModelAuthor() { return MODEL_AUTHOR; }
        public string getModelOwner() { return MODEL_OWNER; }

    }
}
