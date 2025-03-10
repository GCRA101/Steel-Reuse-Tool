using ReuseSchemeTool.model;
using ReuseSchemeTool.view;
using System;
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
        public Autodesk.Revit.UI.UIApplication uiApp { get; set; }
        // ExceptionHandlers
        public MissingInputsHandler missingInputsHandler { get; set; }
        // EventListeners
        public EventsListener eventsListener { get; set; }
        // AudioManagers
        public SoundManager soundManager { get; set; }
        // Other Variables
        public string jsonFilePath { get; set; }



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
            this.eventsListener.initializeAboutBox();
        }

        public void run(Tool tool)
        {
            switch (tool)
            {
                case Tool.INSPECTOR:
                    this.model.runScheming();
                    break;
                case Tool.SCHEME:
                    this.model.runScheming();
                    break;
            }
            
        }

        public void serialize()
        {
            throw new NotImplementedException();
        }

        public void terminate(Tool tool)
        {
            //Close and dispose the form
            this.view.inputsView.Close();
            this.view.inputsView.Dispose();

        }


        public void processInputData()
        {
            // 1. Get the Input Data from the UI

            // SECTION TYPES
            //Get the list of section types selected by the user in the UI by the help of an Enumerator
            List<string> selSectionTypes = new List<string>();
            IEnumerator<string> enumerator = this.view.inputsView.clbSectionTypes.CheckedItems.Cast<String>().GetEnumerator();
            while (enumerator.MoveNext()) { selSectionTypes.Add(enumerator.Current); }

            // STEEL GRADES
            //Get the list of steel grades selected by the user in the UI by the help of an Enumerator
            List<string> selSteelGrades = new List<string>();
            enumerator = this.view.inputsView.clbSteelGrades.CheckedItems.Cast<String>().GetEnumerator();
            while (enumerator.MoveNext()) { selSteelGrades.Add(enumerator.Current); }

            // MAX/MIN LENGHTS
            Single[] lengthsRange = {
                Single.Parse(this.view.inputsView.lblMinLengthValue.Text),
                Single.Parse(this.view.inputsView.lblMaxLengthValue.Text)
            };

            // END CUT-OFF LENGTH
            Single endCutOffLength = Single.Parse(this.view.inputsView.lblCutOffValue.Text);

            // MAX/MIN WEIGHTS
            Single[] weightsRange = {
                Single.Parse(this.view.inputsView.lblMinWeightValue.Text),
                Single.Parse(this.view.inputsView.lblMaxWeightValue.Text)
            };

            UserDefined_RatingStrategy udRatingStrategy = 
                new UserDefined_RatingStrategy(selSectionTypes, selSteelGrades, lengthsRange, weightsRange, endCutOffLength);

            ReuseRatingCalculator reuseRatingCalculator = new ReuseRatingCalculator(udRatingStrategy);

            this.model.initialize(this.uiApp, reuseRatingCalculator);
        }

    }

}
