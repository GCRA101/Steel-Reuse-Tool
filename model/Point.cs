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
        public double x, y, z;

        //CONSTRUCTORS
        public Point(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        // METHODS

        // Setters
        public void setCoordinates(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        // Getters
        public List<double> getCoordinates()
        {
            return new List<double>() {this.x, this.y, this.z};
        }


        /* HASHCODE */

        // Method inherited from the Object superclass and that has to be overwritten in order to generate
        // ad hoc hashcodes based on the values assigned to the specific attributes of this class.
        // The hashcode is essential to be able to sort and store instances of this class properly 
        // in whatever concrete implementation of the abstract data structure Hash Table.
        public override int GetHashCode()
        {
            return (int)(this.x + this.y +this.z);
        }


        // COMPARETO

        /* Method implemented from the IComparable Functional Interface which unique method CompareTo 
           gets called everytime we want to compare an instance of this class with another object.
           The method needs to be implemented accordingly with the criteria we want to use to define
           which object is greater or smaller than the other based on the values assigned to its 
           attributes. */
        public int CompareTo(object o)
        {
            // 1. Check if object is null or has a different data type
            if (o == null || !(o is Point)) return 1;
            // 2. Downcast object to T data type
            Point point = (Point)o;
            // 3. Compare coordinates
            if (this.z.CompareTo(point.z)!=0) return this.z.CompareTo(point.z);
            if (this.x.CompareTo(point.x) != 0) return this.x.CompareTo(point.x);
            if (this.y.CompareTo(point.y) != 0) return this.y.CompareTo(point.y);
            // 4. Return 0 (i.e. equality) otherwise...
            return 0;
        }

        // EQUALS

        /* Method inherited from the Object superclass and that gets called everytime we check whether 
           two instances of this class are equal or not. 
           It has to be overwritten based on the values assigned to the attributes of the class instances. */
        public override bool Equals(object o)
        {
            // 1. Check if object is null or has a different data type
            if (o == null || !(o is Point)) return false;
            // 2. Downcast object to T data type
            Point point = (Point)o;
            // 3. Return equality only if section, id and geometry are identical
            return (this.x==point.x && this.y==point.y && this.z==point.z);
        }



    }
}
