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
                // Inspector Tool
                String inspector_imagePath = "ReuseSchemeTool.view.images.InspectorTool_AppLogo16x16.png";
                String inspector_largeImagePath = "ReuseSchemeTool.view.images.InspectorTool_AppLogo32x32.png";
                String inspector_toolTipImagePath = "ReuseSchemeTool.view.images.InspectorTool_AppLogo.png";
                String inspector_toolTipText = "Reuse Inspector Tool";
                String inspector_longDescriptionFilePath = "ReuseSchemeTool.model.text_files.InspectorTool_LongDescription.txt";
                String inspector_longDescription = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream(inspector_longDescriptionFilePath)).ReadToEnd();
                String inspector_className = "ReuseSchemeTool.view.revit_plugin.CommandInspectorTool";
                // Scheming Tool
                String scheming_imagePath = "ReuseSchemeTool.view.images.SchemingTool_AppLogo16x16.png";
                String scheming_largeImagePath = "ReuseSchemeTool.view.images.SchemingTool_AppLogo32x32.png";
                String scheming_toolTipImagePath = "ReuseSchemeTool.view.images.SchemingTool_AppLogo.png";
                String scheming_toolTipText = "Reuse Scheme Tool";
                String scheming_longDescriptionFilePath = "ReuseSchemeTool.model.text_files.SchemingTool_LongDescription.txt";
                String scheming_longDescription = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream(scheming_longDescriptionFilePath)).ReadToEnd();
                String scheming_className = "ReuseSchemeTool.view.revit_plugin.CommandSchemeTool";

                String assemblyFullPath = Assembly.GetExecutingAssembly().Location;

                //4. Create RibbonItems (PushButtons)
                // Inspector Tool
                RibbonItemFactory.getInstance().create(ribbonPanel, RibbonItemType.PushButton, "Inspector\n Tool", inspector_imagePath,
                                                       inspector_largeImagePath, inspector_toolTipImagePath, inspector_toolTipText, inspector_longDescription, 
                                                       assemblyFullPath, inspector_className);
                // Scheming Tool
                RibbonItemFactory.getInstance().create(ribbonPanel, RibbonItemType.PushButton, "Scheme\n Tool", scheming_imagePath,
                                                       scheming_largeImagePath, scheming_toolTipImagePath, scheming_toolTipText, scheming_longDescription,
                                                       assemblyFullPath, scheming_className);

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
