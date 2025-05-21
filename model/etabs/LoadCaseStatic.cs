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
    public abstract class LoadCaseStatic : LoadCase
    {

        // ATTRIBUTES'
        protected string initialCaseName;
        protected string[] loadTypes;
        protected double[] sfs;

        // CONSTRUCTORS'
        // Default'
        public LoadCaseStatic() : base()
        {
        }

        // Overloaded'
        public LoadCaseStatic(string loadCaseName, string initialCaseName, int numLoads, string[] loadTypes, string[] loadNames, double[] sfs) : base(loadCaseName, numLoads, loadNames)
        {
            // Assign additional attributes
            this.initialCaseName = initialCaseName;
            this.loadTypes = loadTypes;
            this.sfs = sfs;
        }


        // METHODS'

        // Setters
        public void setInitialCaseName(string initialCaseName)
        {
            this.initialCaseName = initialCaseName;
        }
        public void setLoadTypes(string[] loadTypes)
        {
            this.loadTypes = loadTypes;
        }
        public void setSfs(double[] sfs)
        {
            this.sfs = sfs;
        }

        // Getters
        public string getInitialCaseName()
        {
            return this.initialCaseName;
        }
        public string[] getLoadTypes()
        {
            return this.loadTypes;
        }
        public double[] getSfs()
        {
            return this.sfs;
        }



        // HASHCODE

        // Method inherited from the Object superclass and that has to be overwritten in order to generate
        // ad hoc hashcodes based on the values assigned to the specific attributes of this class.
        // The hashcode is essential to be able to sort and store instances of this class properly 
        // in whatever concrete implementation of the abstract data structure Hash Table.
        public override int GetHashCode()
        {
            // Determines and returns the Hashcode of the class instance as the number given by the sum 
            // of the superclass' corresponding hashcode plus the hashcode of the loadTypes array and the sum
            // of all the sfs factors
            int hash;
            hash = base.GetHashCode + this.loadTypes.GetHashCode() + this.sfs.Sum();
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
            LoadCaseStatic lcsObj;
            lcsObj = (LoadCaseStatic)obj;
            // 3. Compare the two instances of the class giving precedence to superclass' method and
            // initialCaseName
            if (base.CompareTo(lcsObj) != 0)
                return base.CompareTo(lcsObj);
            else if (this.getInitialCaseName().CompareTo(lcsObj.getInitialCaseName()) != 0)
                return this.getInitialCaseName().CompareTo(lcsObj.getInitialCaseName());
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
            LoadCaseStaticLinear lcsObj;
            lcsObj = (LoadCaseStaticLinear)obj;

            // 3. Check if loadcase name, initial load case name and all factors are the same
            if (base.Equals(lcsObj) & this.getInitialCaseName().Equals(lcsObj.getInitialCaseName) & this.getLoadTypes().SequenceEqual(lcsObj.getLoadTypes) & this.sfs.SequenceEqual(lcsObj.getSfs))
                return true;
            else
                return false;
        }
    }
}
