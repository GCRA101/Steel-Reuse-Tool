using Autodesk.Revit.DB.Structure;
using Autodesk.Revit.UI;
using ReuseSchemeTool.model;
using ReuseSchemeTool.view;
using ReuseSchemeTool.view.revit_plugin;
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
        private TrackBar trbMinLength, trbMaxLength, trbCutOff, trbMinWeight, trbMaxWeight;
        private Button btnRun;

        //CONSTRUCTORS
        //Overloaded
        public EventsListener(RST_Controller controller, RST_View view)
        {
            this.controller = controller;
            this.view = view;
        }

        public void initializeAboutBox(Tool tool)
        {
            switch (tool)
            {
                case (Tool.INSPECTOR):
                    this.aboutBoxBtnOk = ((InspectorTool_AboutBox)this.view.aboutBox).btnOK;
                    break;
                case (Tool.SCHEME):
                    this.aboutBoxBtnOk = ((SchemingTool_AboutBox)this.view.aboutBox).btnOK;
                    break;
            }
            
            //aboutBoxBtnOk.Click += new EventHandler(aboutBoxBtnOk_Click);
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
            this.trbCutOff = this.view.inputsView.trbCutOff;
            trbCutOff.Scroll += trbScrollHandler;
            this.trbMinWeight = this.view.inputsView.trbMinWeight;
            trbMinWeight.Scroll += trbScrollHandler;
            this.trbMaxWeight = this.view.inputsView.trbMaxWeight;
            trbMaxWeight.Scroll += trbScrollHandler;

            this.btnRun = this.view.inputsView.btnRun;
            //btnRun.Click += btnRunClickHandler;
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
            if (sender == trbCutOff) { this.view.inputsView.lblCutOffValue.Text = Math.Round((trbCutOff.Value/10.0),1).ToString(); }
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
                this.controller.run(Tool.SCHEME);
                this.controller.terminate(Tool.SCHEME);
            }
            catch (MissingInputsException ex1) 
            {
                this.controller.missingInputsHandler.execute(ex1); 
            }
            
        }

    }
}
