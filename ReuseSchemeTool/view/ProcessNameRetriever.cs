using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace ReuseSchemeTool.view
{
    public static class ProcessNameRetriever
    {

        public static string getName(ProcessName processName)
        {
            switch (processName)
            {
                case (ProcessName.AUTODESK_REVIT):
                    return "Revit";
                case (ProcessName.AUTODESK_ROBOT):
                    return "Robot";
                case (ProcessName.CSI_ETABS):
                    return "ETABS";
                case (ProcessName.CSI_SAP):
                    return "SAP";
                case (ProcessName.OASYS_PDISP):
                    return "PDisp";
                case (ProcessName.RHINO3D):
                    return "Rhino";
                default:
                    return null;
            }
        }

    }
}
