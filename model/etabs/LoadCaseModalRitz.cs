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
    public class LoadCaseModalRitz : LoadCaseModal
    {

        // ATTRIBUTES
        private int[] ritzMaxCyc;

        // CONSTRUCTORS
        public LoadCaseModalRitz() : base()
        {
        }
        public LoadCaseModalRitz(string loadCaseName, string initalCaseName, int numLoads, string[] loadTypes, string[] loadNames, int numModesMax, int numModesMin, double[] targetParams, int[] ritzMaxCyc) : base(loadCaseName, initalCaseName, numLoads, loadTypes, loadNames, numModesMax, numModesMin, targetParams)
        {
            this.ritzMaxCyc = ritzMaxCyc;
        }


        // METHODS

        // Setters
        public void setRitzMaxCyc(int[] ritzMaxCyc)
        {
            this.ritzMaxCyc = ritzMaxCyc;
        }

        // Getters
        public int[] getRitzMaxCyc()
        {
            return this.ritzMaxCyc;
        }


        // HASHCODE

        // Method inherited from the Object superclass and that has to be overwritten in order to generate
        // ad hoc hashcodes based on the values assigned to the specific attributes of this class.
        // The hashcode is essential to be able to sort and store instances of this class properly 
        // in whatever concrete implementation of the abstract data structure Hash Table.
        public override int GetHashCode()
        {
            // Determines and returns the Hashcode of the class instance as the number given by the sum 
            // of the corresponding superclass' hashcode plus the sum of all the ritzMaxCyc factors
            int hash;
            hash = base.GetHashCode() + Math.Round(System.Convert.ToDecimal(ritzMaxCyc.Sum()));
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
            LoadCaseModalRitz lcmrObj;
            lcmrObj = (LoadCaseModalRitz)obj;
            // 3. Compare the two instances of the class giving precedence to the superclass' method
            // then the RitzMaxCyc attribute
            if (base.CompareTo(lcmrObj) != 0)
                return base.CompareTo(lcmrObj);
            else if (this.ritzMaxCyc.Sum() > lcmrObj.getRitzMaxCyc().Sum())
                return 1;
            else if (this.ritzMaxCyc.Sum() < lcmrObj.getRitzMaxCyc().Sum())
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
            LoadCaseModalRitz lcmrObj;
            lcmrObj = (LoadCaseModalRitz)obj;

            // 3. Check if all the local attributes are assigned with same values
            if (base.Equals(lcmrObj) & this.ritzMaxCyc.Sum() == lcmrObj.getRitzMaxCyc().Sum())
                return true;
            else
                return false;
        }
    }
}
