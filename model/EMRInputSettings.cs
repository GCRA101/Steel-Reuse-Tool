using Autodesk.Revit.DB;
using ReuseSchemeTool.view.revit_plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReuseSchemeTool.model
{
    public class EMRInputSettings: InputSettings
    {

        private static EMRInputSettings instance;


        private EMRInputSettings(List<SteelSectionType> steelSectionTypes, double minLength_m, double maxLength_m,
                        double endCutOffLength_m, double minWeight_kg_m, double maxWeight_kg_m) :
                            base(steelSectionTypes, minLength_m, maxLength_m, endCutOffLength_m, minWeight_kg_m, maxWeight_kg_m) { }

        public static EMRInputSettings getInstance()
        {
            if (instance == null) {
                instance = new EMRInputSettings(new List<SteelSectionType> {SteelSectionType.UB, SteelSectionType.UC},
                                                4, double.NaN, 0.3,50,double.NaN);}
            return instance;
        }

    }
}

