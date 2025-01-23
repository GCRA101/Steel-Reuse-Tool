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


namespace ReuseSchemeTool.view.revit_plugin
{
    /* COMMAND CLASS ************************************************************ */

    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        /*IMPLEMENTED METHODS*/

        // Execute Method from IExternalCommand Interface
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            try
            {
                //1. Initialize Controller
                RST_Controller controller = new RST_Controller(commandData.Application);
                controller.initialize();
                //2. Success
                return Result.Succeeded;
            }
            catch (Exception e)
            {
                return Result.Failed;
            }
        }
    }
}
