using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Events;
using Autodesk.Revit.DB.Structure;
using Autodesk.Revit.Exceptions;
using Autodesk.Revit.UI;
using Microsoft.Office.Interop.Excel;
using Newtonsoft.Json.Linq;
using ReuseSchemeTool.model;
using ReuseSchemeTool.model.revit;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Media;
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
        private ExcelDataManager excelDataManager;
        public Queue<Autodesk.Revit.DB.View> revitViews = new Queue<Autodesk.Revit.DB.View>();
        private string outputsParentFolderPath;
        private string outputsFolderPath;
        private string jsonFilesFolderPath;
        private string excelFilesFolderPath;
        private string pdfFilesFolderPath;
        private List<string> folderPaths;
        private bool inspectorTool_pullRevitDataRun = false;
        private bool inspectorTool_convertDataRun = false;
        private bool inspectorTool_pushToExcelRun = false;
        private bool inspectorTool_processComplete = false;
        private bool schemeTool_schemingRun = false;
        private bool schemeTool_updateReuseRatingRun = false;
        private bool schemeTool_buildRevitViewsRun = false;
        private bool schemeTool_processComplete = false;
        private int numSteps = 3;

        private const string EMBEDDEDFILEPATH_XLSM_DATABASE = "ReuseSchemeTool.model.excel_files.Database_Graphs.xlsm";

        private const string MODEL_INSPECTOR_NAME = "Reuse Inspector Tool";
        private const string MODEL_SCHEMING_NAME = "Reuse Scheme Tool";
        private const string MODEL_VERSION = "Version: " + "1.0.0";
        private const string MODEL_COPYRIGHT = "Copyright @ Buro Happold Ltd Inc.2024";
        private const string MODEL_AUTHOR = "Giorgio Carlo Roberto Albieri";
        private const string MODEL_OWNER = "Buro Happold Ltd";


        // STATIC METHOD .getInstance()
        public static RST_Model getInstance()
        {
            if (instance == null) return new RST_Model();
            return instance;
        }


        // CONSTRUCTOR - Private
        private RST_Model()
        {
            this.observers = new List<Observer>();
            this.jsonSerializer = new JSONSerializer<List<FrameDecorator>>();
            this.existingSteelFrames = new List<ExistingSteelFrame>();
            this.proposedSteelFrames = new List<ProposedSteelFrame>();

        }


        public void initialize(Autodesk.Revit.UI.UIApplication uiApp)
        {
            if (uiApp == null) throw new MissingInputsException("Revit UI Application is missing/not valid.");
            this.uiApp = uiApp;
            this.uiDoc = uiApp.ActiveUIDocument;
            this.dbDoc = uiDoc.Document;
            frameConverter = new FrameConverter(dbDoc);
        }


        public void initialize(Autodesk.Revit.UI.UIApplication uiApp, ReuseRatingCalculator reuseRatingCalculator)
        {
            this.initialize(uiApp);
            this.reuseRatingCalculator = reuseRatingCalculator;
        }


        private void initializeOutputFolders(Tool tool)
        {
            // LOCATION OF REVITMODELPATH TO BE REVIEWED !!!!!!!!!!! ******
            string revitModelPath = "c:\\Users\\galbieri\\Buro Happold\\Design & Technology - R&D Wishlist\\00728_STR Steel Re-use\\03_Reference Revit Model\\JIM-BHC-S4-04-002-100-ZZ-M3-ST-000001_rvt.rvt";

            switch (tool)
            {
                case (Tool.INSPECTOR):
                    this.outputsFolderPath = FileManager.setDatedFolderPath(this.outputsParentFolderPath, "RST_Inspector_Ouputs");
                    this.excelFilesFolderPath = this.outputsFolderPath + "\\EXCEL_Files";
                    this.pdfFilesFolderPath = this.outputsFolderPath + "\\PDF_Files";
                    folderPaths = new List<string>() { this.excelFilesFolderPath, this.pdfFilesFolderPath };
                    break;
                case (Tool.SCHEME):
                    this.outputsFolderPath = FileManager.setDatedFolderPath(this.outputsParentFolderPath, "RST_Scheming_Ouputs");
                    this.jsonFilesFolderPath = this.outputsFolderPath + "\\JSON_Files";
                    this.excelFilesFolderPath = this.outputsFolderPath + "\\EXCEL_Files";
                    this.pdfFilesFolderPath = this.outputsFolderPath + "\\PDF_Files";
                    folderPaths = new List<string>() { this.jsonFilesFolderPath, this.excelFilesFolderPath, this.pdfFilesFolderPath };
                    break;
            }

            foreach (string folder in folderPaths)
            {
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
            }
        }


        public void runInspection()
        {

            initializeOutputFolders(Tool.INSPECTOR);

            /* 1. EXTRACT REVIT STRUCTURAL FRAMES*/
            RevitElementsCollector revitFramesCollector = new RevitElementsCollector(new RevitFramesCollectorStrategy(this.dbDoc));
            revitFramesCollector = new BHEParameterFilter(revitFramesCollector, "BHE_Reuse Strategy", "EXISTING TO DISMANTLE - TO RECYCLE");
            revitFramesCollector = new BHEParameterFilter(revitFramesCollector, "BHE_Material", "Steel");
            revitFramesCollector = new PhaseCreatedFilter(revitFramesCollector, "Existing");
            frameElements = revitFramesCollector.collectElements();

            this.inspectorTool_pullRevitDataRun = true;
            this.notifyObservers();

            /* 2. CONVERT REVIT TO SOFTWARE-AGNOSTIC FRAME OBJECTS */
            steelFrames = frameElements.Select(elem => frameConverter.getObj(elem)).ToList();
            existingSteelFrames = steelFrames.Select(sframe => new ExistingSteelFrame(sframe)).ToList();

            this.inspectorTool_convertDataRun = true;
            this.notifyObservers();

            /* 3. GENERATE OUTPUTS */
            // Excel File
            this.createExcelFile(EMBEDDEDFILEPATH_XLSM_DATABASE, this.excelFilesFolderPath, existingSteelFrames, Tool.INSPECTOR);

            this.inspectorTool_pushToExcelRun = true;
            this.inspectorTool_processComplete = true;
            this.notifyObservers();

        }


        public void runScheming()
        {

            initializeOutputFolders(Tool.SCHEME);

            /* 1. EXTRACT REVIT STRUCTURAL FRAMES*/
            RevitElementsCollector revitFramesCollector = new RevitElementsCollector(new RevitFramesCollectorStrategy(this.dbDoc));
            revitFramesCollector = new BHEParameterFilter(revitFramesCollector, "BHE_Reuse Strategy", "EXISTING TO DISMANTLE - TO RECYCLE");
            revitFramesCollector = new BHEParameterFilter(revitFramesCollector, "BHE_Material", "Steel");
            revitFramesCollector = new PhaseCreatedFilter(revitFramesCollector, "Existing");
            frameElements = revitFramesCollector.collectElements();

            /* 2. CONVERT REVIT TO SOFTWARE-AGNOSTIC FRAME OBJECTS */
            steelFrames = frameElements.Select(elem => frameConverter.getObj(elem)).ToList();
            existingSteelFrames = steelFrames.Select(sframe => new ExistingSteelFrame(sframe)).ToList();

            /* 3. CALCULATE REUSE RATING FOR SOFTWARE-AGNOSTIC STEEL FRAME OBJECTS */
            // Computation
            existingSteelFrames.ForEach(esframe => this.reuseRatingCalculator.calculateRating(esframe));
            // Sorting data
            existingSteelFrames.Sort((x, y) => x.getFrame().getUniqueId().CompareTo(y.getFrame().getUniqueId()));

            /* 4. SERAILIZE FRAME OBJECT TO JSON */
            this.serialize(existingSteelFrames);

            /* 5. GENERATE OUTPUTS */
            // Excel File
            this.createExcelFile(EMBEDDEDFILEPATH_XLSM_DATABASE, this.excelFilesFolderPath, existingSteelFrames, Tool.SCHEME);


            this.schemeTool_schemingRun = true;

            this.notifyObservers();

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


            this.schemeTool_updateReuseRatingRun = true;

            this.notifyObservers();

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

                RevitFileManager.loadEmbeddedRevitFamilies(dbDoc, "ReuseSchemeTool.model.revit_files.Revit2020");

                Autodesk.Revit.DB.View ThreeDView = ViewsFactory.getInstance().create(dbDoc, RevitViewType.THREE_D, "Reuse Scheme 3D View", 100);

                // Collect only the Existing Steel Frames
                RevitElementsCollector revitFramesCollector = new RevitElementsCollector(new RevitFramesCollectorStrategy(this.dbDoc));
                revitFramesCollector = new BHEParameterFilter(revitFramesCollector, "BHE_Material", "Steel");
                revitFramesCollector = new PhaseCreatedFilter(revitFramesCollector, "Existing");
                // Show only the Existing Steel Frames in the 3D View
                ThreeDView.UnhideElements(revitFramesCollector.collectElements().Select(f => f.Id).ToList());
                ThreeDView.IsolateElementsTemporary(revitFramesCollector.collectElements().Select(f => f.Id).ToList());

                List<BuiltInCategory> categoriesList = new List<BuiltInCategory>()
                    { BuiltInCategory.OST_StructuralColumns, BuiltInCategory.OST_StructuralFraming};
                List<String> materialsList = new List<String>() { "Steel" };
                ViewFiltersFactory.getInstance().createNewBHFilters(ThreeDView, categoriesList, materialsList, "BHE_Survey Information", BHColorPalette.TRAFFICLIGHTS_BRIGHT, false);

                // Color all Elements with a semi-transparent grey color
                OverrideGraphicSettings overrideSettings = new OverrideGraphicSettings();
                System.Drawing.Color systBHGreyColor = ColorsFactory.getInstance().createBHColor(BHColor.MUTED_GREY); // RGB values for grey
                Autodesk.Revit.DB.Color revitBHGreyColor = new Autodesk.Revit.DB.Color(systBHGreyColor.R, systBHGreyColor.G, systBHGreyColor.B);
                ViewFiltersFactory.getInstance().createNewFilter(ThreeDView, categoriesList, "OTHER TO BE RETAINED", "BHE_Reuse Strategy", "EXISTING TO DISMANTLE - TO RECYCLE", revitBHGreyColor, 75, true);

                revitViews.Enqueue(ThreeDView);



                List<KeyValuePair<string, Autodesk.Revit.DB.Color>> viewFiltersData = ThreeDView.GetFilters()
                    .ToDictionary(elId =>
                    {
                        string filterName = dbDoc.GetElement(elId).Name.Replace('_', ' ');
                        switch (filterName)
                        {
                            case "OUTSIDE CRITERIA":
                                filterName = "DISMANTLED STEELWORK OUTSIDE CRITERIA";
                                break;
                            case "WITHIN CRITERIA":
                                filterName = "DISMANTLED STEELWORK WITHIN CRITERIA";
                                break;
                            case "OTHER TO BE RETAINED":
                                filterName = "OTHER EXISTING STEELWORK TO BE RETAINED";
                                break;
                        }
                        return filterName;
                    },
                    elId => ThreeDView.GetFilterOverrides(elId).SurfaceForegroundPatternColor).ToList();

                viewFiltersData.Sort((kvp1, kvp2) => kvp1.Key.Length.CompareTo(kvp2.Key.Length));

                ViewDrafting legendView = (ViewDrafting)ViewsFactory.getInstance().create(dbDoc, RevitViewType.DRAFTING, "Reuse Scheme Legend", 20);


                ViewDraftingsFactory.getInstance().createLegend(legendView, "Legend", viewFiltersData.Select(kvp => kvp.Key).ToList(), viewFiltersData.Select(kvp => kvp.Value).ToList());




                ViewDrafting notesView = (ViewDrafting)ViewsFactory.getInstance().create(dbDoc, RevitViewType.DRAFTING, "Reuse Scheme Design Notes", 20);
                UserDefined_RatingStrategy ratingStrategy = (UserDefined_RatingStrategy)this.reuseRatingCalculator.getRatingStrategy();


                List<string> notes = new List<string>
                {
                    "APPLICABLE SECTION TYPES ARE: " + ratingStrategy.allowedSectionTypes.Aggregate((current,next)=>current +", "+next),
                    "APPLICABLE STEEL GRADES ARE: " + ratingStrategy.allowedMaterials.Aggregate((current,next)=>current +", "+next),
                    "MINIMUM LENGTH IS : " + Math.Round(ratingStrategy.lengthRange.Min(),1).ToString() + " m",
                    "MAXIMUM LENGTH IS : " + Math.Round(ratingStrategy.lengthRange.Max(),1).ToString() + " m",
                    "MINIMUM WEIGHT IS : " + Math.Round(ratingStrategy.weightRange.Min(),1).ToString() + " kg/m",
                    "MAXIMUM WEIGHT IS : " + Math.Round(ratingStrategy.weightRange.Max(),1).ToString() + " kg/m",
                    "CONNECTION OFFCUT LENGTH IS : " + Math.Round(ratingStrategy.endCutOffLength*1000.0,0).ToString() + " mm",

                };
                Autodesk.Revit.DB.Color revitBlackColor = new Autodesk.Revit.DB.Color(0, 0, 0);
                ViewDraftingsFactory.getInstance().createNotesBox(notesView, "Selection Criteria", notes, revitBlackColor);




                ViewDrafting pcItemsView = (ViewDrafting)ViewsFactory.getInstance().create(dbDoc, RevitViewType.DRAFTING, "Reuse Scheme Pie Chart - Known vs Unknown", 20);

                FilteredElementCollector elmsCollector = null;
                ElementFilter elemFilter = null;
                IList<Element> filteredElements = null;


                List<Element> toDismantleFrames = revitFramesCollector.collectElements().Where(el => el.LookupParameter("BHE_Reuse Strategy").AsString().Contains("EXISTING TO DISMANTLE")).ToList();
                List<Element> knownToDismantleFrames = toDismantleFrames.Where(el => !el.LookupParameter("BHE_Reuse Strategy").AsString().Contains("UNKNOWN")).ToList();
                List<Element> unknownToDismantleFrames = toDismantleFrames.Where(el => el.LookupParameter("BHE_Reuse Strategy").AsString().Contains("UNKNOWN")).ToList();

                double lenKnown = Math.Round(knownToDismantleFrames.Select(el => UnitUtils.ConvertFromInternalUnits(el.LookupParameter("Length").AsDouble(), UnitTypeId.Meters)).Sum(), 1);
                double lenUnknown = Math.Round(unknownToDismantleFrames.Select(el => UnitUtils.ConvertFromInternalUnits(el.LookupParameter("Length").AsDouble(), UnitTypeId.Meters)).Sum(), 1);
                Autodesk.Revit.DB.Color colorKnown = ColorAdapter.convertToRevit(ColorsFactory.getInstance().createBHColor(BHColor.MUTED_DUCK_EGG));
                Autodesk.Revit.DB.Color colorUnknown = ColorAdapter.convertToRevit(ColorsFactory.getInstance().createBHColor(BHColor.MUTED_PLUM));

                List<PieSliceData> pieSlicesData = new List<PieSliceData> { new PieSliceData("KNOWN", lenKnown, colorKnown), new PieSliceData("UNKNOWN", lenUnknown, colorUnknown) };

                ViewDraftingsFactory.getInstance().createPieChart(pcItemsView, pieSlicesData, "Known vs Unknown Dismantled Elements", "by length", "m", true);




                ViewDrafting pcMatView = (ViewDrafting)ViewsFactory.getInstance().create(dbDoc, RevitViewType.DRAFTING, "Reuse Scheme Pie Chart - Steel Within Criteria", 20);

                pieSlicesData = ThreeDView.GetFilters().
                    Where(elId => !dbDoc.GetElement(elId).Name.Contains("OTHER")).
                    Select(elId =>
                    {
                        string name = dbDoc.GetElement(elId).Name.Replace('_', ' ');

                        elmsCollector = new FilteredElementCollector(dbDoc, ThreeDView.Id);
                        // Step 4: Apply the Filter to the Collector
                        elemFilter = ((ParameterFilterElement)dbDoc.GetElement(elId)).GetElementFilter();
                        filteredElements = elmsCollector.OfClass(typeof(FamilyInstance)).WherePasses(elemFilter).ToElements();

                        double value = filteredElements.Sum(el => {

                            Autodesk.Revit.DB.Parameter lengthParam = el.LookupParameter("Length");
                            Autodesk.Revit.DB.Parameter weightParam = ((FamilyInstance)el).Symbol.LookupParameter("Nominal Weight");

                            if (lengthParam != null && weightParam != null)
                            {
                                double length_m = UnitUtils.ConvertFromInternalUnits(lengthParam.AsDouble(), UnitTypeId.Meters);
                                double weight_kg_m = UnitUtils.ConvertFromInternalUnits(weightParam.AsDouble() / 9.80665, UnitTypeId.Tonnes);
                                return Math.Round(length_m * weight_kg_m, 0);
                            }
                            // *********************************************************************************************************************
                            // ADD A WARNING FOR THE USER HIGHLIGHTING WHICH REVIT ELEMENTS HAVE ONE OF THE TWO PARAMETERS ABOVE =NULL !!! *********
                            // *********************************************************************************************************************

                            return 0.0;

                        });

                        Autodesk.Revit.DB.Color color = ThreeDView.GetFilterOverrides(elId).SurfaceForegroundPatternColor;

                        return new PieSliceData(name, value, color);

                    }).ToList();

                pieSlicesData.Reverse();

                ViewDraftingsFactory.getInstance().createPieChart(pcMatView, pieSlicesData, "Known Dismantled Elements - Steel Within Criteria", "by weight", "tonnes", true);




                List<ChartData> chartData;
                chartData = ThreeDView.GetFilters().
                    Where(elId => dbDoc.GetElement(elId).Name.Contains("CRITERIA")).
                    Select(elId =>
                    {
                        string name = dbDoc.GetElement(elId).Name.Replace('_', ' ');

                        elmsCollector = new FilteredElementCollector(dbDoc, ThreeDView.Id);
                        // Step 4: Apply the Filter to the Collector
                        elemFilter = ((ParameterFilterElement)dbDoc.GetElement(elId)).GetElementFilter();
                        filteredElements = elmsCollector.OfClass(typeof(FamilyInstance)).WherePasses(elemFilter).ToElements();

                        double value = filteredElements.Sum(el => {

                            Autodesk.Revit.DB.Parameter lengthParam = el.LookupParameter("Length");
                            Autodesk.Revit.DB.Parameter weightParam = ((FamilyInstance)el).Symbol.LookupParameter("Nominal Weight");

                            if (lengthParam != null && weightParam != null)
                            {
                                double length_m = UnitUtils.ConvertFromInternalUnits(lengthParam.AsDouble(), UnitTypeId.Meters);
                                double weight_kg_m = UnitUtils.ConvertFromInternalUnits(weightParam.AsDouble() / 9.80665, UnitTypeId.Tonnes);
                                return Math.Round(length_m * weight_kg_m, 0);
                            }
                            // *********************************************************************************************************************
                            // ADD A WARNING FOR THE USER HIGHLIGHTING WHICH REVIT ELEMENTS HAVE ONE OF THE TWO PARAMETERS ABOVE =NULL !!! *********
                            // *********************************************************************************************************************

                            return 0.0;

                        });

                        Autodesk.Revit.DB.Color color = ThreeDView.GetFilterOverrides(elId).SurfaceForegroundPatternColor;

                        return new ChartData(name, value, color);

                    }).ToList();


                chartData.ForEach(cd =>
                {
                    if (cd.getName().Contains("OUTSIDE")) { cd.setName("(Outside criteria kg * 1.6965) =\n" + cd.getValue() * 1.6965 + "kgCO2e additional savings"); }
                    if (cd.getName().Contains("WITHIN")) { cd.setName("(Inside criteria kg * 1.6965) =\n " + cd.getValue() * 1.6965 + "kgCO2e savings"); }
                });

                String c02SavingFactors_NotesFilePath = "ReuseSchemeTool.model.text_files.C02_SavingFactors.txt";
                String c02SavingFactors_Notes = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream(c02SavingFactors_NotesFilePath)).ReadToEnd();

                ViewDrafting bcC02SavingsView = (ViewDrafting)ViewsFactory.getInstance().create(dbDoc, RevitViewType.DRAFTING, "Reuse Scheme Bar Chart - Potential Carbon Savings", 20);

                ViewDraftingsFactory.getInstance().createBarChart(bcC02SavingsView, "Potential C02 Savings", chartData, BarChartType.STACKED, c02SavingFactors_Notes, false, true);






                Element filter = dbDoc.GetElement(ThreeDView.GetFilters().FirstOrDefault(elId => dbDoc.GetElement(elId).Name == "WITHIN_CRITERIA"));

                elmsCollector = new FilteredElementCollector(dbDoc, ThreeDView.Id);
                // Step 4: Apply the Filter to the Collector
                elemFilter = ((ParameterFilterElement)filter).GetElementFilter();
                filteredElements = elmsCollector.WherePasses(elemFilter).ToElements();

                filteredElements.ToList().Sort((el0, el1) => ((FamilyInstance)el1).Symbol.LookupParameter("Nominal Weight").AsDouble().CompareTo(((FamilyInstance)el0).Symbol.LookupParameter("Nominal Weight").AsDouble()));

                Dictionary<string, List<double>> stocksData = filteredElements
                    .GroupBy(el => el.Name)
                    .ToDictionary(grp => grp.Key, grp => grp.ToList().Select(el => UnitUtils.ConvertFromInternalUnits(el.get_Parameter(BuiltInParameter.INSTANCE_LENGTH_PARAM).AsDouble(), UnitTypeId.Millimeters)).ToList());


                ViewDrafting stockChartView = (ViewDrafting)ViewsFactory.getInstance().create(dbDoc, RevitViewType.DRAFTING, "Reuse Scheme Stock Chart", 20);

                Autodesk.Revit.DB.Color stockColor = ColorAdapter.convertToRevit(ColorsFactory.getInstance().createBHColor(BHColor.BRIGHT_GREEN));
                ViewDraftingsFactory.getInstance().createStockChart(stockChartView, "Stock Chart", stocksData, stockColor);


                ViewSheetBuilder.initialise(ViewSheet.CreatePlaceholder(dbDoc), "SKXXX", "STEEL REUSE POTENTIAL OVERVIEW");
                ViewSheetBuilder.buildTitleBlock("BHE_A1");
                ViewportLocationOnSheet location = new ViewportLocationOnSheet(SheetColumn.C01, SheetRow.R01);
                ViewportSizeOnSheet size = new ViewportSizeOnSheet(SheetColumn.C06, SheetRow.R04);
                ViewSheetBuilder.buildViewPort(ThreeDView, location, size);


                ViewSheetBuilder.buildViewPort(notesView, new ViewportLocationOnSheet(SheetColumn.C01, SheetRow.R12), false);

                ViewSheetBuilder.buildViewPort(legendView, new ViewportLocationOnSheet(SheetColumn.C07, SheetRow.R12), false);

                ViewSheetBuilder.buildViewPort(pcItemsView, new ViewportLocationOnSheet(SheetColumn.C01, SheetRow.R16), false);

                ViewSheetBuilder.buildViewPort(pcMatView, new ViewportLocationOnSheet(SheetColumn.C07, SheetRow.R16), false);

                ViewSheetBuilder.buildViewPort(stockChartView, new ViewportLocationOnSheet(SheetColumn.C13, SheetRow.R01), false);

                ViewSheetBuilder.buildViewPort(bcC02SavingsView, new ViewportLocationOnSheet(SheetColumn.C09, SheetRow.R01), false);

                ViewSheet viewSheet = ViewSheetBuilder.getViewSheet();

                revitViews.Enqueue(viewSheet);


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

            this.schemeTool_buildRevitViewsRun = true;
            this.schemeTool_processComplete = true;

            this.notifyObservers();

        }


        public void setRevitUIApp(Autodesk.Revit.UI.UIApplication uiApp)
        {
            if (uiApp == null) throw new MissingInputsException("Revit UI Application is missing/not valid.");
            this.uiApp = uiApp;
        }



        public void createExcelFile(string embeddedFilePath, string outputsFolderPath, List<ExistingSteelFrame> existingSteelFrames, Tool tool)
        {

            excelDataManager = new ExcelDataManager(embeddedFilePath, outputsFolderPath);
            excelDataManager.initialize(false, true);

            switch (tool)
            {
                case (Tool.INSPECTOR):
                    excelDataManager.write(existingSteelFrames, "Inputs", "A2");
                    excelDataManager.getExcelApp().Run("Module1.ResetGraphs");
                    break;
                case (Tool.SCHEME):
                    string endCutOffLength = ((UserDefined_RatingStrategy)this.reuseRatingCalculator.getRatingStrategy()).endCutOffLength.ToString();
                    excelDataManager.write(new string[] { endCutOffLength }, "Steel Reuse Dashboard", new string[] { "endCutOffLength" });
                    excelDataManager.write(existingSteelFrames.Where(esf => esf.getReuseRating() == ReuseRating.WITHIN_CRITERIA).ToList(), "Inputs", "A2");
                    break;
            }

            excelDataManager.refreshWorkbook();
            excelDataManager.hideWorksheet("Inputs");
            excelDataManager.printWorkSheet("Steel Reuse Dashboard", this.pdfFilesFolderPath);

            if (tool == Tool.INSPECTOR)
            {
                excelDataManager.refreshWorkbook();
                excelDataManager.dispose();
            }

            if (tool == Tool.SCHEME)
            {
                excelDataManager.protectWorkbook(true);
                excelDataManager.dispose();
            }

        }


        public void serialize<T>(List<T> frames) where T : FrameDecorator
        {
            // SERIALIZE OUTPUTS IN A JSON FILE
            //1. Sort the Objects based on a user-defined Comparator
            List<FrameDecorator> frameDecorators = frames.Cast<FrameDecorator>().ToList();
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

        // Observer Pattern
        public void registerObserver(Observer o) { this.observers.Add(o); }
        public void removeObserver(Observer o) { this.observers.Remove(o); }
        public void notifyObservers() { this.observers.ForEach(o => o.update()); }

        // Getters
        public string getModelName(Tool tool)
        {
            switch (tool)
            {
                case Tool.INSPECTOR:
                    return MODEL_INSPECTOR_NAME;
                    break;
                case Tool.SCHEME:
                    return MODEL_SCHEMING_NAME;
                    break;
            }

            return null;
        }

        public void setOutputsParentFolderPath (string outputsParentFolderPath) { this.outputsParentFolderPath = outputsParentFolderPath; }
        public string getOutputsParentFolderPath() { return this.outputsParentFolderPath; }
        public ExcelDataManager getExcelDataManager() { return this.excelDataManager; }
        public string getModelVersion() { return MODEL_VERSION; }
        public string getModelCopyRight() { return MODEL_COPYRIGHT; }
        public string getModelAuthor() { return MODEL_AUTHOR; }
        public string getModelOwner() { return MODEL_OWNER; }
        public int getNumSteps() { return this.numSteps; }
        public bool isSchemingRun() { return this.schemeTool_schemingRun; }
        public bool isUpdateReuseRatingRun() { return this.schemeTool_updateReuseRatingRun; }
        public bool isBuildRevitViewsRun() { return this.schemeTool_buildRevitViewsRun; }
        public bool isSchemingComplete() { return this.schemeTool_processComplete; }
        public bool isPullRevitDataRun() { return this.inspectorTool_pullRevitDataRun; }
        public bool isConvertDataRun() { return this.inspectorTool_convertDataRun; }
        public bool isPushToExcelRun() { return this.inspectorTool_pushToExcelRun; }
        public bool isInspectionComplete() { return this.inspectorTool_processComplete; }


    }
}
