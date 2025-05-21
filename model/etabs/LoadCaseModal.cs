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
    public abstract class LoadCaseModal : LoadCase
    {

        // ATTRIBUTES
        protected string initialCaseName;
        protected string[] loadTypes;
        protected int numModesMax, numModesMin;
        protected double[] targetParams;

        // CONSTRUCTORS
        // Default
        public LoadCaseModal() : base()
        {
        }
        // Overloaded
        public LoadCaseModal(string loadCaseName, string initalCaseName, int numLoads, string[] loadTypes, string[] loadNames, int numModesMax, int numModesMin, double[] targetParams) : base(loadCaseName, numLoads, loadNames)
        {
            this.initialCaseName = initialCaseName;
            this.loadTypes = loadTypes;
            this.numModesMax = numModesMax;
            this.numModesMin = numModesMin;
            this.targetParams = targetParams;
        }

        // METHODS

        // Setters
        public void setInitialCaseName(string initialCaseName)
        {
            this.initialCaseName = initialCaseName;
        }
        public void setLoadTypes(string[] loadTypes)
        {
            this.loadTypes = loadTypes;
        }
        public void setNumModesMax(int numModesMax)
        {
            this.numModesMax = numModesMax;
        }
        public void setNumModesMin(int numModesMin)
        {
            this.numModesMin = numModesMin;
        }
        public void setTargetParams(double[] targetParams)
        {
            this.targetParams = targetParams;
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
        public int getNumModesMax()
        {
            return this.numModesMax;
        }
        public int getNumModesMin()
        {
            return this.numModesMin;
        }
        public double[] getTargetParams()
        {
            return this.targetParams;
        }



        // HASHCODE

        // Method inherited from the Object superclass and that has to be overwritten in order to generate
        // ad hoc hashcodes based on the values assigned to the specific attributes of this class.
        // The hashcode is essential to be able to sort and store instances of this class properly 
        // in whatever concrete implementation of the abstract data structure Hash Table.
        public override int GetHashCode()
        {
            // Determines and returns the Hashcode of the class instance as the number given by the sum 
            // of the corresponding superclass' hashcode plus the name's corresponding hashcode
            // plus the hashcode of the loadTypes array and the sum of NumModesMax and NumModesMin
            int hash;
            hash = base.GetHashCode() + this.initialCaseName.GetHashCode() + this.loadTypes.GetHashCode() + this.numModesMax + this.numModesMin;
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
            LoadCaseModal lcmObj;
            lcmObj = (LoadCaseModal)obj;
            // 3. Compare the two instances of the class giving precedence to the superclass' method
            // then the initialCaseName and finally the NumModesMax
            if (base.CompareTo(lcmObj) != 0)
                return base.CompareTo(lcmObj);
            else if (this.initialCaseName.CompareTo(lcmObj.getInitialCaseName()) != 0)
                return this.initialCaseName.CompareTo(lcmObj.getInitialCaseName());
            else if (this.numModesMax > lcmObj.getNumModesMax())
                return 1;
            else if (this.numModesMax < lcmObj.getNumModesMax())
                return -1;
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
            LoadCaseModal lcmObj;
            lcmObj = (LoadCaseModal)obj;

            // 3. Check if loadcase name, initial load case name and all factors are the same
            if (base.Equals(lcmObj) & this.initialCaseName.Equals(lcmObj.getInitialCaseName()) & this.getLoadTypes().SequenceEqual(lcmObj.getLoadTypes()) & this.numModesMax == lcmObj.getNumModesMax())
                return true;
            else
                return false;
        }
    }
}
