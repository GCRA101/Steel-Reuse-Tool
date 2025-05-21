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

namespace model
{
    public abstract class LoadCase : ETABSData
    {

        // ATTRIBUTES'
        protected string loadCaseName;
        protected int numLoads;
        protected string[] loadNames;

        // CONSTRUCTOR'
        // Default
        public LoadCase()
        {
        }
        // Overloaded
        public LoadCase(string loadCaseName, int numLoads, string[] loadNames)
        {
            {
                var withBlock = this;
                withBlock.loadCaseName = loadCaseName;
                withBlock.numLoads = numLoads;
                withBlock.loadNames = loadNames;
            }
        }

        // METHODS'

        // Setters
        public void setLoadCaseName(string loadCaseName)
        {
            this.loadCaseName = loadCaseName;
        }
        public void setNumLoads(int numLoads)
        {
            this.numLoads = numLoads;
        }
        public void setLoadNames(string[] loadNames)
        {
            this.loadNames = loadNames;
        }


        // Getters
        public string getLoadCaseName()
        {
            return this.loadCaseName;
        }
        public int getNumLoads()
        {
            return this.numLoads;
        }
        public string[] getLoadNames()
        {
            return this.loadNames;
        }


        // HASHCODE

        // Method inherited from the Object superclass and that has to be overwritten in order to generate
        // ad hoc hashcodes based on the values assigned to the specific attributes of this class.
        // The hashcode is essential to be able to sort and store instances of this class properly 
        // in whatever concrete implementation of the abstract data structure Hash Table.
        public override int GetHashCode()
        {
            // Determines and returns the Hashcode of the class instance as the number given by the sum 
            // of the name's corresponding hashcode plus the number of load patterns
            int hash;
            hash = this.loadCaseName.GetHashCode() + this.getNumLoads();
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
            LoadCase lcObj;
            lcObj = (LoadCase)obj;
            // 3. Compare the two instances of the class giving precedence to the name and the number of loads
            if (this.loadCaseName.CompareTo(lcObj.getLoadCaseName()) != 0)
                return this.loadCaseName.CompareTo(lcObj.getLoadCaseName());
            else if (this.getNumLoads() < lcObj.getNumLoads())
                return -1;
            else if (this.getNumLoads() > lcObj.getNumLoads())
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
            LoadCase lcObj;
            lcObj = (LoadCase)obj;

            // 3. Check if loadcase name, initial load case name and all factors are the same
            if (this.getLoadCaseName().Equals(lcObj.getLoadCaseName()) & this.numLoads == lcObj.getNumLoads() & this.getLoadNames().Equals(lcObj.getLoadNames()))
                return true;
            else
                return false;
        }
    }
}
