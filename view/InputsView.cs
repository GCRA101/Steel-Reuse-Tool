using ReuseSchemeTool.controller;
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
    public partial class InputsView : Form, Observer
    {

        //ATTRIBUTES
        protected RST_Model model;
        protected RST_Controller controller;


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

        public void update()
        {
            throw new NotImplementedException();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void lblProgrBar_Click(object sender, EventArgs e)
        {

        }

        private void btnRunIteration_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
