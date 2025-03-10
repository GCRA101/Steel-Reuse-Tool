using ReuseSchemeTool.controller;
using ReuseSchemeTool.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReuseSchemeTool.view
{
    public partial class SchemingTool_AboutBox : Form, model.Observer
    {
        //ATTRIBUTES
        private RST_Model model;

        public SchemingTool_AboutBox(RST_Model model)
        {
            // This call is required by the designer.
            InitializeComponent();
            // Set up centered position on the screen
            this.StartPosition = FormStartPosition.CenterScreen;
            // Initialize the model. 
            this.model = model;
            // Set up Load event handler
            this.Load += new EventHandler(aboutBox_Load);
        }

        private void aboutBox_Load(object sender, System.EventArgs e)
        {
            // Set up the dialog text at runtime according to the application's assembly information.  
            this.update();
        }

        public void update()
        {
            //Application Name
            this.lblProductName.Text = this.model.getModelName(Tool.SCHEME);
            //Application Version
            this.lblVersion.Text = this.model.getModelVersion();
            //Copyright info
            this.lblCopyright.Text = this.model.getModelCopyRight();
            //Company Name info
            this.lblCompanyName.Text = this.model.getModelOwner();
            //Description
            this.txtDescription.Text = ControllerFileManager.getDocText(Document.APP_DESCRIPTION);
        }

    }
}
