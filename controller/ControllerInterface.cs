using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReuseSchemeTool.controller
{
    public interface ControllerInterface
    {
        void initialize();
        void createExceptionHandlers();
        void run();
        void serialize();
        void deserialize();
        void terminate();

    }
}
