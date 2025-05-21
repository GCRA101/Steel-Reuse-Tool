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
    public class LoadCaseResponseSpectrum : LoadCase
    {

        // ATTRIBUTES
        private string modalCaseName;
        private string[] functions;
        private string[] csys;
        private double[] scaleFactors, ang;
        private double eccen;

        // CONSTRUCTORS
        // Default
        public LoadCaseResponseSpectrum() : base()
        {
        }
        // Overloaded
        public LoadCaseResponseSpectrum(string loadCaseName, string modalCaseName, int numLoads, string[] loadNames, string[] functions, string[] csys, double[] scaleFactors, double[] ang, double eccen) : base(loadCaseName, numLoads, loadNames)
        {
            this.modalCaseName = modalCaseName;
            this.functions = functions;
            this.csys = csys;
            this.scaleFactors = scaleFactors;
            this.ang = ang;
            this.eccen = eccen;
        }


        // METHODS

        // Setters
        public void setModalCaseName(string modalCaseName)
        {
            this.modalCaseName = modalCaseName;
        }
        public void setFunctions(string[] functions)
        {
            this.functions = functions;
        }
        public void setCSys(string[] csys)
        {
            this.csys = csys;
        }
        public void setScaleFactors(double[] scaleFactors)
        {
            this.scaleFactors = scaleFactors;
        }
        public void setAng(double[] ang)
        {
            this.ang = ang;
        }
        public void setEccen(double eccen)
        {
            this.eccen = eccen;
        }

        // Getters
        public string getModalCaseName()
        {
            return this.modalCaseName;
        }
        public string[] getFunctions()
        {
            return this.functions;
        }
        public string[] getCSys()
        {
            return this.csys;
        }
        public double[] getScaleFactors()
        {
            return this.scaleFactors;
        }
        public double[] getAng()
        {
            return this.ang;
        }
        public double getEccen()
        {
            return this.eccen;
        }



        // HASHCODE

        // Method inherited from the Object superclass and that has to be overwritten in order to generate
        // ad hoc hashcodes based on the values assigned to the specific attributes of this class.
        // The hashcode is essential to be able to sort and store instances of this class properly 
        // in whatever concrete implementation of the abstract data structure Hash Table.
        public override int GetHashCode()
        {
            // Determines and returns the Hashcode of the class instance as the number given by the sum 
            // of the corresponding superclass' hashCode + the output of an additional hashing function
            // working on the local attributes scaleFactors, ang and eccen
            int hash;
            hash = base.GetHashCode() + System.Convert.ToInt32(Math.Round(System.Convert.ToDecimal(scaleFactors.Sum() + ang.Sum() + eccen)));
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
            LoadCaseResponseSpectrum lcrsObj;
            lcrsObj = (LoadCaseResponseSpectrum)obj;
            // 3. Compare the two instances of the class giving precedence to the superclass comparer
            // then the modalCaseName
            if (base.CompareTo(lcrsObj) != 0)
                return base.CompareTo(lcrsObj);
            else if (this.modalCaseName.CompareTo(lcrsObj.getModalCaseName()) != 0)
                return this.modalCaseName.CompareTo(lcrsObj.getModalCaseName());
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
            LoadCaseResponseSpectrum lcrsObj;
            lcrsObj = (LoadCaseResponseSpectrum)obj;

            // 3. Check if modalCaseName and all functions and corresponding factors are the same
            if (base.Equals(lcrsObj) & this.getModalCaseName().Equals(lcrsObj.getModalCaseName()) & this.functions.SequenceEqual(lcrsObj.getFunctions()) & this.scaleFactors.SequenceEqual(lcrsObj.getScaleFactors()))
                return true;
            else
                return false;
        }
    }
}
