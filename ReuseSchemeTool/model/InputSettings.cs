using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReuseSchemeTool.model
{
    public abstract class InputSettings
    {
        protected List<SteelSectionType> steelSectionTypes;
        protected double minLength_m, maxLength_m;
        protected double endCutOffLength_m;
        protected double minWeight_kg_m, maxWeight_kg_m;

        protected InputSettings() { }

        protected InputSettings(List<SteelSectionType> steelSectionTypes, double minLength_m, double maxLength_m, 
                                double endCutOffLength_m, double minWeight_kg_m, double maxWeight_kg_m)
        {
            this.steelSectionTypes = steelSectionTypes;
            this.minLength_m = minLength_m;
            this.maxLength_m = maxLength_m;
            this.endCutOffLength_m = endCutOffLength_m;
            this.minWeight_kg_m = minWeight_kg_m;
            this.maxWeight_kg_m = maxWeight_kg_m;
        }

        public List<SteelSectionType> getSteelSectionTypes() { return steelSectionTypes; }
        public double getMinLength_m() { return minLength_m; }
        public double getMaxLength_m() { return maxLength_m; }
        public double getEndCutOffLength_m() { return endCutOffLength_m; }
        public double getMinWeight_kg_m() { return minWeight_kg_m; }
        public double getMaxWeight_kg_m() { return maxWeight_kg_m; }

    }
}
