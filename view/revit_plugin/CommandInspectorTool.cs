/* IMPORT LIBRARIES */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Libraries for UI Buttons/Panels
using System.Reflection;
using System.Xaml;
// Libraries for Revit
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB.Events;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
// Other Libraries
using System.Linq.Expressions;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Windows.Media;
using System.Xml.Linq;
using System.Runtime.CompilerServices;
using Autodesk.Revit.Creation;
using System.Security.Cryptography;
using ReuseSchemeTool.controller;
using ReuseSchemeTool.model;


namespace ReuseSchemeTool.view.revit_plugin
{
    /* COMMAND CLASS ************************************************************ */

    [Transaction(TransactionMode.Manual)]
    public class CommandInspectorTool : IExternalCommand
    {
        /*IMPLEMENTED METHODS*/

        // Execute Method from IExternalCommand Interface
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {

            // Initialize Controller
            RST_Controller controller = new RST_Controller(commandData.Application);

            Transaction revitTransaction = new Transaction(commandData.Application.ActiveUIDocument.Document, "Reuse Rating");

            try
            {
                //controller.initialize();

                //Show the SplashScreen and the AboutBox
                controller.initialize(Tool.INSPECTOR);

                if (controller.view.aboutBox.ShowDialog() == DialogResult.OK) {
                    controller.soundManager.play(Sound.CLICKBUTTON);

                    revitTransaction.Start();

                    controller.model.initialize(commandData.Application);
                    controller.run(Tool.INSPECTOR);
                    

                    // Close and Dispose Transaction
                    revitTransaction.Commit();
                    revitTransaction.Dispose();

                    while (controller.model.revitViews.Count > 0 )
                    {
                        commandData.Application.ActiveUIDocument.ActiveView = controller.model.revitViews.Dequeue();
                    }

                    controller.terminate(Tool.INSPECTOR);
                }

                // Success
                return Result.Succeeded;
            }

            catch (MissingInputsException ex1) {
                 controller.missingInputsHandler.execute(ex1);
                 return Result.Failed;

            }
            catch (Exception e)
            {
                 if (revitTransaction != null) {

                    revitTransaction.RollBack();

                    TaskDialog.Show("ERROR MESSAGES", e.Message);

                    // Close and Dispose Transaction
                    revitTransaction.Commit();
                    revitTransaction.Dispose();
                 }

                message = e.Message;
                return Result.Failed;
            }
        }

    }
}

