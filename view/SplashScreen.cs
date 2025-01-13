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

namespace ReuseSchemeTool.view
{
    public partial class SplashScreen : Form, model.Observer
    {
        // ATTRIBUTES
        RST_Model model;

        // CONSTRUCTOR
        public SplashScreen(RST_Model model)
        {
            this.model= model;
            InitializeComponent();
        }

        public void update()
        {
            throw new NotImplementedException();
        }
    }
}
