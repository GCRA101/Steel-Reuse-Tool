using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReuseSchemeTool.model
{
    public abstract class ReuseRatingStrategy : ReuseRatingInterface
    {
        public abstract void calculateRating(ExistingSteelFrame frame);

    }
}
