using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReuseSchemeTool.model.revit
{
    public class PieSliceData: ChartData
    {
        /* ATTRIBUTES */
        private double angle;
        private double percentage;


        /* CONSTRUCTORS */

        // Overloaded 1
        public PieSliceData(string name, double value): base(name, value){ }

        // Overloaded 2
        public PieSliceData(string name, double value, Color color) : base(name,value,color) { }

        // Overloaded 3
        public PieSliceData(string name, double value, Color color, double angle) : this(name, value, color)
        {
            this.angle=angle;
        }


        /* METHODS */

        // Setters
        public void setAngle(double angle) { this.angle=angle; }
        public void setPercentage(double percentage) { this.percentage = percentage; }

        // Getters
        public double getAngle() { return this.angle; }
        public double getPercentage() { return this.percentage; }



    }
}
