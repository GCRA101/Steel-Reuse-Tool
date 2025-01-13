using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReuseSchemeTool.model
{
    public class Frame
    {
        //ATTRIBUTES
        protected String sectionSize;
        protected String material;
        protected Double length;
        protected String uniqueId;
        protected Line geometry;

        //CONSTRUCTORS
        //Default
        public Frame() { }
        //Overloaded
        public Frame(string sectionSize, string material, double length, string uniqueId, Line geometry)
        {
            this.sectionSize = sectionSize;
            this.material = material;
            this.length = length;
            this.uniqueId = uniqueId;
            this.geometry = geometry;
        }

        //METHODS




    }
}
