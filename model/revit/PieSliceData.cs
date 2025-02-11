using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReuseSchemeTool.model.revit
{
    public class PieSliceData
    {
        /* ATTRIBUTES */
        private string name;
        private double value;
        private Color color;
        private double angle;


        /* CONSTRUCTORS */

        // Overloaded 1
        public PieSliceData(string name, double value)
        {
            this.name = name;
            this.value = value;
        }

        // Overloaded 2
        public PieSliceData(string name, double value, Color color) : this(name,value)
        {
            this.color = color;
        }

        // Overloaded 3
        public PieSliceData(string name, double value, Color color, double angle) : this(name, value, color)
        {
            this.angle=angle;
        }


        /* METHODS */

        // Setters
        public void setName(string name) { this.name = name; }
        public void setValue(double value) { this.value = value; }
        public void setColor(Color color) { this.color = color; }
        public void setAngle(double angle) { this.angle=angle; }

        // Getters
        public string getName() { return this.name; }
        public double getValue() { return this.value; }
        public Color getColor() { return this.color; }
        public double getAngle() { return this.angle; }



    }
}
