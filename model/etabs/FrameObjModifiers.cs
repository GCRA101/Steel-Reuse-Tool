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

public class FrameObjModifiers : ObjModifiers
{

    // ATTRIBUTES
    private double crossSectionArea, shearArea2, shearArea3, torsion, momentOfInertia2, momentOfIntertia3;

    // CONSTRUCTOR
    // Default
    public FrameObjModifiers() : base()
    {
    }
    // Overloaded
    public FrameObjModifiers(string name, double crossSectionArea, double shearArea2, double shearArea3, double torsion, double momentOfInertia2, double momentOfInertia3) : base(name)
    {
        {
            var withBlock = this;
            withBlock.crossSectionArea = crossSectionArea;
            withBlock.shearArea2 = shearArea2;
            withBlock.shearArea3 = shearArea3;
            withBlock.torsion = torsion;
            withBlock.momentOfInertia2 = momentOfInertia2;
            withBlock.momentOfIntertia3 = momentOfInertia3;
        }
        this.setValues(crossSectionArea, shearArea2, shearArea3, torsion, momentOfInertia2, momentOfInertia3);
    }


    // METHODS

    // Setters and Getters

    public void setValues(double crossSectionArea, double shearArea2, double shearArea3, double torsion, double momentOfInertia2, double momentOfInertia3)
    {
        this.values = new double[] { crossSectionArea, shearArea2, shearArea3, torsion, momentOfInertia2, momentOfInertia3 };
    }


    // HASHCODE

    // Method inherited from the Object superclass and that has to be overwritten in order to generate
    // ad hoc hashcodes based on the values assigned to the specific attributes of this class.
    // The hashcode is essential to be able to sort and store instances of this class properly 
    // in whatever concrete implementation of the abstract data structure Hash Table.
    public override int GetHashCode()
    {
        // Determines and returns the Hashcode of the class instance as the number given by the sum 
        // of the name's corresponding hashcode plus the integer result of a local hashing function
        // working with the values assigned to the obj modifiers.
        int hash;
        hash = this.getName.GetHashCode + System.Convert.ToInt32(Math.Round(System.Convert.ToDecimal((crossSectionArea + 3 * shearArea2 + shearArea3 - momentOfInertia2) * 10)));
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
        FrameObjModifiers fomObj;
        fomObj = (FrameObjModifiers)obj;
        // 3. Compare the two instances of the class giving precedence to name and then number of factors
        if (this.getName.CompareTo(fomObj.getName()) != 0)
            return this.getName.CompareTo(fomObj.getName());
        else if (this.getValues.Count < fomObj.getValues.Count)
            return -1;
        else if (this.getValues.Count > fomObj.getValues.Count)
            return 1;
        return 0;
    }


    // EQUALS

    // Method inherited from the Object superclass and that gets called everytime we check whether 
    // two instances of this class are equal or not. 
    // It has to be overwritten based on the values assigned to the attributes of the class instances
    public override bool Equals(object obj)
    {

        // 1. Check input Obj Data Type to match the PointObj Class
        if (!obj.GetType().Equals(this.GetType))
            return false;

        // 2. Down-Cast the input object to the current class
        FrameObjModifiers fomObj;
        fomObj = (FrameObjModifiers)obj;

        // 3. Check if all coordinates and name of the two objects are equal or not
        if (this.getName.Equals(fomObj.getName()) & this.getValues().Equals(fomObj.getValues()))
            return true;
        else
            return false;
    }
}
