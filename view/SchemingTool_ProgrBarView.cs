using ReuseSchemeTool.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReuseSchemeTool.view
{
    public partial class SchemingTool_ProgrBarView: Form, model.Observer
    {
        //ATTRIBUTES
        private RST_Model model;
        private int progrBarStep;
        private int deltaProgrBar;

        public SchemingTool_ProgrBarView(RST_Model model)
        {
            // This call is required by the designer.
            InitializeComponent();
            // Set up centered position on the screen
            this.StartPosition = FormStartPosition.CenterScreen;
            // Initialize the model. 
            this.model = model;
            // Set up Load event handler
            this.Load += new EventHandler(this.progrBar_Load);
            // Get values range of the progress bar
            this.deltaProgrBar=this.prgbProgress.Maximum - this.prgbProgress.Minimum;
        }
        private void progrBar_Load(object sender, System.EventArgs e)
        {
            // Set up the dialog text at runtime according to the application's assembly information.  
            this.update();
        }

        public void update()
        {
            // UPDATE PROGRESS BAR

            // Get input maximum number of iterations
            int iterNumMax = this.model.getNumSteps();
            // Define value of progress bar step based on max number of iterations
            if (iterNumMax != 0)
            {
                this.progrBarStep = (int)((this.prgbProgress.Maximum - this.prgbProgress.Minimum) / iterNumMax);
            }
            // Increment the progress bar if step has been run
            if (this.model.isSchemingRun() || this.model.isUpdateReuseRatingRun() || this.model.isBuildRevitViewsRun())
            {
                this.prgbProgress.Increment(progrBarStep);
                System.Threading.Thread.Sleep(1000);
                this.prgbProgress.Refresh();
                this.lblProgrPercent.Text = Math.Round(((double)this.prgbProgress.Value / (double)this.prgbProgress.Maximum) * 100.0, 0).ToString() + " %";
                System.Threading.Thread.Sleep(1000);
                this.Refresh();
            }

            // ITERATION COMPLETE MESSAGE
            if (this.model.isSchemingComplete() == true)
            {
                //this.lblProgrBar.Text = "PROCESS COMPLETE!";
                this.prgbProgress.Increment(this.prgbProgress.Maximum - this.prgbProgress.Value);
                System.Threading.Thread.Sleep(1000);
                this.prgbProgress.Refresh();
                this.lblProgrPercent.Text = Math.Round(((double)this.prgbProgress.Value / (double)this.prgbProgress.Maximum) * 100.0, 0).ToString() + " %";
                System.Threading.Thread.Sleep(1000);
                this.Refresh();
                System.Threading.Thread.Sleep(2000);
            }

         
        }

        private void prgbProgress_Click(object sender, EventArgs e)
        {

        }
    }
}
