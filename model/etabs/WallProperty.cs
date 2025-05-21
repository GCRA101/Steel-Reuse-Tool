using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using ETABS_Base_Reactions_Exchange.model;

public class WallProperty : AreaObjProperty
{

    // ATTRIBUTES
    private ETABSv1.eWallPropType wallPropType;
    private ETABSv1.eShellType shellType;
    private string matProp;
    private double thickness;


    // CONSTRUCTORS

    // Default
    public WallProperty() : base()
    {
    }
    // Overloaded1
    public WallProperty(string name) : base(name)
    {
    }
    // Overloaded2
    public WallProperty(string name, ETABSv1.eWallPropType wallPropType, ETABSv1.eShellType shellType, string matProp, double thickness) : base(name)
    {
        {
            var withBlock = this;
            withBlock.wallPropType = wallPropType;
            withBlock.shellType = shellType;
            withBlock.matProp = matProp;
            withBlock.thickness = thickness;
        }
    }


    // METHODS

    // Setters
    public void setWallPropType(ETABSv1.eWallPropType wallPropType)
    {
        this.wallPropType = wallPropType;
    }
    public void setShellType(ETABSv1.eShellType shellType)
    {
        this.shellType = shellType;
    }
    public void setMatProp(string matProp)
    {
        this.matProp = matProp;
    }
    public void setThickness(double thickness)
    {
        this.thickness = thickness;
    }

    // Getters
    public ETABSv1.eWallPropType getWallPropType()
    {
        return this.wallPropType;
    }
    public ETABSv1.eShellType getShellType()
    {
        return this.shellType;
    }
    public string getMatProp()
    {
        return this.matProp;
    }
    public double getThickness()
    {
        return this.thickness;
    }


    // HASHCODE

    // Method inherited from the Object superclass and that has to be overwritten in order to generate
    // ad hoc hashcodes based on the values assigned to the specific attributes of this class.
    // The hashcode is essential to be able to sort and store instances of this class properly 
    // in whatever concrete implementation of the abstract data structure Hash Table.
    public override int GetHashCode()
    {
        // Determines and returns the Hashcode of the class instance as the number given by the sum 
        // of the hashcodes of a number of its attributes
        int hash;
        hash = this.name.GetHashCode() + this.wallPropType.GetHashCode() + System.Convert.ToInt32(this.thickness);
        return hash;
    }


    // COMPARETO

    // Method implemented from the IComparable Functional Interface which unique method CompareTo 
    // gets called everytime we want to compare an instance of this class with another object.
    // The method needs to be implemented accordingly with the criteria we want to use to define
    // which object is greater or smaller than the other based on the values assigned to its 
    // attributes.
    public override int CompareTo(object obj)
    {
        throw new NotImplementedException();
        // 1. Check input Obj Data Type to match the current class
        if (!obj.GetType().Equals(this.GetType))
            return default(Integer);
        // 2. Down-Cast the input Object to the current class
        WallProperty wpObj;
        wpObj = (WallProperty)obj;
        // 3. Compare the two instances of the class giving precedence to name and thickness
        if (this.name.CompareTo(wpObj.getName()) != 0)
            return this.name.CompareTo(wpObj.getName());
        else if (this.thickness < wpObj.getThickness())
            return -1;
        else if (this.thickness > wpObj.getThickness())
            return 1;
        return 0;
    }


    // EQUALS

    // Method inherited from the Object superclass and that gets called everytime we check whether 
    // two instances of this class are equal or not. 
    // It has to be overwritten based on the values assigned to the attributes of the class instances
    public override bool Equals(object obj)
    {

        // 1. Check input Obj Data Type to match the current class
        if (!obj.GetType().Equals(this.GetType))
            return false;

        // 2. Down-Cast the input object to the current class
        WallProperty wpObj;
        wpObj = (WallProperty)obj;

        // 3. Check if attributes values are the same
        if (this.name.Equals(wpObj.getName()) & this.matProp.Equals(wpObj.getMatProp()) & this.thickness == wpObj.getThickness())
            return true;
        else
            return false;
    }
}
