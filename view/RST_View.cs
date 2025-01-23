using Autodesk.Revit.DB.Structure;
using Autodesk.Revit.DB;
using Autodesk.Revit.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ReuseSchemeTool.model;
using ReuseSchemeTool.controller;
using System.Media;

namespace ReuseSchemeTool.view
{
    public class RST_View
    {

        //ATTRIBUTES

        //References to Model and Controller
        public RST_Model model { set; get; }
        public RST_Controller controller { set; get; }
        //Main windows of the View
        public SplashScreen splashScreen { set; get; }
        public AboutBox aboutBox { set; get; }
        public InputsView inputsView { set; get; }

        //CONSTRUCTORS
        public RST_View(RST_Model model, RST_Controller controller)
        {
            this.model = model;
            this.controller = controller;
        }


	    //METHODS

	    //CREATION of the VIEWS
        public void createSplashScreen()
        {
            this.splashScreen = new SplashScreen(this.model);
            this.controller.soundManager.play(Sound.SPLASHSCREEN);
            this.model.registerObserver(this.splashScreen);
            System.Threading.Thread.Sleep(1000);
            this.splashScreen.Show();
            this.splashScreen.Refresh();
            System.Threading.Thread.Sleep(5000);
            this.model.removeObserver(this.splashScreen);
            this.splashScreen.Close();
        }
        
        public void createAboutBox()
        {
            this.aboutBox = new AboutBox(this.model);
            this.model.registerObserver(this.aboutBox);
            this.model.notifyObservers();
            this.aboutBox.Show();
            this.aboutBox.Refresh();
        }

        public void createInputsView()
        {
            this.inputsView = new InputsView(this.model, this.controller);
            this.inputsView.initialise();

            this.model.removeObserver(this.aboutBox);
            this.model.registerObserver(this.inputsView);

            this.inputsView.Show();
            this.aboutBox.Close();
        }
    }
}
