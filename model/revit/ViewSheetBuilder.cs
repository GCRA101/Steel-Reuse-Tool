using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public static void buildViewPort(View view,XYZ locationPoint)
        {
            if (viewSheet == null) { return; }
            Viewport.Create(viewSheet.Document, viewSheet.Id, view.Id, locationPoint);
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
