using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReuseSchemeTool.model.data_structures
{
    public class RBNode<T> : IComparable where T : IComparable<T>
    {
        //ATTRIBUTES
        public T key {  get; set; }
        public RBColor color { get; set; }
        public RBNode<T> parent { get; set; }
        public RBNode<T> left { get; set; }
        public RBNode<T> right { get; set; }

        //CONSTRUCTORS
        //Default

        //METHODS

        // .ToString()
        public override string ToString() {
            return this.key.ToString() + "_" + this.color.ToString();
        }

        // .CompareTo()

        /* Method implemented from the IComparable Functional Interface which unique method CompareTo 
           gets called everytime we want to compare an instance of this class with another object.
           The method needs to be implemented accordingly with the criteria we want to use to define
           which object is greater or smaller than the other based on the values assigned to its 
           attributes. */
        public int CompareTo(object o){
            // 1. Check if object is null or has a different data type
            if (o == null || !(o is RBNode<T>)) return 1;
            // 2. Downcast object to T data type
            RBNode<T> rBNode = (RBNode<T>)o;
            // 3. Compare keys
            if (this.key.CompareTo(rBNode.key) != 0) return this.key.CompareTo(rBNode.key);
            // 4. Compare colors
            if (this.color.CompareTo(rBNode.color) != 0) return this.color.CompareTo(rBNode.color);
            // 5. Return 0 (i.e. equality) otherwise...
            return 0;
        }

        // .Equals()

        /* Method inherited from the Object superclass and that gets called everytime we check whether 
           two instances of this class are equal or not. 
           It has to be overwritten based on the values assigned to the attributes of the class instances. */
        public override bool Equals(object o)
        {
            // 1. Check if object is null or has a different data type
            if (o == null || !(o is RBNode<T>)) return false;
            // 2. Downcast object to T data type
            RBNode<T> rBNode = (RBNode<T>)o;
            // 3. Return equality only if both keys and color are equal
            return (this.key.Equals(rBNode.key) && this.color==rBNode.color);
        }

    }
}
