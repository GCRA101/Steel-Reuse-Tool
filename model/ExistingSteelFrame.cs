using Autodesk.Revit.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReuseSchemeTool.model
{
    public class ExistingSteelFrame : FrameDecorator
    {
        /* ATTRIBUTES */
        private ConditionSurveyInfo conditionInfo;
        private DimensionalSurveyInfo dimensionInfo;
        private Double endCutOffLength;
        private ReuseRating reuseRating;
        private string reuseStrategy;


        /* CONSTRUCTORS */
        
        // Overloaded 01
        public ExistingSteelFrame(Frame frame) : base(frame) { }

        // Overloaded 02
        public ExistingSteelFrame(Frame frame, ConditionSurveyInfo conditionSurveyInfo, DimensionalSurveyInfo dimensionalSurveyInfo, Double endCutOffLength=0.0): this(frame)
        {
            this.conditionInfo = conditionSurveyInfo;
            this.dimensionInfo = dimensionalSurveyInfo;
            this.endCutOffLength = endCutOffLength;
        }


        /* METHODS */

        // Setters
        public void setConditionInfo(ConditionSurveyInfo conditionInfo) { this.conditionInfo = conditionInfo; } 
        public void setDimensionInfo(DimensionalSurveyInfo dimensionInfo) { this.dimensionInfo = dimensionInfo; }   
        public void setCutOffLength(Double endCutOffLength) { this.endCutOffLength= endCutOffLength; }
        public void setReuseRating(ReuseRating reuseRating) { this.reuseRating = reuseRating; }
        public void setReuseStrategy(string reuseStrategy) { this.reuseStrategy = reuseStrategy; }

        // Getters
        public ConditionSurveyInfo getConditionInfo() { return this.conditionInfo; }
        public DimensionalSurveyInfo getDimensionInfo() { return this.dimensionInfo; }
        public Double getEndCutOffLength() { return this.endCutOffLength; }
        public Double getCutLength() { return this.getLength()-this.endCutOffLength; }
        public ReuseRating getReuseRating() { return this.reuseRating; }
        public string getReuseStrategy() { return this.reuseStrategy; }



        /* HASHCODE */

        // Method inherited from the Object superclass and that has to be overwritten in order to generate
        // ad hoc hashcodes based on the values assigned to the specific attributes of this class.
        // The hashcode is essential to be able to sort and store instances of this class properly 
        // in whatever concrete implementation of the abstract data structure Hash Table.
        public override int GetHashCode()
        {
            return this.frame.GetHashCode() + this.reuseRating.GetHashCode();
        }

        /* COMPARETO */

        /* Method implemented from the IComparable Functional Interface which unique method CompareTo 
           gets called everytime we want to compare an instance of this class with another object.
           The method needs to be implemented accordingly with the criteria we want to use to define
           which object is greater or smaller than the other based on the values assigned to its 
           attributes. */
        public override int CompareTo(object o)
        {
            // 1. Check if object is null or has a different data type
            if (o == null || !(o is ExistingSteelFrame)) return 1;
            // 2. Downcast object to T data type
            ExistingSteelFrame extframe = (ExistingSteelFrame)o;
            // 3. Compare Frame
            if (this.frame.CompareTo(extframe.frame) != 0) return this.frame.CompareTo(extframe.frame);
            // 4. Compare ReuseRating
            if (this.reuseRating.CompareTo(extframe.reuseRating) != 0) return this.reuseRating.CompareTo(extframe.reuseRating);
            // 5. Return 0 (i.e. equality) otherwise...
            return 0;
        }

        /* EQUALS */

        /* Method inherited from the Object superclass and that gets called everytime we check whether 
           two instances of this class are equal or not. 
           It has to be overwritten based on the values assigned to the attributes of the class instances. */
        public override bool Equals(object o)
        {
            // 1. Check if object is null or has a different data type
            if (o == null || !(o is ExistingSteelFrame)) return false;
            // 2. Downcast object to T data type
            ExistingSteelFrame extframe = (ExistingSteelFrame)o;
            // 3. Return equality if all attributes are identical
            return (this.frame.Equals(extframe.frame) && this.reuseRating.Equals(extframe.reuseRating) &&
                    this.conditionInfo.Equals(extframe.conditionInfo) && 
                    this.dimensionInfo.Equals(extframe.dimensionInfo));
        }





    }
}
