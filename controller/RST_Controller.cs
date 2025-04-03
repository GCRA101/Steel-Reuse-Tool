using ReuseSchemeTool.model;
using ReuseSchemeTool.view;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReuseSchemeTool.controller
{
    public class RST_Controller : ControllerInterface
    {

        // ATTRIBUTES
        // References to Model and View
        public RST_Model model { get; set; }
        public RST_View view { get; set; }
        // Reference to Revit UI Application
        private Autodesk.Revit.UI.UIApplication uiApp { get; set; }
        // ExceptionHandlers
        private MissingInputsHandler missingInputsHandler { get; set; }
        // EventListeners
        private EventsListener eventsListener { get; set; }
        // AudioManagers
        private SoundManager soundManager { get; set; }
        // Other Variables
        private string jsonFilePath { get; set; }



        public RST_Controller(Autodesk.Revit.UI.UIApplication uiApp)
        {
            //Store the Revit UI Application
            this.uiApp = uiApp;
            //Instantiate the Model
            this.model = RST_Model.getInstance();
            //Instantiate the View
            this.view = new RST_View(this.model, this);
            //Instantiate AudioManagers
            this.soundManager = SoundManager.getInstance();
            //Instatiate EventsListener
            this.eventsListener = new EventsListener(this, this.view);
            //Instantiate ExceptionHandlers
            this.createExceptionHandlers();
        }

        public void createExceptionHandlers()
        {
            this.missingInputsHandler = new MissingInputsHandler(this);
        }

        public void deserialize()
        {
            throw new NotImplementedException();
        }

        public void initialize(Tool tool)
        {
            //Show the SplashScreen
            this.view.createSplashScreen(tool);
            //Show the AboutBox
            this.view.createAboutBox(tool);
            //Activate the EventsListener of the AboutBox
            this.eventsListener.initializeAboutBox(tool);
        }

        public void run(Tool tool)
        {
            switch (tool)
            {
                case Tool.INSPECTOR:
                    this.model.runInspection();
                    this.soundManager.play(Sound.END_INSPECTION);
                    break;
                case Tool.SCHEME:
                    try
                    {
                        this.model.runScheming();
                        this.model.updateReuseRatings();
                        this.model.buildRevitViews();
                        this.soundManager.play(Sound.END_SCHEME);
                    }
                    catch (MissingInputsException ex1)
                    {
                        missingInputsHandler.execute(ex1);
                    }
                    break;
            }

        }

        public void serialize()
            {
                throw new NotImplementedException();
            }

        public void terminate(Tool tool)
        {
            switch (tool)
            {
                case Tool.INSPECTOR:
                    //Close and dispose the progress bar view
                    this.view.getProgressBarView().Close();
                    this.view.getProgressBarView().Dispose();
                    System.Threading.Thread.Sleep(1000);
                    this.model.getExcelDataManager().initialize();
                    this.model.getExcelDataManager().visible(true);
                    this.model.getExcelDataManager().setTopMost();
                    break;
                case Tool.SCHEME:
                    //Close and dispose the form
                    this.view.getInputsView().Close();
                    this.view.getInputsView().Dispose();
                    //Close and dispose the progress bar view
                    this.view.getProgressBarView().Close();
                    this.view.getProgressBarView().Dispose();
                    break;
            }

        }

        public void processInputData()
        {
            // 1. Get the Input Data from the UI

            // SECTION TYPES
            //Get the list of section types selected by the user in the UI by the help of an Enumerator
            List<string> selSectionTypes = new List<string>();
            IEnumerator<string> enumerator = this.view.getInputsView().clbSectionTypes.CheckedItems.Cast<String>().GetEnumerator();
            while (enumerator.MoveNext()) { selSectionTypes.Add(enumerator.Current); }

            // STEEL GRADES
            //Get the list of steel grades selected by the user in the UI by the help of an Enumerator
            List<string> selSteelGrades = new List<string>();
            enumerator = this.view.getInputsView().clbSteelGrades.CheckedItems.Cast<String>().GetEnumerator();
            while (enumerator.MoveNext()) { selSteelGrades.Add(enumerator.Current); }

            // MAX/MIN LENGHTS
            Single[] lengthsRange = {
                Single.Parse(this.view.getInputsView().lblMinLengthValue.Text),
                Single.Parse(this.view.getInputsView().lblMaxLengthValue.Text)
            };

            // END CUT-OFF LENGTH
            Single endCutOffLength = Single.Parse(this.view.getInputsView().lblCutOffValue.Text);

            // MAX/MIN WEIGHTS
            Single[] weightsRange = {
                Single.Parse(this.view.getInputsView().lblMinWeightValue.Text),
                Single.Parse(this.view.getInputsView().lblMaxWeightValue.Text)
            };

            UserDefined_RatingStrategy udRatingStrategy = 
                new UserDefined_RatingStrategy(selSectionTypes, selSteelGrades, lengthsRange, weightsRange, endCutOffLength);

            ReuseRatingCalculator reuseRatingCalculator = new ReuseRatingCalculator(udRatingStrategy);

            this.model.initialize(this.uiApp, reuseRatingCalculator);
        }



        // Setters
        public void setUIApp(Autodesk.Revit.UI.UIApplication uiApp) { this.uiApp = uiApp; }
        public void setMissingInputsHandler(MissingInputsHandler missingInputsHandler) { this.missingInputsHandler = missingInputsHandler; }
        public void setEventsListener(EventsListener eventsListener) { this.eventsListener = eventsListener; }
        public void setSoundManager(SoundManager soundManager) { this.soundManager = soundManager; }
        public void setJsonFilePath(string jsonFilePath) { this.jsonFilePath = jsonFilePath; }

        // Getters
        public Autodesk.Revit.UI.UIApplication getUIApp() { return this.uiApp; }
        public MissingInputsHandler getMissingInputsHandler() { return this.missingInputsHandler; }
        public EventsListener getEventsListener() { return this.eventsListener; }
        public SoundManager getSoundManager() { return this.soundManager; }
        public string getJsonFilePath() { return this.jsonFilePath; }


    }

}
