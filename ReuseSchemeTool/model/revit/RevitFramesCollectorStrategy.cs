using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReuseSchemeTool.model.revit
{
    public class RevitFramesCollectorStrategy : RevitElemCollectorStrategy
    {
        // CONSTRUCTORS
        public RevitFramesCollectorStrategy(Autodesk.Revit.DB.Document dbDoc): base(dbDoc) { }

        // METHODS
        public override List<Element> collectElements()
        {
            /* 1. BUILD REVIT COLLECTOR FILTERS */

            // StructuralType Filters
            ElementStructuralTypeFilter filterBeams = new ElementStructuralTypeFilter(Autodesk.Revit.DB.Structure.StructuralType.Beam);
            ElementStructuralTypeFilter filterColumns = new ElementStructuralTypeFilter(Autodesk.Revit.DB.Structure.StructuralType.Column);
            ElementStructuralTypeFilter filterBraces = new ElementStructuralTypeFilter(Autodesk.Revit.DB.Structure.StructuralType.Brace);
            // List of Filters
            List<ElementFilter> filtersList = new List<ElementFilter>() { filterBeams, filterColumns, filterBraces };
            // Logical Or Filter
            LogicalOrFilter filterStrFrames = new LogicalOrFilter(filtersList);

            /* 2. EXTRACT REVIT STRUCTURAL FRAMES*/

            // FilteredElementCollector
            FilteredElementCollector elemCollector = new FilteredElementCollector(this.dbDoc);
            return elemCollector.OfClass(typeof(FamilyInstance))
                                .WherePasses(filterStrFrames)
                                .ToList();
        }
    }
}
