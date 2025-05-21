using System;

public abstract class AreaObjProperty : IComparable
{

    // ATTRIBUTES
    public string name;
    public int color;
    public string notes;
    public string guid;

    // CONSTRUCTORS
    // Default
    public AreaObjProperty()
    {
    }
    // Overloaded
    public AreaObjProperty(string name)
    {
        this.name = name;
    }

    // METHODS

    // Setters
    public void setName(string name)
    {
        this.name = name;
    }
    public void setColor(int color)
    {
        this.color = color;
    }
    public void setNotes(string notes)
    {
        this.notes = notes;
    }
    public void setGuid(string guid)
    {
        this.guid = guid;
    }

    // Getters
    public string getName()
    {
        return this.name;
    }
    public int getColor()
    {
        return this.color;
    }
    public string getNotes()
    {
        return this.notes;
    }
    public string getGuid()
    {
        return this.guid;
    }

    public virtual int CompareTo(object obj)
    {
        throw new NotImplementedException();
    }
}
