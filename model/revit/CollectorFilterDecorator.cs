using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReuseSchemeTool.model.revit
{
    public abstract class CollectorFilterDecorator : RevitElementsCollector
    {
        // ATTRIBUTES
        protected RevitElementsCollector revitElementsCollector;

        // CONSTRUCTOR
        public CollectorFilterDecorator(RevitElementsCollector revitElementsCollector)
        {
            this.revitElementsCollector = revitElementsCollector;
        }


    }
}
