using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReuseSchemeTool.model.revit
{
    public class ViewportSizeOnSheet
    {
        /* ATTRIBUTES */
        public SheetColumn width { get; set; }
        public SheetRow height { get; set; }

        /* CONSTRUCTOR */
        public ViewportSizeOnSheet(SheetColumn width, SheetRow height)
        {
            this.width= width;
            this.height= height;
        }

    }
}
