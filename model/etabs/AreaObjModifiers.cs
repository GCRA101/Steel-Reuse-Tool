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

public class AreaObjModifiers : ObjModifiers
{

    // ATTRIBUTES
    private double f11, f22, f12, m11, m22, m12, v13, v23;

    // CONSTRUCTOR
    // Default
    public AreaObjModifiers() : base()
    {
    }
    // Overloaded
    public AreaObjModifiers(string name, double f11, double f22, double f12, double m11, double m22, double m12, double v13, double v23, double mass, double weight) : base(name)
    {
        {
            var withBlock = this;
            withBlock.f11 = f11;
            withBlock.f22 = f22;
            withBlock.f12 = f12;
            withBlock.m11 = m11;
            withBlock.m22 = m22;
            withBlock.m12 = m12;
            withBlock.v13 = v13;
            withBlock.v23 = v23;
            withBlock.mass = mass;
            withBlock.weight = weight;
        }
        this.setValues(f11, f22, f12, m11, m22, m12, v13, v23, mass, weight);
    }


    // METHODS

    // Setters and Getters

    public void setValues(double f11, double f22, double f12, double m11, double m22, double m12, double v13, double v23, double mass, double weight)
    {
        this.values = new double[] { f11, f22, f12, m11, m22, m12, v13, v23, mass, weight };
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
        hash = this.getName.GetHashCode + System.Convert.ToInt32(Math.Round(System.Convert.ToDecimal((f11 + 3 * f22 + f12 - m11 + m12 * v13 - v23 + mass + weight) * 10)));
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
        AreaObjModifiers aomObj;
        aomObj = (AreaObjModifiers)obj;
        // 3. Compare the two instances of the class giving precedence to name and then number of factors
        if (this.getName.CompareTo(aomObj.getName()) != 0)
            return this.getName.CompareTo(aomObj.getName());
        else if (this.getValues.Count < aomObj.getValues.Count)
            return -1;
        else if (this.getValues.Count > aomObj.getValues.Count)
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
        AreaObjModifiers aomObj;
        aomObj = (AreaObjModifiers)obj;

        // 3. Check if all coordinates and name of the two objects are equal or not
        if (this.getName.Equals(aomObj.getName()) & this.getValues().Equals(aomObj.getValues()))
            return true;
        else
            return false;
    }
}
