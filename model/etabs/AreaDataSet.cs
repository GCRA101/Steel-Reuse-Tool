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

public class AreaDataSet : ETABSData
{

    // ATTRIBUTES
    private AreaObj areaObj;
    private ShellForces forces;

    // CONSTRUCTORS
    // Default
    public AreaDataSet()
    {
    }
    // Overloaded
    public AreaDataSet(AreaObj areaObj, ShellForces forces)
    {
        this.areaObj = areaObj;
        this.forces = forces;
    }

    // METHODS

    // Setters
    public void setAreaObj(AreaObj areaObj)
    {
        this.areaObj = areaObj;
    }
    public void setForces(ShellForces forces)
    {
        this.forces = forces;
    }

    // Getters
    public AreaObj getAreaObj()
    {
        return this.areaObj;
    }
    public ShellForces getForces()
    {
        return this.forces;
    }



    // HASHCODE

    // Method inherited from the Object superclass and that has to be overwritten in order to generate
    // ad hoc hashcodes based on the values assigned to the specific attributes of this class.
    // The hashcode is essential to be able to sort and store instances of this class properly 
    // in whatever concrete implementation of the abstract data structure Hash Table.
    public override int GetHashCode()
    {
        // Determines and returns the Hashcode of the class instance as the integer number given 
        // by the sum of the hashcodes of the areaObj and of the shell forces
        return this.getAreaObj().GetHashCode + this.getForces().GetHashCode;
    }


    // COMPARETO

    // Method implemented from the IComparable Functional Interface which unique method CompareTo 
    // gets called everytime we want to compare an instance of this class with another object.
    // The method needs to be implemented accordingly with the criteria we want to use to define
    // which object is greater or smaller than the other based on the values assigned to its 
    // attributes.
    public override int CompareTo(object obj)
    {
        // 1. Check input Obj Data Type to match the class of the present object
        if (!obj.GetType().Equals(this.GetType))
            return default(Integer);
        // 2. Down-Cast the input Object to the AreaDataSet class
        AreaDataSet adsObj;
        adsObj = (AreaDataSet)obj;
        // 3. Compare the two instances of the class giving precedence to the Area Object
        return this.getAreaObj().CompareTo(adsObj.getAreaObj());
    }


    // EQUALS

    // Method inherited from the Object superclass and that gets called everytime we check whether 
    // two instances of this class are equal or not. 
    // It has to be overwritten based on the values assigned to the attributes of the class instances
    public override bool Equals(object obj)
    {

        // 1. Check input Obj Data Type to match the class of the present object
        if (!obj.GetType().Equals(this.GetType))
            return false;

        // 2. Down-Cast the input Object to AreaDataSet class
        AreaDataSet adsObj;
        adsObj = (AreaDataSet)obj;

        // 3. Check if the areaObjects of the two objects are the same
        if (this.getAreaObj().Equals(adsObj.getAreaObj()) & this.forces.Equals(adsObj.getForces()))
            return true;

        return false;
    }
}
