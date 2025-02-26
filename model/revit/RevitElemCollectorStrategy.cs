using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReuseSchemeTool.model.revit
{
    public abstract class RevitElemCollectorStrategy : RevitElemCollectorInterface
    {
        // ATTRIBUTES
        protected Autodesk.Revit.DB.Document dbDoc;

        // CONSTRUCTORS
        public RevitElemCollectorStrategy(Autodesk.Revit.DB.Document dbDoc) { }

        // METHODS
        public abstract List<Element> collectElements();

        public Document getDBDocument() { return dbDoc; }

    }
}
