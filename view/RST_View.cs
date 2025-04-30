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
        private System.Windows.Forms.Form splashScreen;
        private System.Windows.Forms.Form aboutBox;
        private System.Windows.Forms.Form progressBarView;
        private InspectorTool_InputsView inputsView;

        //CONSTRUCTORS
        public RST_View(RST_Model model, RST_Controller controller)
        {
            this.model = model;
            this.controller = controller;
        }


	    //METHODS

	    //CREATION of the VIEWS
        public void createSplashScreen(Tool tool)
        {
            switch (tool)
            {
                case Tool.INSPECTOR:
                    this.splashScreen = new InspectorTool_SplashScreen(this.model);
                    break;
                case Tool.SCHEME:
                    this.splashScreen = new SchemingTool_SplashScreen(this.model);
                    break;
            }

            this.controller.getSoundManager().play(Sound.SPLASHSCREEN);
            this.model.registerObserver((Observer)this.splashScreen);
            System.Threading.Thread.Sleep(1000);
            this.splashScreen.Show();
            this.splashScreen.Refresh();
            System.Threading.Thread.Sleep(5000);
            this.model.removeObserver((Observer)this.splashScreen);
            this.splashScreen.Close();


        }
        
        public void createAboutBox(Tool tool)
        {
            switch (tool)
            {
                case Tool.INSPECTOR:
                    this.aboutBox = new InspectorTool_AboutBox(this.model);
                    break;
                case Tool.SCHEME:
                    this.aboutBox = new SchemingTool_AboutBox(this.model);
                    break;
            }

            this.model.registerObserver((Observer)this.aboutBox);
            this.model.notifyObservers();
        }

        public void createInputsView()
        {
            this.inputsView = new InspectorTool_InputsView(this.model, this.controller);
            this.inputsView.initialise(EMRInputSettings.getInstance());

            this.model.removeObserver((Observer)this.aboutBox);
            this.model.registerObserver(this.inputsView);

            this.aboutBox.Close();
        }

        public void createProgressBarView(Tool tool)
        {
            switch (tool)
            {
                case Tool.INSPECTOR:
                    this.progressBarView = new InspectorTool_ProgrBarView(this.model);
                    break;
                case Tool.SCHEME:
                    this.progressBarView = new SchemingTool_ProgrBarView(this.model);
                    break;
            }

            this.model.registerObserver((Observer)this.progressBarView);
            this.model.notifyObservers();

            this.progressBarView.TopMost = true;
            this.progressBarView.Show();
            this.progressBarView.Refresh();

            System.Threading.Thread.Sleep(500);
        }


        // Getters
        public System.Windows.Forms.Form getSplashScreen() { return this.splashScreen; }
        public System.Windows.Forms.Form getAboutBox() { return this.aboutBox; }
        public System.Windows.Forms.Form getProgressBarView() { return this.progressBarView; }
        
        public InspectorTool_InputsView getInputsView() { return this.inputsView; }

    }
}
