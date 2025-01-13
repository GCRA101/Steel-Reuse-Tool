using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReuseSchemeTool.model
{
    public class Line
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



    }
}
