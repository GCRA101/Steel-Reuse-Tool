using ReuseSchemeTool.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace ReuseSchemeTool.view
{
    public partial class InspectorTool_SplashScreen : System.Windows.Forms.Form, model.Observer
    {
        // ATTRIBUTES
        private RST_Model model;

        // CONSTRUCTOR
        public InspectorTool_SplashScreen(RST_Model model)
        {
            // This call is required by the designer.
            InitializeComponent();
            // Set up centered position on the screen
            this.StartPosition = FormStartPosition.CenterScreen;
            // Initialize the model.  
            this.model= model;
            // Set up Load event handler
            this.Load += new EventHandler(splashScreen_Load);
        }

        private void splashScreen_Load(object sender,System.EventArgs e) 
        {
            // Set up the dialog text at runtime according to the application's assembly information.  
            this.update();
        }

        public void update()
        {
            //Application Name
            this.lblApplicationName.Text = this.model.getModelName(Tool.INSPECTOR);
            //Application Version
            this.lblVersion.Text = this.model.getModelVersion();
            //Copyright info
            this.lblCopyright.Text = this.model.getModelCopyRight();
        }
    }
}
