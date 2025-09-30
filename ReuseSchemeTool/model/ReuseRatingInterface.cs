using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReuseSchemeTool.model
{
    public interface ReuseRatingInterface
    {
        void calculateRating(ExistingSteelFrame frame);
    }
}
