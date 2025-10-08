using Autodesk.Revit.DB;
using ReuseSchemeTool.model.data_structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReuseSchemeTool.model
{
    public static class AppConfig
    {
        public const string PARAM_REUSE_STRATEGY = "BHE_Reuse Strategy";
        public const string PARAM_STRUCTURAL_MATERIAL = "BHE_Material";
        public const string PARAM_PHASE = "Existing";
        public const string PARAM_REUSE_RATING = "BHE_Filter Comments 01";
        public const string TITLEBLOCK_FAMILY_NAME = "BHE_TitleBlocks_A0-A1-A2_RST";
        public const string TITLEBLOCK_TYPE_NAME = "BHE_A1";
    }

}
