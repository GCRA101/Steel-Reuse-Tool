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
    public class LoadCaseModalEigen : LoadCaseModal
    {

        // ATTRIBUTES
        private double eigenShiftFreq, eigenCutOff, eigenTol;
        private int allowAutoFreqShift;
        private bool[] staticCorrect;

        // CONSTRUCTORS
        public LoadCaseModalEigen() : base()
        {
        }
        public LoadCaseModalEigen(string loadCaseName, string initalCaseName, int numLoads, string[] loadTypes, string[] loadNames, int numModesMax, int numModesMin, double[] targetParams, double eigenShiftFreq, double eigenCutOff, double eigenTol, int allowAutoFreqShift, bool[] staticCorrect) : base(loadCaseName, initalCaseName, numLoads, loadTypes, loadNames, numModesMax, numModesMin, targetParams)
        {
            this.eigenShiftFreq = eigenShiftFreq;
            this.eigenCutOff = eigenCutOff;
            this.eigenTol = eigenTol;
            this.allowAutoFreqShift = allowAutoFreqShift;
            this.staticCorrect = staticCorrect;
        }


        // METHODS

        // Setters
        public void setEigenShiftFreq(double eigenShiftFreq)
        {
            this.eigenShiftFreq = eigenShiftFreq;
        }
        public void setEigenCutOff(double eigenCutOff)
        {
            this.eigenCutOff = eigenCutOff;
        }
        public void setEigenTol(double eigenTol)
        {
            this.eigenTol = eigenTol;
        }
        public void setAllowAutoFreqShift(int allowAutoFreqShift)
        {
            this.allowAutoFreqShift = allowAutoFreqShift;
        }
        public void setStaticCorrect(bool[] staticCorrect)
        {
            this.staticCorrect = staticCorrect;
        }


        // Getters
        public double getEigenShiftFreq()
        {
            return this.eigenShiftFreq;
        }
        public double getEigenCutOff()
        {
            return this.eigenCutOff;
        }
        public double getEigenTol()
        {
            return this.eigenTol;
        }
        public int getAllowAutoFreqShift()
        {
            return this.allowAutoFreqShift;
        }
        public bool[] getStaticCorrect()
        {
            return this.staticCorrect;
        }



        // HASHCODE

        // Method inherited from the Object superclass and that has to be overwritten in order to generate
        // ad hoc hashcodes based on the values assigned to the specific attributes of this class.
        // The hashcode is essential to be able to sort and store instances of this class properly 
        // in whatever concrete implementation of the abstract data structure Hash Table.
        public override int GetHashCode()
        {
            // Determines and returns the Hashcode of the class instance as the number given by the sum 
            // of the corresponding superclass' hashcode plus the result of a hashing function operating on the
            // main local attributes eigenShiftFreq, eigenCutOff and eigenTol
            int hash;
            hash = base.GetHashCode() + System.Convert.ToInt32(Math.Ceiling(eigenShiftFreq * 100 + eigenCutOff - eigenTol));
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
            LoadCaseModalEigen lcmeObj;
            lcmeObj = (LoadCaseModalEigen)obj;
            // 3. Compare the two instances of the class giving precedence to the superclass' method
            // then the eigenShiftFreq
            if (base.CompareTo(lcmeObj) != 0)
                return base.CompareTo(lcmeObj);
            else if (this.eigenShiftFreq > lcmeObj.getEigenShiftFreq())
                return 1;
            else if (this.eigenShiftFreq < lcmeObj.getEigenShiftFreq())
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
            LoadCaseModalEigen lcmeObj;
            lcmeObj = (LoadCaseModalEigen)obj;

            // 3. Check if all the local attributes are assigned with same values
            if (base.Equals(lcmeObj) & this.eigenShiftFreq == lcmeObj.getEigenShiftFreq() & this.eigenCutOff == lcmeObj.getEigenCutOff() & this.eigenTol == lcmeObj.getEigenTol())
                return true;
            else
                return false;
        }
    }
}
