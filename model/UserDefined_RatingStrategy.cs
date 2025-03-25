﻿using Autodesk.Revit.DB;
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
        public List<String> allowedSectionTypes;
        public List<String> allowedMaterials;
        public Single[] lengthRange;
        public Single[] weightRange;
        public Single endCutOffLength;


        /* CONSTRUCTORS */
        // Overloaded
        public UserDefined_RatingStrategy(List<String> allowedSectionTypes, 
            List<String> allowedMaterials, Single[] lengthRange, Single[] weightRange, Single endCutOffLength)
        {
            this.allowedSectionTypes = allowedSectionTypes;
            this.allowedMaterials = allowedMaterials;
            this.lengthRange = lengthRange;
            this.weightRange = weightRange;
            this.endCutOffLength = endCutOffLength;
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
            if ((frame.getCutLength()!=null) &&
                (frame.getCutLength() >= this.lengthRange[0]) &&
                (frame.getCutLength() <= this.lengthRange[1]))
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
                {frame.setReuseRating(ReuseRating.WITHIN_CRITERIA);}
            else 
                { frame.setReuseRating(ReuseRating.OUTSIDE_CRITERIA);}

            
        }

    }
}
