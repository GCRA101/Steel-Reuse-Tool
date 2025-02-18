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

        public static void buildViewPort(Autodesk.Revit.DB.View view, ViewportLocationOnSheet location, ViewportSizeOnSheet size)
        {
            if (viewSheet == null) { return; }

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
            XYZ viewportCenter = new XYZ(viewSheet.Outline.Min.U + viewportOffsetX_ft + viewportWidth_ft / 2,
                                         viewSheet.Outline.Max.V - viewportOffsetY_ft - viewportHeight_ft / 2,0);

            // Create the viewport
            Viewport viewport = Viewport.Create(viewSheet.Document, viewSheet.Id, view.Id, viewportCenter);

            // Adjust the scale of the 3D view to fit the model
            BoundingBoxXYZ boundingBox = view.get_BoundingBox(null);
            double modelWidth_ft = boundingBox.Max.X - boundingBox.Min.X;
            double modelHeight_ft = boundingBox.Max.Y - boundingBox.Min.Y;

            double scaleX = viewportWidth_ft / modelWidth_ft;
            double scaleY = viewportHeight_ft / modelHeight_ft;
            double scale = Math.Min(scaleX, scaleY);

            view.Scale = (int)(1 / scale);


            //// Adjust the crop box of the view
            //BoundingBoxXYZ cropBox = view.CropBox;

            //double cropBoxWidth_ft = cropBox.Max.X - cropBox.Min.X;
            //double cropBoxHeight_ft = cropBox.Max.Y - cropBox.Min.Y;

            //// Convert from feet to millimeters
            //double cropBoxWidth_mm = UnitUtils.ConvertFromInternalUnits(cropBoxWidth_ft, UnitTypeId.Millimeters);
            //double cropBoxHeight_mm = UnitUtils.ConvertFromInternalUnits(cropBoxHeight_ft, UnitTypeId.Millimeters);

            //double deltaX = (((int)size.width) * ((outlineWidth_ft / deltaUNum)/cropBoxWidth_ft) * cropBoxWidth_ft - cropBoxWidth_ft)/ 2;
            //double deltaY = (((int)size.height) * ((outlineHeight_ft / deltaVNum)/cropBoxHeight_ft) * cropBoxHeight_ft - cropBoxHeight_ft )/ 2;

            //cropBox.Max = new XYZ(cropBox.Max.X + deltaX, cropBox.Max.Y + deltaY, cropBox.Max.Z); // Increase size
            //cropBox.Min = new XYZ(cropBox.Min.X - deltaX, cropBox.Min.Y - deltaY, cropBox.Min.Z); // Decrease size
            
            //view.CropBox = cropBox;



            ////double x = viewSheet.Outline.Max.U-(viewSheet.Outline.Max.U / deltaUNum * ((int)location.column+1));
            //double x = viewSheet.Outline.Max.U / deltaUNum * ((int)location.column);
            //double y = viewSheet.Outline.Max.V-(viewSheet.Outline.Max.V / deltaVNum * ((int)location.row));

            //XYZ point = new XYZ(x, y, 0);

            //Viewport viewport = Viewport.Create(viewSheet.Document, viewSheet.Id, view.Id, point);


            //// TITLEBLOCK DIMENSIONS

            //// Get the width and height parameters
            //double ttlbkWidth = titleBlock.get_Parameter(BuiltInParameter.SHEET_WIDTH).AsDouble();
            //double ttlbkHeight = titleBlock.get_Parameter(BuiltInParameter.SHEET_HEIGHT).AsDouble();
            
            //// Convert from feet to millimeters (if needed)
            //double ttlbkWidth_mm = UnitUtils.ConvertFromInternalUnits(ttlbkWidth, UnitTypeId.Millimeters);
            //double ttlbkHeight_mm = UnitUtils.ConvertFromInternalUnits(ttlbkHeight, UnitTypeId.Millimeters);


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
