using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReuseSchemeTool.controller
{
    public interface AudioManagerInterface
    {
        void play(string filePath);
        Boolean isActive();
        void setActive(Boolean active);


    }
}
