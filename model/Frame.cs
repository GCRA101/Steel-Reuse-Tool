using Autodesk.Revit.DB;
using ReuseSchemeTool.model.data_structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReuseSchemeTool.model
{
    public class Frame: IComparable
    {
        //ATTRIBUTES
        protected Section section;
        protected String material;
        protected Double length;
        protected String uniqueId;
        protected Line geometry;

        //CONSTRUCTORS
        //Default
        public Frame() { }
        //Overloaded
        public Frame(Section section, string material, double length, string uniqueId, Line geometry)
        {
            this.section = section;
            this.material = material;
            this.length = length;
            this.uniqueId = uniqueId;
            this.geometry = geometry;
        }

        //METHODS

        //Setters
        public void setSection(Section section) { this.section = section; }
        public void setMaterial(String material) { this.material = material; }
        public void setLength(Double length) { this.length = length; }
        public void setUniqueId(String uniqueId) { this.uniqueId = uniqueId; }
        public void setGeometry(Line geometry) { this.geometry = geometry; }

        //Getters
        public Section getSection() { return section; }
        public String getMaterial() { return material; }
        public double getLength() { return length; }
        public String getUniqueId() { return uniqueId; }
        public Line getGeometry() { return geometry; }


        // .ToString()
        public override string ToString()
        {
            return "{"+this.uniqueId+"_"+ this.section.ToString() + "_" + this.material+"}";
        }


        /* HASHCODE */

        // Method inherited from the Object superclass and that has to be overwritten in order to generate
        // ad hoc hashcodes based on the values assigned to the specific attributes of this class.
        // The hashcode is essential to be able to sort and store instances of this class properly 
        // in whatever concrete implementation of the abstract data structure Hash Table.
        public override int GetHashCode()
        {
            return this.section.GetHashCode() + this.geometry.GetHashCode();
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
            if (o == null || !(o is Frame)) return 1;
            // 2. Downcast object to T data type
            Frame frame = (Frame)o;
            // 3. Compare section
            if (this.section.CompareTo(frame.section)!=0) return this.section.CompareTo(frame.section);
            // 4. Compare Geometry
            if (this.length.CompareTo(frame.length)!=0) return frame.length.CompareTo(frame.length);
            // 5. Return 0 (i.e. equality) otherwise...
            return 0;
        }

        // EQUALS

        /* Method inherited from the Object superclass and that gets called everytime we check whether 
           two instances of this class are equal or not. 
           It has to be overwritten based on the values assigned to the attributes of the class instances. */
        public override bool Equals(object o)
        {
            // 1. Check if object is null or has a different data type
            if (o == null || !(o is Frame)) return false;
            // 2. Downcast object to T data type
            Frame frame = (Frame)o;
            // 3. Return equality only if section, id and geometry are identical
            return (this.section.Equals(frame.section) && this.geometry.Equals(frame.geometry) &&
                    this.geometry.Equals(frame.uniqueId));
        }

    }
}
