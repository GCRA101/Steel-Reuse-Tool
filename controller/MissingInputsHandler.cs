using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ReuseSchemeTool.controller
{
    public class MissingInputsHandler : ExceptionHandler
    {
        // CONSTRUCTOR
        public MissingInputsHandler(RST_Controller controller) : base(controller) { }

        //METHODS
        public override void execute(Exception exception = null)
        {
            if (exception!=null)
            {
                this.message = exception.Message;
                MessageBox.Show(this.message,"WARNING - MISSING INPUTS", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

    }
}
