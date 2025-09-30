using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReuseSchemeTool.model
{
    public interface RevitConverterInterface
    {
        bool checkObjType();
        Geometry getGeometry();
        string getUniqueId();
    }
}
