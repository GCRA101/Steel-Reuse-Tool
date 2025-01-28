using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReuseSchemeTool.model.revit
{
    public class ViewportLocationOnSheet
    {
        /* ATTRIBUTES */
        public SheetColumn column { get; set; }
        public SheetRow row { get; set; }

        /* CONSTRUCTOR */
        public ViewportLocationOnSheet(SheetColumn column, SheetRow row)
        {
            this.column= column;
            this.row= row;
        }
    }
}
