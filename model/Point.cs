using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReuseSchemeTool.model
{
    public class Point : Geometry
    {
        //ATTRIBUTES
        private double x, y, z;

        //CONSTRUCTORS
        public Point(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        //METHODS
        public void setCoordinates(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public List<double> getCoordinates()
        {
            return new List<double>() {this.x, this.y, this.z};
        }


    }
}
