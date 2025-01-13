/* IMPORT LIBRARIES */
using System;
// Libraries for Revit
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using System.IO;
using System.Reflection;

namespace ReuseSchemeTool.view
{
    [Transaction(TransactionMode.Manual)]
    public class RibbonUI : IExternalApplication
    {
        /* ATTRIBUTES */
        //private String projectFolderPath = System.IO.Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).FullName;
        private String projectFolderPath = "c:\\Users\\galbieri\\OneDrive - Buro Happold\\Structures\\10_Computational\\HOI\\Revit API Plugins\\ReuseSchemeTool\\ReuseSchemeTool\\";

        private RibbonPanel ribbonPanel;


        /* CONSTRUCTOR */
        //Default
        public RibbonUI() {}


        /* METHODS */

        // OnStartup - Implemented from IExternalApplication Interface
        public Result OnStartup(UIControlledApplication application)
        {
            try
            {
                //1. Create new RibbonTab
                application.CreateRibbonTab("BH Plugins");
                //2. Create new RibbonTab Panel
                ribbonPanel = RibbonTabPanelFactory.getInstance().create(application, "BH Plugins", "Reuse Toolkit");
                //3. Buildup Inputs for RibbonItemFactory
                String imagePath = "ReuseSchemeTool.AppLogo64x64.png";
                String largeImagePath = "ReuseSchemeTool.AppLogo96x96.png";
                String toolTipImagePath = "ReuseSchemeTool.AppLogo.png";
                String toolTipText = "Reuse Scheme Tool";
                String longDescriptionFilePath = "ReuseSchemeTool.AppLongDescription.txt";
                String longDescription = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream(longDescriptionFilePath)).ReadToEnd();
                String assemblyFullPath = Assembly.GetExecutingAssembly().Location;
                String className = "ReuseSchemeTool.Command";
                //4. Create RibbonItem (PushButton)
                RibbonItemFactory.getInstance().create(ribbonPanel, RibbonItemType.PushButton, "Reuse Scheme\n Tool", imagePath,
                                                       largeImagePath, toolTipImagePath, toolTipText, longDescription, assemblyFullPath,
                                                       className);
                return Result.Succeeded;
            }
            catch (Exception e)
            {
                return Result.Failed;
            }
        }



        // OnShutdown - Implemented from IExternalApplication Interface
        public Result OnShutdown(UIControlledApplication application)
        {
            try
            {
                return Result.Succeeded;
            }
            catch (Exception e)
            {
                return Result.Failed;
            }
        }
    }


}
