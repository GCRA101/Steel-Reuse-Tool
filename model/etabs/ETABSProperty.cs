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

public abstract class ETABSProperty : ETABSData
{

    // ATTRIBUTES **************************************************
    protected string name;
    protected ColorInterface color;
    protected string description;


    // CONSTRUCTORS ************************************************
    // Default
    public ETABSProperty()
    {
    }
    // Overloaded 01
    public ETABSProperty(string name)
    {
        this.name = name;
    }
    // Overloaded 02
    public ETABSProperty(string name, ColorInterface color, string description) : this(name)
    {
        this.color = color;
        this.description = description;
    }


    // METHODS ******************************************************

    // Setters
    public void setName(string name)
    {
        this.name = name;
    }
    public void setColor(ColorInterface color)
    {
        this.color = color;
    }
    public void setDescription(string description)
    {
        this.description = description;
    }

    // Getters
    public string getName()
    {
        return this.name;
    }
    public ColorInterface getColor()
    {
        return this.color;
    }
    public string getDescription()
    {
        return this.description;
    }
}
