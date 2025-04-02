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
                    this.aboutBoxBtnOk = ((InspectorTool_AboutBox)this.view.getAboutBox()).btnOK;
                    break;
                case (Tool.SCHEME):
                    this.aboutBoxBtnOk = ((SchemingTool_AboutBox)this.view.getAboutBox()).btnOK;
                    break;
            }
            
            //aboutBoxBtnOk.Click += new EventHandler(aboutBoxBtnOk_Click);
        }

        public void initializeInputsView()
        {            
            EventHandler clbClickHandler =new EventHandler(inputsViewClb_Click);
            EventHandler trbScrollHandler = new EventHandler(inputsViewTrb_Scroll);

            this.clbSectionTypes = this.view.getInputsView().clbSectionTypes;
            clbSectionTypes.Click += clbClickHandler;
            this.clbSteelGrades = this.view.getInputsView().clbSteelGrades;
            clbSteelGrades.Click += clbClickHandler;
            this.trbMinLength = this.view.getInputsView().trbMinLength;
            trbMinLength.Scroll += trbScrollHandler;
            this.trbMaxLength = this.view.getInputsView().trbMaxLength;
            trbMaxLength.Scroll += trbScrollHandler;
            this.trbCutOff = this.view.getInputsView().trbCutOff;
            trbCutOff.Scroll += trbScrollHandler;
            this.trbMinWeight = this.view.getInputsView().trbMinWeight;
            trbMinWeight.Scroll += trbScrollHandler;
            this.trbMaxWeight = this.view.getInputsView().trbMaxWeight;
            trbMaxWeight.Scroll += trbScrollHandler;

            this.btnRun = this.view.getInputsView().btnRun;
        }


        private void aboutBoxBtnOk_Click(System.Object sender, System.EventArgs e) {
            //Play Sound Effect
            this.controller.getSoundManager().play(Sound.CLICKBUTTON);
            //Create the View
            view.createInputsView();
            //Initialize Components for Events listening
            this.initializeInputsView();
        }

        private void inputsViewClb_Click(System.Object sender, System.EventArgs e)
        {
            //Play Sound Effect
            this.controller.getSoundManager().play(Sound.CHECKBOX);
        }

        private void inputsViewTrb_Scroll(System.Object sender, System.EventArgs e)
        {
            //Play Sound Effect
            //this.controller.getSoundManager().play(Sound.CLICKBUTTON);
            if (sender== trbMinLength) {this.view.getInputsView().lblMinLengthValue.Text = trbMinLength.Value.ToString();}
            if (sender == trbMaxLength) { this.view.getInputsView().lblMaxLengthValue.Text = trbMaxLength.Value.ToString(); }
            if (sender == trbCutOff) { this.view.getInputsView().lblCutOffValue.Text = Math.Round((trbCutOff.Value/10.0),1).ToString(); }
            if (sender == trbMinWeight) { this.view.getInputsView().lblMinWeightValue.Text = trbMinWeight.Value.ToString(); }
            if (sender == trbMaxWeight) { this.view.getInputsView().lblMaxWeightValue.Text = trbMaxWeight.Value.ToString(); }
        }

    }
}
