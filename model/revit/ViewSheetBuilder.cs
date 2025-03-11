using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace ReuseSchemeTool.model.revit
{
    public static class ViewSheetBuilder
    {
        /* ATTRIBUTES */
        private static Autodesk.Revit.DB.ViewSheet viewSheet=null;
        private static Autodesk.Revit.DB.Element titleBlock = null;

        /* METHODS */
        public static void initialise(ViewSheet placeholder, string number, string title)
        {
            viewSheet = placeholder;
            viewSheet.SheetNumber = number;
            viewSheet.Name = title;
        }

        public static void buildTitleBlock(string titleBlockTypeName)
        {
            if (viewSheet == null) { return; }

            if (searchTitleBlockByName(titleBlockTypeName)!=null) 
            {
                Autodesk.Revit.DB.Element titleBlock = searchTitleBlockByName(titleBlockTypeName);
                viewSheet.ConvertToRealSheet(titleBlock.Id);
            }

        }

        public static void buildTitleBlock(ElementId titleBlockId)
        {
            if (viewSheet == null) { return; }

            viewSheet.ConvertToRealSheet(titleBlockId);
        }

        public static void buildViewPort(Autodesk.Revit.DB.View view, ViewportLocationOnSheet location, ViewportSizeOnSheet size, Boolean duplicateView=true)
        {
            if (viewSheet == null) { return; }

            if (duplicateView) view = (Autodesk.Revit.DB.View)view.Document.GetElement(view.Duplicate(ViewDuplicateOption.Duplicate));


            int deltaUNum = Enum.GetValues(typeof(SheetColumn)).Length;
            int deltaVNum = Enum.GetValues(typeof(SheetRow)).Length;

            // VIEWSHEET OUTLINE DIMENSIONS

            // Calculate the width and height in feet
            double sheetWidth_ft = viewSheet.Outline.Max.U - viewSheet.Outline.Min.U;
            double sheetHeight_ft = viewSheet.Outline.Max.V - viewSheet.Outline.Min.V;

            // Convert from feet to millimeters
            double sheetWidth_mm = UnitUtils.ConvertFromInternalUnits(sheetWidth_ft, UnitTypeId.Millimeters);
            double sheetHeight_mm = UnitUtils.ConvertFromInternalUnits(sheetHeight_ft, UnitTypeId.Millimeters);

            double viewportWidth_ft = sheetWidth_ft/deltaUNum * ((int)size.width);
            double viewportHeight_ft = sheetHeight_ft / deltaVNum * ((int)size.height);

            double viewportOffsetX_ft = sheetWidth_ft / deltaUNum * ((int)location.column);
            double viewportOffsetY_ft = sheetHeight_ft / deltaVNum * ((int)location.row);

            // Calculate the center point of the viewport
            XYZ viewportCenter = new XYZ(viewSheet.Outline.Min.U + viewportOffsetX_ft,
                                         viewSheet.Outline.Max.V - viewportOffsetY_ft,0);

            // Adjust the scale of the 3D view to fit the model
            BoundingBoxXYZ boundingBox = view.get_BoundingBox(null);
            double modelWidth_ft = boundingBox.Max.X - boundingBox.Min.X;
            double modelHeight_ft = boundingBox.Max.Y - boundingBox.Min.Y;

            double scaleX = viewportWidth_ft / modelWidth_ft;
            double scaleY = viewportHeight_ft / modelHeight_ft;
            double scale = Math.Min(scaleX, scaleY);

            view.Scale = (int)(1 / scale);

            // Create the viewport
            Viewport viewport = Viewport.Create(viewSheet.Document, viewSheet.Id, view.Id, viewportCenter);

            double viewportWidth = viewport.GetBoxOutline().MaximumPoint.X - viewport.GetBoxOutline().MinimumPoint.X;
            double viewportHeight = viewport.GetBoxOutline().MaximumPoint.Y - viewport.GetBoxOutline().MinimumPoint.Y;

            XYZ centrePoint = viewport.GetBoxCenter();
            viewportWidth = viewport.GetBoxOutline().MaximumPoint.X - viewport.GetBoxOutline().MinimumPoint.X;
            viewportHeight = viewport.GetBoxOutline().MaximumPoint.Y - viewport.GetBoxOutline().MinimumPoint.Y;

            XYZ newCenterPoint = new XYZ(viewSheet.Outline.Min.U + viewportOffsetX_ft + viewportWidth / 2,
                    viewSheet.Outline.Max.V - viewportOffsetY_ft - viewportHeight / 2, 0);

            viewport.SetBoxCenter(newCenterPoint);

        }

        public static void buildViewPort(Autodesk.Revit.DB.View view, ViewportLocationOnSheet location, Boolean duplicateView = true)
        {
            if (viewSheet == null) { return; }

            if (duplicateView) view = (Autodesk.Revit.DB.View)view.Document.GetElement(view.Duplicate(ViewDuplicateOption.Duplicate));

            int deltaUNum = Enum.GetValues(typeof(SheetColumn)).Length;
            int deltaVNum = Enum.GetValues(typeof(SheetRow)).Length;

            // VIEWSHEET OUTLINE DIMENSIONS

            // Calculate the width and height in feet
            double sheetWidth_ft = viewSheet.Outline.Max.U - viewSheet.Outline.Min.U;
            double sheetHeight_ft = viewSheet.Outline.Max.V - viewSheet.Outline.Min.V;

            double viewportWidth_ft, viewportHeight_ft;

            double viewportOffsetX_ft = sheetWidth_ft / deltaUNum * ((int)location.column);
            double viewportOffsetY_ft = sheetHeight_ft / deltaVNum * ((int)location.row);

            // Calculate the center point of the viewport
            XYZ viewportCenter = new XYZ(viewSheet.Outline.Min.U + viewportOffsetX_ft,
                                         viewSheet.Outline.Max.V - viewportOffsetY_ft, 0);

            // Create the viewport
            Viewport viewport = Viewport.Create(viewSheet.Document, viewSheet.Id, view.Id, viewportCenter);

            XYZ centrePoint = viewport.GetBoxCenter();
            double viewportWidth=viewport.GetBoxOutline().MaximumPoint.X - viewport.GetBoxOutline().MinimumPoint.X;
            double viewportHeight = viewport.GetBoxOutline().MaximumPoint.Y - viewport.GetBoxOutline().MinimumPoint.Y;

            XYZ newCenterPoint = new XYZ(centrePoint.X + viewportWidth / 2, centrePoint.Y - viewportHeight / 2, centrePoint.Z);

            viewport.SetBoxCenter(newCenterPoint);

        }


        public static void buildViewPort(Autodesk.Revit.DB.View view, XYZ centrePoint, Boolean duplicateView = true)
        {
            if (viewSheet == null) { return; }

            if (duplicateView) view = (Autodesk.Revit.DB.View)view.Document.GetElement(view.Duplicate(ViewDuplicateOption.Duplicate));

            // Create the viewport
            Viewport viewport = Viewport.Create(viewSheet.Document, viewSheet.Id, view.Id, centrePoint);

        }


        public static void placeImageOnSheet(Document dbDoc, string imagePath, XYZ position)
        {

            // Load the image into the document
            ImageTypeOptions imageTypeOptions = new ImageTypeOptions(imagePath,false,ImageTypeSource.Import);

            ImageType imageType = ImageType.Create(dbDoc, imageTypeOptions);

            ImagePlacementOptions imagePlacementOptions = new ImagePlacementOptions();
            imagePlacementOptions.Location = position;

            // Create an instance of the image on the sheet
            ImageInstance imageInstance = ImageInstance.Create(dbDoc, viewSheet, imageType.Id, imagePlacementOptions);

        }



        private static Element searchTitleBlockByName(string titleBlockTypeName)
        {
            return new FilteredElementCollector(viewSheet.Document)
                    .WhereElementIsElementType()
                    .OfCategory(BuiltInCategory.OST_TitleBlocks)
                    .ToList()
                    .First(tb => tb.Name == titleBlockTypeName);
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
