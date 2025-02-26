using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReuseSchemeTool.model.revit
{
    public class RevitElementsCollector : RevitElemCollectorInterface
    {
        // ATTRIBUTES
        protected RevitElemCollectorStrategy collectorStrategy;

        // CONSTRUCTORS
        public RevitElementsCollector() { }
        public RevitElementsCollector(RevitElemCollectorStrategy collectorStrategy)
        {
            this.collectorStrategy = collectorStrategy;
        }



        public virtual List<Element> collectElements()
        {
            return this.collectorStrategy.collectElements();
        }


        public void setCollectorStrategy(RevitElemCollectorStrategy collectorStrategy) { this.collectorStrategy = collectorStrategy; }

        public RevitElemCollectorStrategy getCollectorStrategy() { return this.collectorStrategy; }
    }
}
