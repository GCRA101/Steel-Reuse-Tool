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
    public partial class AboutBox : Form, Observer
    {
        //ATTRIBUTES
        private RST_Model model;

        public AboutBox(RST_Model model)
        {
            this.model = model;
            InitializeComponent();
        }

        public void update()
        {
            throw new NotImplementedException();
        }
    }
}
