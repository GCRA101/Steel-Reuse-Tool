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

public class Storey : ETABSData
{

    // ATTRIBUTES
    private string name;
    private double elevation, height;
    private bool isMaster;
    private string guid;

    // CONSTRUCTORS
    // Overloaded 01
    public Storey(string name)
    {
        this.name = name;
    }
    // Overloaded 02
    public Storey(string name, double elevation, double height, bool isMaster, string guid)
    {
        this.name = name;
        this.elevation = elevation;
        this.height = height;
        this.isMaster = isMaster;
        this.guid = guid;
    }

    // METHODS

    // Setters and Getters
    public void setName(string name)
    {
        this.name = name;
    }
    public void setElevation(double elevation)
    {
        this.elevation = elevation;
    }
    public void setHeight(double height)
    {
        this.height = height;
    }
    public void setMaster(bool isMaster)
    {
        this.isMaster = isMaster;
    }
    public void setGuid(string guid)
    {
        this.guid = guid;
    }
    public string getName()
    {
        return this.name;
    }
    public double getElevation()
    {
        return this.elevation;
    }
    public double getHeight()
    {
        return this.height;
    }
    public bool getMaster()
    {
        return this.isMaster;
    }
    public string getGuid()
    {
        return this.guid;
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
        // working with the values assigned to the other attributes.
        int hash;
        hash = this.getName().GetHashCode() + System.Convert.ToInt32(Math.Round(System.Convert.ToDecimal((this.elevation + this.height))));
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
        Storey strObj;
        strObj = (Storey)obj;
        // 3. Compare the two instances of the class giving precedence to name, elevation and height
        if (this.getName().CompareTo(strObj.getName()) != 0)
            return this.getName().CompareTo(strObj.getName());
        else if (this.getElevation() < strObj.getElevation())
            return -1;
        else if (this.getElevation() > strObj.getElevation())
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
        Storey strObj;
        strObj = (Storey)obj;

        // 3. Check if the main attributes of the two objects are equal or not
        if (this.getName().Equals(strObj.getName()) & this.getElevation() == strObj.getElevation() & this.getHeight() == strObj.getHeight() & this.getGuid().Equals(strObj.getGuid()))
            return true;
        else
            return false;
    }
}
