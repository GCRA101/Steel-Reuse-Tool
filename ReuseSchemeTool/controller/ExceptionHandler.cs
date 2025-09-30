using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReuseSchemeTool.controller
{
    public abstract class ExceptionHandler : ExceptionHandlerInterface
    {
        //ATTRIBUTES
        protected RST_Controller controller;
        protected String message;

        //CONSTRUCTOR
        public ExceptionHandler(RST_Controller controller)
        {
            this.controller = controller;
        }

        //METHODS
        public virtual void execute(Exception exception = null)
        {
            throw new NotImplementedException();
        }
    }
}
