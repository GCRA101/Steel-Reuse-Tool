using Autodesk.Revit.DB.Structure;
using ReuseSchemeTool.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ReuseSchemeTool.controller
{
    public class EventsListener
    {
        //ATTRIBUTES
        private RST_Controller controller;
        private RST_View view;

        private System.Windows.Forms.Button aboutBoxBtnOk;

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

        private void aboutBoxBtnOk_Click(System.Object sender, System.EventArgs e) {
            //Play Sound Effect
            this.controller.getSoundManager().play(Sound.CLICKBUTTON);
            //Create the View
            view.createViewInputs();
            //Initialize Components for Events listening
            this.initializeViewInputs();
        }

        public void initializeViewInputs()
        {
           
        }



    }
}
