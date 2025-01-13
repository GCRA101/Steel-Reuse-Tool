using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReuseSchemeTool.controller
{
    public interface ExceptionHandlerInterface
    {
        void execute(Exception exception = null);
    }
}
