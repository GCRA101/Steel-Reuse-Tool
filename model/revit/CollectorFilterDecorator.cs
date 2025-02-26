using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ReuseSchemeTool.model.revit
{
    public abstract class CollectorFilterDecorator : RevitElementsCollector
    {
        // ATTRIBUTES
        protected RevitElementsCollector revitElementsCollector;

        // CONSTRUCTORS
        public CollectorFilterDecorator() { }
        public CollectorFilterDecorator(RevitElementsCollector revitElementsCollector)
        {
            this.revitElementsCollector = revitElementsCollector;
        }

        protected Autodesk.Revit.DB.Document getDBDoc()
        {
            return this.getDBDocRecursive(this.revitElementsCollector);
        }

        protected Autodesk.Revit.DB.Document getDBDocRecursive(RevitElementsCollector revitElementsCollector)
        {
            // BASE CASES
            if (revitElementsCollector == null) return null;
            if (revitElementsCollector.getCollectorStrategy()!= null)
                return revitElementsCollector.getCollectorStrategy().getDBDocument();
            // RECURSIVE CASE
            return getDBDocRecursive(((CollectorFilterDecorator)revitElementsCollector).revitElementsCollector);
        }


    }
}
