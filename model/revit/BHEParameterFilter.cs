using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReuseSchemeTool.model.revit
{
    public class BHEParameterFilter : CollectorFilterDecorator
    {
        private string parameterName, parameterValue;

        public BHEParameterFilter(RevitElementsCollector revitElementsCollector, string parameterName, string parameterValue) : base(revitElementsCollector)
        {
            this.parameterName = parameterName;
            this.parameterValue = parameterValue;
        }


        public override List<Element> collectElements()
        {
            Document dbDoc = this.revitElementsCollector.getCollectorStrategy().getDBDocument();

            return this.revitElementsCollector.collectElements().Where(el => el.LookupParameter(parameterName).AsString() == parameterValue).ToList();

        }

    }
}
