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
            //Instantiate the Model
            this.model = RST_Model.getInstance();
            this.model.uiApp=uiApp;
            //Instantiate the View
            this.view = new RST_View(this.model, this);
            //Instantiate AudioManagers
            this.soundManager=SoundManager.getInstance();
            //Instatiate EventsListener
            this.eventsListener = new EventsListener(this, this.view);
            //Instantiate ExceptionHandlers
            this.createExceptionHandlers();
        }

        public void createExceptionHandlers()
        {
            this.missingInputsHandler=new MissingInputsHandler(this);
        }

        public void deserialize()
        {
            throw new NotImplementedException();
        }

        public void initialize()
        {
            //Show the SplashScreen
            this.view.createSplashScreen();
            //Show the AboutBox
            this.view.createAboutBox();
            //Activate the EventsListener of the AboutBox
            this.eventsListener.initializeAboutBox();
        }

        public void run()
        {
            throw new NotImplementedException();
        }

        public void serialize()
        {
            throw new NotImplementedException();
        }

        public void terminate()
        {
            //Close and dispose the form
            //this.view.getInputsView.close();
            //this.view.getInputsView.dispose();
            
        }



        public SoundManager getSoundManager()
        {
            return soundManager;
        }


    }
}
