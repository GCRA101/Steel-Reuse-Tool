using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Events;
using Autodesk.Revit.DB.Structure;
using Autodesk.Revit.Exceptions;
using Autodesk.Revit.UI;
using Microsoft.Office.Interop.Excel;
using Newtonsoft.Json.Linq;
using ReuseSchemeTool.model.revit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Shapes;

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
        public Stack<View> revitViews = new Stack<View>();
        private string outputsFolderPath;
        private string jsonFilesFolderPath;
        private string excelFilesFolderPath;
        private string pdfFilesFolderPath;
        private List<string> folderPaths;


        private const string EMBEDDEDFILEPATH_XLSM_DATABASE = "ReuseSchemeTool.excelFiles.Database_Graphs.xlsm";

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

            initializeOutputFolders();

        }

        private void initializeOutputFolders()
        {
            // LOCATION OF REVITMODELPATH TO BE REVIEWED !!!!!!!!!!! ******
            string revitModelPath = "c:\\Users\\galbieri\\Buro Happold\\Design & Technology - R&D Wishlist\\00728_STR Steel Re-use\\03_Reference Revit Model\\JIM-BHC-S4-04-002-100-ZZ-M3-ST-000001_rvt.rvt";
            this.outputsFolderPath = FileManager.setDatedFolderPath(System.IO.Path.GetDirectoryName(revitModelPath), "RST_Ouputs");
            this.jsonFilesFolderPath = this.outputsFolderPath + "\\JSON_Files";
            this.excelFilesFolderPath = this.outputsFolderPath + "\\EXCEL_Files";
            this.pdfFilesFolderPath = this.outputsFolderPath + "\\PDF_Files";

            folderPaths = new List<string>() { this.jsonFilesFolderPath, this.excelFilesFolderPath, this.pdfFilesFolderPath};

            foreach (string folder in folderPaths) 
            { 
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
            }
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
            frameElements.Select(el => !string.IsNullOrWhiteSpace(el.LookupParameter("BHE_Reuse Strategy").AsString()));

            /* 3. CONVERT REVIT TO SOFTWARE-AGNOSTIC FRAME OBJECTS */
            steelFrames = frameElements.Select(elem => frameConverter.getFrameObj(elem)).ToList();
            existingSteelFrames = steelFrames.Select(sframe => new ExistingSteelFrame(sframe)).ToList();

            /* 4. CALCULATE REUSE RATING FOR SOFTWARE-AGNOSTIC STEEL FRAME OBJECTS */
            existingSteelFrames.ForEach(esframe => this.reuseRatingCalculator.calculateRating(esframe));

            existingSteelFrames.Sort((x, y) => x.getFrame().getUniqueId().CompareTo(y.getFrame().getUniqueId()));

            this.serialize(existingSteelFrames);

            ExcelDataManager excelDataManager = new ExcelDataManager(EMBEDDEDFILEPATH_XLSM_DATABASE, this.excelFilesFolderPath);
            excelDataManager.initialize();

            string endCutOffLength = ((UserDefined_RatingStrategy)this.reuseRatingCalculator.getRatingStrategy()).endCutOffLength.ToString();
            excelDataManager.write(new string[] {endCutOffLength}, "Steel Reuse Dashboard", new string[] { "endCutOffLength" });
            excelDataManager.write(existingSteelFrames.Where(esf=>esf.getReuseRating()==ReuseRating.MUST_HAVE).ToList(), "Inputs", "A2");
            excelDataManager.refreshWorkbook();
            excelDataManager.hideWorksheet("Inputs");
            excelDataManager.printWorkSheet("Steel Reuse Dashboard", this.pdfFilesFolderPath);
            excelDataManager.protectWorkbook(true);
            excelDataManager.dispose();
            
        }

        public void updateReuseRatings()
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

                View ThreeDView = ViewsFactory.getInstance().create(dbDoc, RevitViewType.THREE_D, "Reuse Scheme 3D View", 100);

                List<BuiltInCategory> categoriesList = new List<BuiltInCategory>()
                    { BuiltInCategory.OST_StructuralColumns, BuiltInCategory.OST_StructuralFraming};
                List<String> materialsList = new List<String>() { "Steel" };
                ViewFiltersFactory.getInstance().createNewFilter(ThreeDView, categoriesList, materialsList, "BHE_Survey Information", ColorPalette.TRAFFICLIGHTS);

                revitViews.Push(ThreeDView);

                Dictionary<string, Color> viewFiltersData = ThreeDView.GetFilters().ToDictionary(elId => dbDoc.GetElement(elId).Name, elId => ThreeDView.GetFilterOverrides(elId).SurfaceForegroundPatternColor);

                ViewDrafting legendView = (ViewDrafting)ViewsFactory.getInstance().create(dbDoc, RevitViewType.DRAFTING, "Reuse Scheme Legend", 20);
                ViewDraftingsFactory.getInstance().createLegend(legendView, "Legend", viewFiltersData.Keys.ToList(), viewFiltersData.Values.ToList());

                revitViews.Push(legendView);


                ViewDrafting pcItemsView = (ViewDrafting)ViewsFactory.getInstance().create(dbDoc, RevitViewType.DRAFTING, "Reuse Scheme Pie Chart - Item Quantities", 20);

                FilteredElementCollector elmsCollector = null;
                ElementFilter elemFilter = null;
                IList<Element> filteredElements = null;

                List<PieSliceData> pieSlicesData = ThreeDView.GetFilters().Select(elId =>
                {
                    string name = dbDoc.GetElement(elId).Name;

                    elmsCollector = new FilteredElementCollector(dbDoc, ThreeDView.Id);
                    // Step 4: Apply the Filter to the Collector
                    elemFilter = ((ParameterFilterElement)dbDoc.GetElement(elId)).GetElementFilter();
                    filteredElements = elmsCollector.WherePasses(elemFilter).ToElements();
                    long value = filteredElements.Count();

                    Color color = ThreeDView.GetFilterOverrides(elId).SurfaceForegroundPatternColor;

                    return new PieSliceData(name, value, color);

                }).ToList();

                ViewDraftingsFactory.getInstance().createPieChart(pcItemsView, "Pie Chart - Item Quantities", pieSlicesData, "items");

                revitViews.Push(pcItemsView);



                ViewDrafting pcMatView = (ViewDrafting)ViewsFactory.getInstance().create(dbDoc, RevitViewType.DRAFTING, "Reuse Scheme Pie Chart - Material Quantities", 20);

                pieSlicesData = ThreeDView.GetFilters().Select(elId =>
                {
                    string name = dbDoc.GetElement(elId).Name;

                    elmsCollector = new FilteredElementCollector(dbDoc, ThreeDView.Id);
                    // Step 4: Apply the Filter to the Collector
                    elemFilter = ((ParameterFilterElement)dbDoc.GetElement(elId)).GetElementFilter();
                    filteredElements = elmsCollector.WherePasses(elemFilter).ToElements();
                    
                    double value = filteredElements.Sum(el => {
                        
                        Autodesk.Revit.DB.Parameter lengthParam = el.LookupParameter("Length");
                        Autodesk.Revit.DB.Parameter weightParam = ((FamilyInstance)el).Symbol.LookupParameter("Nominal Weight");
                        
                        if (lengthParam != null && weightParam != null)
                        {
                            double length_m = UnitUtils.ConvertFromInternalUnits(el.LookupParameter("Length").AsDouble(), UnitTypeId.Meters);
                            double weight_kg_m = UnitUtils.ConvertFromInternalUnits(((FamilyInstance)el).Symbol.LookupParameter("Nominal Weight").AsDouble() / 9.80665, UnitTypeId.Tonnes);
                            return Math.Round(length_m * weight_kg_m,0);
                        }
                        // *********************************************************************************************************************
                        // ADD A WARNING FOR THE USER HIGHLIGHTING WHICH REVIT ELEMENTS HAVE ONE OF THE TWO PARAMETERS ABOVE =NULL !!! *********
                        // *********************************************************************************************************************

                        return 0.0;

                        });

                    Color color = ThreeDView.GetFilterOverrides(elId).SurfaceForegroundPatternColor;

                    return new PieSliceData(name, value, color);

                }).ToList();

                ViewDraftingsFactory.getInstance().createPieChart(pcMatView, "Pie Chart - Material Quantities", pieSlicesData, "tonnes");

                revitViews.Push(pcMatView);



                Element filter = dbDoc.GetElement(ThreeDView.GetFilters().FirstOrDefault(elId => dbDoc.GetElement(elId).Name == "MUST_HAVE"));

                elmsCollector = new FilteredElementCollector(dbDoc, ThreeDView.Id);
                // Step 4: Apply the Filter to the Collector
                elemFilter = ((ParameterFilterElement)filter).GetElementFilter();
                filteredElements = elmsCollector.WherePasses(elemFilter).ToElements();

                filteredElements.ToList().Sort((el0, el1) => ((FamilyInstance)el1).Symbol.LookupParameter("Nominal Weight").AsDouble().CompareTo(((FamilyInstance)el0).Symbol.LookupParameter("Nominal Weight").AsDouble()));

                Dictionary<string, List<double>> stocksData = filteredElements
                    .GroupBy(el => el.Name)
                    .ToDictionary(grp => grp.Key, grp => grp.ToList().Select(el => UnitUtils.ConvertFromInternalUnits(el.get_Parameter(BuiltInParameter.INSTANCE_LENGTH_PARAM).AsDouble(), UnitTypeId.Millimeters)).ToList());


                ViewDrafting stockChartView = (ViewDrafting)ViewsFactory.getInstance().create(dbDoc, RevitViewType.DRAFTING, "Reuse Scheme Stock Chart", 20);

                ViewDraftingsFactory.getInstance().createStockChart(stockChartView, "Stock Chart",stocksData);

                revitViews.Push(stockChartView);

                ViewSheetBuilder.initialise(ViewSheet.CreatePlaceholder(dbDoc),"1010101","Reuse Scheme Summary");
                //ViewSheetBuilder.buildTitleBlock("Project JIOM - HOI - A0 - Project North");
                ViewSheetBuilder.buildTitleBlock("Standard_A1");
                ViewportLocationOnSheet location = new ViewportLocationOnSheet(SheetColumn.C01, SheetRow.R01);
                ViewportSizeOnSheet size = new ViewportSizeOnSheet(SheetColumn.C06, SheetRow.R04);
                ViewSheetBuilder.buildViewPort(ThreeDView, location, size);


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



        public void serialize<T>(List<T> frames) where T : FrameDecorator
        {
            // SERIALIZE OUTPUTS IN A JSON FILE
            //1. Sort the Objects based on a user-defined Comparator
            List<FrameDecorator> frameDecorators=frames.Cast<FrameDecorator>().ToList();
            //2. Build the Json File Name
            string jsonFilePath = FileManager.setDatedFilePath(this.jsonFilesFolderPath, "ExistingFramesToReuse.json");
            //3. Serialize the list of Frame Decorators
            this.jsonSerializer.serialize(frameDecorators, jsonFilePath);
        }

        public List<FrameDecorator> deserialize(string jsonFilePath)
        {
            // DESERIALIZE JSON FILE IN A LIST OF PILEOBJECTS
            return this.jsonSerializer.deserialize(jsonFilePath);
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
