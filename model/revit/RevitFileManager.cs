using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ReuseSchemeTool.model.revit
{
    public static class RevitFileManager
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


                if (revitTransaction != null)
                {
                    // Close and Dispose Transaction
                    revitTransaction.Commit();
                    revitTransaction.Dispose();
                }

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


        public static void exportRevitViewToPDF(Autodesk.Revit.UI.UIDocument uiDoc, Autodesk.Revit.DB.View view, string folderPath)
        {

            Transaction revitTransaction = null;
            Autodesk.Revit.DB.Document dbDoc = view.Document;

            try
            {
                //Start New Transaction
                if (!dbDoc.IsModifiable)
                {
                    revitTransaction = new Transaction(dbDoc, "Export View as PDF");
                    revitTransaction.Start();
                }

                PDFExportOptions pdfExportOptions = new PDFExportOptions
                {
                    Combine = true,
                    FileName = view.Name
                };

                List<ElementId> viewIds = new List<ElementId> {view.Id};

                dbDoc.Export(folderPath, viewIds, pdfExportOptions);


                if (revitTransaction != null)
                {
                    // Close and Dispose Transaction
                    revitTransaction.Commit();
                    revitTransaction.Dispose();
                }

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



        public static List<Autodesk.Revit.DB.Family> loadEmbeddedRevitFamilies(Autodesk.Revit.DB.Document dbDoc,string embedFolderPath)
        {
            Transaction revitTransaction = null;

            Autodesk.Revit.DB.Family embeddedRevitFamily;
            List<Autodesk.Revit.DB.Family> embeddedRevitFamilies = new List<Autodesk.Revit.DB.Family>();

            try
            {
                //Start New Transaction
                if (!dbDoc.IsModifiable)
                {
                    revitTransaction = new Transaction(dbDoc, "Load Embedded Revit Family Files");
                    revitTransaction.Start();
                }

                // Get the current assembly
                Assembly assembly = Assembly.GetExecutingAssembly();

                // Get all embedded resource names
                string[] resourceNames = assembly.GetManifestResourceNames();

                // Filter resource names by the specified folder
                List<string> embedRevitFamilyFilePaths = resourceNames.Where(name => name.StartsWith(embedFolderPath)).ToList();

                //Load Revit Families
                foreach (string fPath in embedRevitFamilyFilePaths)
                {
                    Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(fPath);
                    if (stream == null) break;

                    // Create a temporary file
                    string[] splitFilePath = fPath.Split('.');
                    string fileName = splitFilePath[splitFilePath.Length - 2] + "." + splitFilePath.Last();
                    string tempFilePath = Path.Combine(Path.GetTempPath(), fileName);

                    File.WriteAllBytes(tempFilePath, readFully(stream));

                    bool success = dbDoc.LoadFamily(tempFilePath, out embeddedRevitFamily);

                    embeddedRevitFamilies.Add(embeddedRevitFamily);

                }

                if (revitTransaction != null)
                {
                    // Close and Dispose Transaction
                    revitTransaction.Commit();
                    revitTransaction.Dispose();
                }

                return embeddedRevitFamilies;

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

            return null;
        }


        // Helper method to read the stream fully
        private static byte[] readFully(Stream input)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                input.CopyTo(ms);
                return ms.ToArray();
            }
        }


    }
}
