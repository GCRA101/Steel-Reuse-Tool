using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReuseSchemeTool.model.revit
{
    public class ChartData
    {
        /* ATTRIBUTES */
        protected string name;
        protected double value;
        protected Autodesk.Revit.DB.Color color;


        /* CONSTRUCTORS */

        // Overloaded 1
        public ChartData(string name, double value)
        {
            this.name = name;
            this.value = value;
        }

        // Overloaded 2
        public ChartData(string name, double value, Autodesk.Revit.DB.Color color) : this(name, value)
        {
            this.color = color;
        }


        /* METHODS */

        // Setters
        public void setName(string name) { this.name = name; }
        public void setValue(double value) { this.value = value; }
        public void setColor(Autodesk.Revit.DB.Color color) { this.color = color; }

        // Getters
        public string getName() { return this.name; }
        public double getValue() { return this.value; }
        public Autodesk.Revit.DB.Color getColor() { return this.color; }

    }
}
