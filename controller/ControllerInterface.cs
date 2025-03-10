using ReuseSchemeTool.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReuseSchemeTool.controller
{
    public interface ControllerInterface
    {
        void initialize(Tool tool);
        void createExceptionHandlers();
        void run(Tool tool);
        void serialize();
        void deserialize();
        void terminate(Tool tool);

    }
}
