using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReuseSchemeTool.model.revit
{
    public class PhaseCreatedFilter : CollectorFilterDecorator
    {
        private string phasePattern;

        public PhaseCreatedFilter(RevitElementsCollector revitElementsCollector, string phasePattern) : base(revitElementsCollector) 
        {
            this.phasePattern = phasePattern;
        }


        public override List<Element> collectElements()
        {
            Document dbDoc = this.getDBDoc();

            Phase phase = new FilteredElementCollector(dbDoc).OfClass(typeof(Phase))
                                           .Cast<Phase>().FirstOrDefault(phs=> phs.Name.Contains(phasePattern));

            if (phase == null) return null;

            return this.revitElementsCollector.collectElements().Where(el => el.CreatedPhaseId == phase.Id).ToList();
        }

    }
}
