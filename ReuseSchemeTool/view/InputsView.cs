using Autodesk.Revit.DB;
using ReuseSchemeTool.controller;
using ReuseSchemeTool.model;
using ReuseSchemeTool.model.revit;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace ReuseSchemeTool.view
{
    public partial class InputsView : System.Windows.Forms.Form, Observer
    {

        //ATTRIBUTES
        protected RST_Model model;
        protected RST_Controller controller;
        private int progrBarStep;


        public InputsView(RST_Model model, RST_Controller controller)
        {
            // This call is required by the designer.
            InitializeComponent();
            // Set up centered position on the screen
            this.StartPosition = FormStartPosition.CenterScreen;
            // Initialize model and controller
            this.model = model;
            this.controller = controller;
        }

        public void initialise()
        {
            this.lblMinLengthValue.Text=this.trbMinLength.Value.ToString();
            this.lblMaxLengthValue.Text = this.trbMaxLength.Value.ToString();
            this.lblCutOffValue.Text = Math.Round((this.trbCutOff.Value/10.0),1).ToString();
            this.lblMinWeightValue.Text = this.trbMinWeight.Value.ToString();
            this.lblMaxWeightValue.Text = this.trbMaxWeight.Value.ToString();

        }

        public void initialise(InputSettings inputSettings)
        {

            RevitElementsCollector revitFramesCollector = new RevitElementsCollector(new RevitFramesCollectorStrategy(this.controller.getUIApp().ActiveUIDocument.Document));
            revitFramesCollector = new BHEParameterFilter(revitFramesCollector, AppConfig.PARAM_REUSE_STRATEGY, "EXISTING TO DISMANTLE - TO RECYCLE");
            revitFramesCollector = new PhaseCreatedFilter(revitFramesCollector, AppConfig.PARAM_PHASE);
            
            
            List<string> frameTypeLabels = revitFramesCollector.collectElements()
                .Select(el => ((FamilyInstance)el).Symbol.Family.StructuralFamilyNameKey)
                .Select(famName => famName.Split('-')[0])
                .Where(famLabel=> !String.IsNullOrEmpty(famLabel))
                .ToHashSet().ToList();
            
            frameTypeLabels.Sort();

            frameTypeLabels.ForEach(ftlabel => this.clbSectionTypes.Items.Add(ftlabel));


            for (int i = 0; i < this.clbSectionTypes.Items.Count; i++)
            {
                if (inputSettings.getSteelSectionTypes().Select(enumValue=> enumValue.ToString()).ToList().Contains(this.clbSectionTypes.Items[i].ToString()))
                { this.clbSectionTypes.SetItemChecked(i, true); }
            }


            List<string> materialNames = revitFramesCollector.collectElements()
                .Select(el => el.LookupParameter(AppConfig.PARAM_STRUCTURAL_MATERIAL).AsString())
                .Where(matName => !String.IsNullOrEmpty(matName))
                .Where(matName => matName.ToUpper().Contains("STEEL") || matName.ToUpper().Contains("S235") || matName.ToUpper().Contains("S275") ||
                                  matName.ToUpper().Contains("S355") || matName.ToUpper().Contains("S460"))
                .ToHashSet().ToList();

            materialNames.Sort();

            materialNames.ForEach(matName => this.clbSteelGrades.Items.Add(matName));


            for (int i = 0; i < this.clbSteelGrades.Items.Count; i++)
            {
                this.clbSteelGrades.SetItemChecked(i, true);
            }


            this.trbMinLength.Value = double.IsNaN(inputSettings.getMinLength_m())?
                                        this.trbMinLength.Minimum : (int)inputSettings.getMinLength_m();
            this.lblMinLengthValue.Text = this.trbMinLength.Value.ToString();

            this.trbMaxLength.Value = double.IsNaN(inputSettings.getMaxLength_m())?
                                        this.trbMaxLength.Maximum: (int)inputSettings.getMaxLength_m();
            this.lblMaxLengthValue.Text = this.trbMaxLength.Value.ToString();

            this.trbCutOff.Value = double.IsNaN(inputSettings.getEndCutOffLength_m())?
                                        this.trbMaxLength.Maximum: (int)(inputSettings.getEndCutOffLength_m()* 10.0);
            this.lblCutOffValue.Text = Math.Round((this.trbCutOff.Value / 10.0), 1).ToString();

            this.trbMinWeight.Value = double.IsNaN(inputSettings.getMinWeight_kg_m())?
                                        this.trbMinWeight.Maximum : (int)inputSettings.getMinWeight_kg_m();
            this.lblMinWeightValue.Text = this.trbMinWeight.Value.ToString();

            this.trbMaxWeight.Value = double.IsNaN(inputSettings.getMaxWeight_kg_m())?
                                        this.trbMaxWeight.Maximum : (int)inputSettings.getMaxWeight_kg_m();
            this.lblMaxWeightValue.Text = this.trbMaxWeight.Value.ToString();
        }



        public void update() { }

    }
}
