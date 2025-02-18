using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ReuseSchemeTool.model.revit
{
    public static class FileManager
    {

        public static void exportRevitViewToImage(Autodesk.Revit.UI.UIDocument uiDoc, Autodesk.Revit.DB.View view, string imagePath)
        {

            Transaction revitTransaction = null;
            Autodesk.Revit.DB.Document dbDoc = view.Document;
            uiDoc.ActiveView = view;

            try
            {
                //Start New Transaction
                if (!dbDoc.IsModifiable)
                {
                    revitTransaction = new Transaction(dbDoc, "Export View as Image");
                    revitTransaction.Start();
                }

                ImageExportOptions options = new ImageExportOptions
                {
                    ExportRange = ExportRange.CurrentView,
                    FilePath = imagePath,
                    FitDirection = FitDirectionType.Horizontal,
                    HLRandWFViewsFileType = ImageFileType.PNG,
                    ImageResolution = ImageResolution.DPI_600,
                    ZoomType = ZoomFitType.FitToPage,
                    PixelSize = 4096 // Adjust for higher resolution
                };

                dbDoc.ExportImage(options);

            }
            catch (Exception ex)
            {
                if (revitTransaction != null)
                {

                    revitTransaction.RollBack();

                    TaskDialog.Show("ERROR MESSAGES", ex.Message);

                    // Close and Dispose Transaction
                    revitTransaction.Commit();
                    revitTransaction.Dispose();
                }
            }
        }


    }
}
