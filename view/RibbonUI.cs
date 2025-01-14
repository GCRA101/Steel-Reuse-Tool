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
                //1. Set up Ribbon Tab and Ribbon Panel reference variables
                string tabName = "BH Plugins";
                string panelName = "Reuse Toolkit";

                // 2. Check if Tab and Panel already exist
                bool tabExists;
                tabExists = application.GetRibbonPanels(tabName).Count != 0 ? true : false;
                RibbonPanel ribbonPanel = application.GetRibbonPanels(tabName).
                          Find(rbPanel => rbPanel.Name == panelName);

                // 3. Create new Ribbon Tab and new Ribbon Panel
                // If the tab doesn't exist, create a new RibbonTab
                if (!tabExists) { application.CreateRibbonTab("BH Plugins"); }
                // If the panel doesn't exist, create new RibbonTab Panel
                if (ribbonPanel == null) { ribbonPanel = RibbonTabPanelFactory.getInstance().create(application, tabName, panelName); }

                // 4. Buildup Inputs for RibbonItemFactory
                String imagePath = "ReuseSchemeTool.AppLogo16x16.png";
                String largeImagePath = "ReuseSchemeTool.AppLogo32x32.png";
                String toolTipImagePath = "ReuseSchemeTool.AppLogo.png";
                String toolTipText = "Reuse Scheme Tool";
                String longDescriptionFilePath = "ReuseSchemeTool.AppLongDescription.txt";
                String longDescription = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream(longDescriptionFilePath)).ReadToEnd();
                String assemblyFullPath = Assembly.GetExecutingAssembly().Location;
                String className = "ReuseSchemeTool.Command";
                // 5. Create RibbonItem (PushButton)
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
