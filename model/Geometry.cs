using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReuseSchemeTool.model
{
    public abstract class Geometry
    {

        /* ATTRIBUTES */
        protected string uniqueId;

        /* CONSTRUCTORS */
        // Default

        /* METHODS */

        // Setters
        public void setUniqueId(string uniqueId) { this.uniqueId = uniqueId; }

        // Getters
        public string getUniqueId() { return this.uniqueId; }

        
        
    }
}
