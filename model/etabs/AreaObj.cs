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

public class AreaObj : ETABSData
{

    // ATTRIBUTES
    private string name;
    private List<PointObj> points;
    private AreaObjProperty areaProperty;
    private string groupName;
    private AreaObjModifiers propertyModifiers;

    // CONSTRUCTORS
    // Default
    public AreaObj()
    {
    }
    // Overloaded1
    public AreaObj(string name)
    {
        this.name = name;
    }
    // Overloaded2
    public AreaObj(string name, List<PointObj> points, AreaObjProperty areaProperty, string groupName = "", AreaObjModifiers propertyModifiers = null/* TODO Change to default(_) if this is not a reference type */)
    {
        this.name = name;
        this.points = points;
        this.areaProperty = areaProperty;
        this.groupName = groupName;
        this.propertyModifiers = propertyModifiers;
    }
    // Overloaded3
    public AreaObj(string name, string groupName, AreaObjModifiers propertyModifiers)
    {
        this.name = name;
        this.groupName = groupName;
        this.propertyModifiers = propertyModifiers;
    }


    // METHODS

    // Setters
    public void setName(string name)
    {
        this.name = name;
    }
    public void setPoints(List<PointObj> points)
    {
        this.points = points;
    }
    public void setAreaProperty(areaObjProperty areaProperty)
    {
        this.areaProperty = areaProperty;
    }
    public void setGroupName(string groupName)
    {
        this.groupName = groupName;
    }
    public void setPropertyModifiers(AreaObjModifiers propertyModifiers)
    {
        this.propertyModifiers = propertyModifiers;
    }

    // Getters
    public string getName()
    {
        return this.name;
    }
    public List<PointObj> getPoints()
    {
        return this.points;
    }

    public areaObjProperty getAreaProperty()
    {
        return this.areaProperty;
    }
    public string getGroupName()
    {
        return this.groupName;
    }
    public AreaObjModifiers getPropertyModifiers()
    {
        return this.propertyModifiers;
    }



    // HASHCODE

    // Method inherited from the Object superclass and that has to be overwritten in order to generate
    // ad hoc hashcodes based on the values assigned to the specific attributes of this class.
    // The hashcode is essential to be able to sort and store instances of this class properly 
    // in whatever concrete implementation of the abstract data structure Hash Table.
    public override int GetHashCode()
    {
        // Determines and returns the Hashcode of the class instance as the integer number given 
        // by the sum of the hashcodes of the name and the corner points
        return this.name.GetHashCode() + this.getPoints().GetHashCode();
    }


    // COMPARETO

    // Method implemented from the IComparable Functional Interface which unique method CompareTo 
    // gets called everytime we want to compare an instance of this class with another object.
    // The method needs to be implemented accordingly with the criteria we want to use to define
    // which object is greater or smaller than the other based on the values assigned to its 
    // attributes.
    public override int CompareTo(object obj)
    {
        // 1. Check input Obj Data Type to match the AreaObj Class
        if (!obj.GetType().Equals(this.GetType))
            return default(Integer);
        // 2. Down-Cast the input Object to the AreaObjClass
        AreaObj areaObj;
        areaObj = (AreaObj)obj;
        // 3. Compare the two instances of the class giving precedence to the name
        return this.getName().CompareTo(areaObj.getName());
    }


    // EQUALS

    // Method inherited from the Object superclass and that gets called everytime we check whether 
    // two instances of this class are equal or not. 
    // It has to be overwritten based on the values assigned to the attributes of the class instances
    public override bool Equals(object obj)
    {

        // 1. Check input Obj Data Type to match the AreaObj Class
        if (!obj.GetType().Equals(this.GetType))
            return false;

        // 2. Down-Cast the input Object to the AreaObjClass
        AreaObj areaObj;
        areaObj = (AreaObj)obj;

        // 3. Check if the name and the list of corner points of the two objects area the same
        if (this.getName().Equals(areaObj.getName()) & this.getPoints().Equals(areaObj.getPoints()))
            return true;

        return false;
    }
}
