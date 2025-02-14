using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReuseSchemeTool.model
{
    public class UserDefined_RatingStrategy: ReuseRatingStrategy
    {
        /* ATTRIBUTES */
        List<String> allowedSectionTypes;
        List<String> allowedMaterials;
        Single[] lengthRange;
        Single[] weightRange;


        /* CONSTRUCTORS */
        // Overloaded
        public UserDefined_RatingStrategy(List<String> allowedSectionTypes, 
            List<String> allowedMaterials, Single[] lengthRange, Single[] weightRange)
        {
            this.allowedSectionTypes = allowedSectionTypes;
            this.allowedMaterials = allowedMaterials;
            this.lengthRange = lengthRange;
            this.weightRange = weightRange;
        }


        /* METHODS */
        public override void calculateRating(ExistingSteelFrame frame)
        {
            // 1. CHECKS

            // Local Variables
            bool sectionCheck = false, materialCheck = false;
            bool lengthCheck = false, weightCheck = false;

            // Section Check
            foreach (String secType in allowedSectionTypes) {
                if ((frame.getSection()!=null) && (frame.getSection().getName().Contains(secType))) {
                    sectionCheck = true;
                    break; }}

            // Material Check
            foreach (String mat in allowedMaterials) {
                if ((frame.getMaterial()!=null) && (frame.getMaterial().Contains(mat))) {
                    materialCheck = true;
                    break;}
            }

            // Length Check
            if ((frame.getLength()!=null) &&
                (frame.getLength() >= UnitUtils.ConvertToInternalUnits(this.lengthRange[0], UnitTypeId.Meters)) &&
                (frame.getLength() <= UnitUtils.ConvertToInternalUnits(this.lengthRange[1], UnitTypeId.Meters)))
            {
                lengthCheck = true;
            }

            //
            // Check
            if ((frame.getSection()!=null) &&
                (frame.getSection().getWeight() >= this.weightRange[0]) &&
                (frame.getSection().getWeight() <= this.weightRange[1]))
            {
                weightCheck = true;
            }

            // 2. ASSIGN REUSE RATING

            if (sectionCheck && materialCheck && lengthCheck && weightCheck)
                {frame.setReuseRating(ReuseRating.MUST_HAVE);}
            else 
                { frame.setReuseRating(ReuseRating.MUST_NOT_HAVE);}

            
        }

    }
}
