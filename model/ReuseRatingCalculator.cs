using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReuseSchemeTool.model
{
    public class ReuseRatingCalculator : ReuseRatingInterface
    {
        /* ATTRIBUTES */
        ReuseRatingStrategy ratingStrategy;

        /* CONSTRUCTOR */
        // Overloaded
        public ReuseRatingCalculator(ReuseRatingStrategy ratingStrategy)
        {
            this.ratingStrategy = ratingStrategy;
        }


        /* METHODS */

        public void calculateRating(ExistingSteelFrame frame)
        {
            this.ratingStrategy.calculateRating(frame);
        }


        // Setters
        public void setRatingStrategy(ReuseRatingStrategy ratingStrategy){this.ratingStrategy = ratingStrategy;}

        // Getters
        public ReuseRatingStrategy getRatingStrategy() { return this.ratingStrategy; }
    }
}
