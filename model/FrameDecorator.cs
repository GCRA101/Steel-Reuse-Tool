using Autodesk.Revit.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReuseSchemeTool.model
{
    public class FrameDecorator : FrameInterface, IComparable
    {
        /* ATTRIBUTES */
        protected Frame frame;

        /* CONSTRUCTOR */
        // Default
        public FrameDecorator() { }
        // Overloaded
        public FrameDecorator(Frame frame)
        {
            this.frame = frame;
        }

        /* METHODS */

        // Setters
        public void setGeometry(Line geometry) { this.frame.setGeometry(geometry); }
        public void setLength(double length) { this.frame.setLength(length); }
        public void setMaterial(string material) { this.frame.setMaterial(material); }
        public void setSection(Section section) { this.frame.setSection(section); }
        public void setUniqueId(string uniqueId) { this.frame.setUniqueId(uniqueId); }

        // Getters
        public Line getGeometry() {return frame.getGeometry();}
        public double getLength(){ return frame.getLength(); }
        public string getMaterial(){ return frame.getMaterial();}
        public Section getSection(){ return frame.getSection();}
        public string getUniqueId(){ return frame.getUniqueId();}
        public Frame getFrame(){ return frame; }

    }
}
