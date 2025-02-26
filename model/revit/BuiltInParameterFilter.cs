using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ReuseSchemeTool.model.revit
{
    public class BuiltInParameterFilter : CollectorFilterDecorator
    {
        private BuiltInParameter builtInParameter;
        private string value;

        public BuiltInParameterFilter(RevitElementsCollector revitElementsCollector, BuiltInParameter builtInParameter, string value) : base(revitElementsCollector)
        {
            this.builtInParameter = builtInParameter;
            this.value = value;
        }


        public override List<Element> collectElements()
        {
            Document dbDoc = this.revitElementsCollector.getCollectorStrategy().getDBDocument();

            return this.revitElementsCollector
                            .collectElements()
                            .Where(el => el.get_Parameter(builtInParameter).HasValue &&
                                            el.get_Parameter(builtInParameter) != null)
                            .Where(el => el.get_Parameter(builtInParameter).AsString() == value)
                            .ToList();
        }

    }
}