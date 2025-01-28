using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ReuseSchemeTool.model.revit
{
    public static class ViewSheetBuilder
    {
        /* ATTRIBUTES */
        private static Autodesk.Revit.DB.ViewSheet viewSheet=null;

        /* METHODS */
        public static void initialise(ViewSheet placeholder)
        {
            viewSheet = placeholder;
        }

        public static void buildTitleBlock(string titleBlockTypeName)
        {
            if (viewSheet == null) { return; }

            if (searchTitleBlockIdByName(titleBlockTypeName)!=null) 
            {
                viewSheet.ConvertToRealSheet(searchTitleBlockIdByName(titleBlockTypeName));
            }

        }

        public static void buildTitleBlock(ElementId titleBlockId)
        {
            if (viewSheet == null) { return; }

            viewSheet.ConvertToRealSheet(titleBlockId);
        }

        public static void buildViewPort(View view, ViewportLocationOnSheet location, ViewportSizeOnSheet size)
        {
            if (viewSheet == null) { return; }

            int deltaUNum=Enum.GetValues(typeof(SheetColumn)).Length;
            int deltaVNum = Enum.GetValues(typeof(SheetRow)).Length;

            double x = viewSheet.Outline.Max.U / deltaUNum * ((int)location.column+1);
            double y = viewSheet.Outline.Max.V / deltaVNum * ((int)location.row+1);

            XYZ point = new XYZ(x, y, 0);

            Viewport.Create(viewSheet.Document, viewSheet.Id, view.Id, point);
        }

        
        private static ElementId searchTitleBlockIdByName(string titleBlockTypeName)
        {
            return new FilteredElementCollector(viewSheet.Document)
                    .WhereElementIsElementType()
                    .OfCategory(BuiltInCategory.OST_TitleBlocks)
                    .ToList()
                    .First(tb => tb.Name == titleBlockTypeName)
                    .Id;

        }

        public static ViewSheet getViewSheet()
        {

            if (viewSheet == null) { return null; }

            ViewSheet output = viewSheet;

            viewSheet = null;

            return output;
        }



    }
}
