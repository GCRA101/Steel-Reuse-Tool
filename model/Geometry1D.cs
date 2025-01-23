using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReuseSchemeTool.model
{
    public abstract class Geometry1D : Geometry, GeometryInterface
    {
        /* ATTRIBUTES */
        protected List<Point> points;
        protected Point barycenter;
        protected Double length;

        /* CONSTRUCTORS */
        //Default

        /* METHODS */
        protected void computeBarycenter()
        {
            Double xtot = 0;
            Double ytot = 0;
            Double ztot = 0;

            foreach (Point point in points)
            {
                xtot =xtot + point.x;
                ytot= ytot + point.y;
                ztot = ztot + point.z;
            }

            this.barycenter = new Point(xtot/points.Count, ytot/points.Count, ztot/points.Count);
        }
    }
}
