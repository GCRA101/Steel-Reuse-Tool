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
using ETABSv1;
using CSiAPIv1;

public class Group : ETABSData
{

    // ATTRIBUTES *****************************************************************************
    private string name;
    private ColorInterface colour;


    // CONSTRUCTORS ***************************************************************************

    // Overloaded 1
    public Group(string name) : base()
    {
        this.name = name;
    }
    // Overloaded 2
    public Group(string name, ColorInterface colour) : this(name)
    {
        this.colour = colour;
    }


    // METHODS ********************************************************************************

    // Setters
    public void setName(string name)
    {
        this.name = name;
    }
    public void setColour(ColorInterface colour)
    {
        this.colour = colour;
    }

    // Getters
    public string getName()
    {
        return this.name;
    }
    public ColorInterface getColour()
    {
        return this.colour;
    }

    // HASHCODE

    // Method inherited from the Object superclass and that has to be overwritten in order to generate
    // ad hoc hashcodes based on the values assigned to the specific attributes of this class.
    // The hashcode is essential to be able to sort and store instances of this class properly 
    // in whatever concrete implementation of the abstract data structure Hash Table.
    public override int GetHashCode()
    {
        // Determines and returns the Hashcode of the class instance as the integer number given 
        // by the sum of the hashcodes of the point and reactions attributes respectively.
        int hash;
        hash = this.Name.GetHashCode() + this.getColour().getEtabsIntValue;
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
        // 1. Check input Obj Data Type to match the Current Class
        if (!obj.GetType().Equals(this.GetType))
            return default(Integer);
        // 2. Down-Cast the input Object to the Current Class
        Group grpObj;
        grpObj = (Group)obj;
        // 3. Compare the two instances of the class giving precedence to the Name and the Color attributes
        if ((this.getName().CompareTo(grpObj.getName()) != 0))
            return this.getName().CompareTo(grpObj.getName());
        else if (this.getColour().CompareTo(grpObj.getColour()) != 0)
            return this.getColour().CompareTo(grpObj.getColour());

        return 0;
    }


    // EQUALS

    // Method inherited from the Object superclass and that gets called everytime we check whether 
    // two instances of this class are equal or not. 
    // It has to be overwritten based on the values assigned to the attributes of the class instances
    public override bool Equals(object obj)
    {

        // 1. Check input Obj Data Type to match the Current Class
        if (!obj.GetType().Equals(this.GetType))
            return false;

        // 2. Down-Cast the input object to the Current Class
        Group grpObj;
        grpObj = (Group)obj;

        // 3. Check if attributes of the two class instances are equal or not
        if (this.getName().Equals(grpObj.getName()) & this.getColour().getEtabsIntValue == grpObj.getColour().getEtabsIntValue)
            return true;

        return false;
    }
}
