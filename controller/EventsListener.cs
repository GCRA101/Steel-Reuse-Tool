using Autodesk.Revit.DB.Structure;
using ReuseSchemeTool.model;
using ReuseSchemeTool.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReuseSchemeTool.controller
{
    public class EventsListener
    {
        //ATTRIBUTES
        private RST_Controller controller;
        private RST_View view;

        private Button aboutBoxBtnOk;

        private CheckedListBox clbSectionTypes, clbSteelGrades;
        private TrackBar trbMinLength, trbMaxLength, trbMinWeight, trbMaxWeight;
        private Button btnRun;

        //CONSTRUCTORS
        //Overloaded
        public EventsListener(RST_Controller controller, RST_View view)
        {
            this.controller = controller;
            this.view = view;
        }

        public void initializeAboutBox()
        {
            this.aboutBoxBtnOk = this.view.aboutBox.btnOK;
            aboutBoxBtnOk.Click += new EventHandler(aboutBoxBtnOk_Click);
        }

        public void initializeInputsView()
        {            
            EventHandler clbClickHandler =new EventHandler(inputsViewClb_Click);
            EventHandler trbScrollHandler = new EventHandler(inputsViewTrb_Scroll);
            EventHandler btnRunClickHandler = new EventHandler(inputsViewBtnRun_Click);

            this.clbSectionTypes = this.view.inputsView.clbSectionTypes;
            clbSectionTypes.Click += clbClickHandler;
            this.clbSteelGrades = this.view.inputsView.clbSteelGrades;
            clbSteelGrades.Click += clbClickHandler;
            this.trbMinLength = this.view.inputsView.trbMinLength;
            trbMinLength.Scroll += trbScrollHandler;
            this.trbMaxLength = this.view.inputsView.trbMaxLength;
            trbMaxLength.Scroll += trbScrollHandler;
            this.trbMinWeight = this.view.inputsView.trbMinWeight;
            trbMinWeight.Scroll += trbScrollHandler;
            this.trbMaxWeight = this.view.inputsView.trbMaxWeight;
            trbMaxWeight.Scroll += trbScrollHandler;

            this.btnRun = this.view.inputsView.btnRun;
            btnRun.Click += btnRunClickHandler;
        }


        private void aboutBoxBtnOk_Click(System.Object sender, System.EventArgs e) {
            //Play Sound Effect
            this.controller.soundManager.play(Sound.CLICKBUTTON);
            //Create the View
            view.createInputsView();
            //Initialize Components for Events listening
            this.initializeInputsView();
        }

        private void inputsViewClb_Click(System.Object sender, System.EventArgs e)
        {
            //Play Sound Effect
            this.controller.soundManager.play(Sound.CHECKBOX);
        }

        private void inputsViewTrb_Scroll(System.Object sender, System.EventArgs e)
        {
            //Play Sound Effect
            //this.controller.getSoundManager().play(Sound.CLICKBUTTON);


            if (sender== trbMinLength) {this.view.inputsView.lblMinLengthValue.Text = trbMinLength.Value.ToString();}
            if (sender == trbMaxLength) { this.view.inputsView.lblMaxLengthValue.Text = trbMaxLength.Value.ToString(); }
            if (sender == trbMinWeight) { this.view.inputsView.lblMinWeightValue.Text = trbMinWeight.Value.ToString(); }
            if (sender == trbMaxWeight) { this.view.inputsView.lblMaxWeightValue.Text = trbMaxWeight.Value.ToString(); }
        }

        private void inputsViewBtnRun_Click(System.Object sender, System.EventArgs e)
        {
            //Play Sound Effect
            this.controller.soundManager.play(Sound.CLICKBUTTON);

            //Launch the process while catching exceptions
            try
            {
                this.controller.processInputData();
                this.controller.run();
                this.controller.terminate();
            }
            catch (MissingInputsException ex1) 
            {
                this.controller.missingInputsHandler.execute(ex1); 
            }
            
        }



    }
}
