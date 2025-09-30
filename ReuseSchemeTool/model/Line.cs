using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ReuseSchemeTool.model
{
    public class Line: Geometry1D
    {
        //ATTRIBUTES
        private Point startPoint { set; get; }
        private Point endPoint { set; get; }

        //CONSTRUCTORS
        public Line(Point startPoint, Point endPoint)
        {
            this.startPoint=startPoint;
            this.endPoint = endPoint;
            this.points= new List<Point>() { startPoint, endPoint };
            this.computeBarycenter();
            this.length = this.computeLength();
        }

        //METHODS

        // Utility

        private Double computeLength()
        {
            return Math.Sqrt(Math.Pow(startPoint.x - endPoint.x, 2) +
                                    Math.Pow(startPoint.y - endPoint.y, 2) +
                                    Math.Pow(startPoint.z - endPoint.z, 2));
        }

        // Setters
        public void setStartPoint(Point startPoint) { this.startPoint=startPoint; }
        public void setEndPoint(Point endPoint) { this.endPoint=endPoint; }
        
        // Getters
        public Point getStartPoint() { return this.startPoint; }
        public Point getEndPoint() { return this.endPoint; }
        public Double getLength() { return this.length; }



        /* HASHCODE */

        // Method inherited from the Object superclass and that has to be overwritten in order to generate
        // ad hoc hashcodes based on the values assigned to the specific attributes of this class.
        // The hashcode is essential to be able to sort and store instances of this class properly 
        // in whatever concrete implementation of the abstract data structure Hash Table.
        public override int GetHashCode()
        {
            return this.points.Sum(point=> point.GetHashCode());
        }


        // COMPARETO

        /* Method implemented from the IComparable Functional Interface which unique method CompareTo 
           gets called everytime we want to compare an instance of this class with another object.
           The method needs to be implemented accordingly with the criteria we want to use to define
           which object is greater or smaller than the other based on the values assigned to its 
           attributes. */
        public override int CompareTo(object o)
        {
            // 1. Check if object is null or has a different data type
            if (o == null || !(o is Line)) return 1;
            // 2. Downcast object to T data type
            Line line = (Line)o;
            // 3. Compare length and barycenter...
            if (this.length.CompareTo(line.length) != 0) return this.length.CompareTo(line.length);
            if (this.barycenter.CompareTo(line.barycenter) != 0) return this.barycenter.CompareTo((Line)o);
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
            if (o == null || !(o is Line)) return false;
            // 2. Downcast object to T data type
            Line line = (Line)o;
            // 3. Return equality only if both start and end points are equal
            return (this.startPoint==line.startPoint && this.endPoint==line.endPoint);
        }

    }
}
