/* IMPORT LIBRARIES */
using System;
// Libraries for Revit
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using System.IO;
using System.Reflection;

namespace ReuseSchemeTool.view.revit_plugin
{
    [Transaction(TransactionMode.Manual)]
    public class RibbonUI : IExternalApplication
    {
        /* ATTRIBUTES */
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
                string tabName = "BH Plugins";
                string panelName = "Reuse Toolkit";

                //1. Create new RibbonTab
                //application.CreateRibbonTab(tabName);
                //2. Create new RibbonTab Panel
                ribbonPanel = RibbonTabPanelFactory.getInstance().create(application, tabName, panelName);
                //3. Buildup Inputs for RibbonItemFactory
                String imagePath = "ReuseSchemeTool.images.AppLogo16x16.png";
                String largeImagePath = "ReuseSchemeTool.images.AppLogo32x32.png";
                String toolTipImagePath = "ReuseSchemeTool.images.AppLogo.png";
                String toolTipText = "Reuse Scheme Tool";
                String longDescriptionFilePath = "ReuseSchemeTool.text_files.AppLongDescription.txt";
                String longDescription = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream(longDescriptionFilePath)).ReadToEnd();
                String assemblyFullPath = Assembly.GetExecutingAssembly().Location;
                String className = "ReuseSchemeTool.view.revit_plugin.Command";
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
