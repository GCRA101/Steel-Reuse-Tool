using ReuseSchemeTool.model.data_structures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReuseSchemeTool.model
{
    public class Section: IComparable
    {
        /* ATTRIBUTES */
        private String size;
        private Single area_mm2;
        private Single weight_kg_m;

        
        /* CONSTRUCTORS */
        public Section(String size, Single area_mm2, Single weight_kg_m)
        {
            this.size = size;
            this.area_mm2=area_mm2;
            this.weight_kg_m = weight_kg_m;
        }


        /* METHODS */

        // Setters
        public void setSize(String size) { this.size = size; }
        public void setArea(Single area_mm2) { this.area_mm2= area_mm2; }
        public void setWeight(Single weight_kg_m) { this.weight_kg_m= weight_kg_m; }

        // Getters
        public String getSize() { return size; }
        public Single getArea() {  return area_mm2; }
        public Single getWeight() { return weight_kg_m; }


        // .ToString()
        public override string ToString()
        {
            return this.size;
        }

        /* HASHCODE */

        // Method inherited from the Object superclass and that has to be overwritten in order to generate
        // ad hoc hashcodes based on the values assigned to the specific attributes of this class.
        // The hashcode is essential to be able to sort and store instances of this class properly 
        // in whatever concrete implementation of the abstract data structure Hash Table.
        public override int GetHashCode()
        {
            return this.size.GetHashCode() + (int)this.area_mm2;
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
            if (o == null || !(o is Section)) return 1;
            // 2. Downcast object to T data type
            Section section = (Section)o;
            // 3. Compare weight
            if (this.weight_kg_m<section.weight_kg_m) return -1;
            else if (this.weight_kg_m > section.weight_kg_m) return 1;
            // 4. Compare area
            else if (this.area_mm2 < section.area_mm2) return -1;
            else if (this.area_mm2 > section.area_mm2) return 1;
            // 5. Compare size
            return this.size.CompareTo(section.size);

        }

        // EQUALS

        /* Method inherited from the Object superclass and that gets called everytime we check whether 
           two instances of this class are equal or not. 
           It has to be overwritten based on the values assigned to the attributes of the class instances. */
        public override bool Equals(object o)
        {
            // 1. Check if object is null or has a different data type
            if (o == null || !(o is Section)) return false;
            // 2. Downcast object to T data type
            Section section = (Section)o;
            // 3. Return equality only if both keys and color are equal
            return this.size == section.size && 
                this.area_mm2 == section.area_mm2 && 
                this.weight_kg_m == section.weight_kg_m;
        }




    }
}
