using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReuseSchemeTool.model
{
    public class Line: Geometry
    {
        //ATTRIBUTES
        private Point startPoint { set; get; }
        private Point endPoint { set; get; }

        //CONSTRUCTORS
        public Line(Point startPoint, Point endPoint)
        {
            this.startPoint=startPoint;
            this.endPoint = endPoint;
        }

        //METHODS
        public void setStartPoint(Point startPoint) { this.startPoint=startPoint; }
        public void setEndPoint(Point endPoint) { this.endPoint=endPoint; }
        public Point getStartPoint() { return this.startPoint; }
        public Point getEndPoint() { return this.endPoint; }


    }
}
