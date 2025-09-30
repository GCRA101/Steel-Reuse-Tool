using Autodesk.Revit.Exceptions;
using ReuseSchemeTool.controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ReuseSchemeTool.controller
{
    public static class FilePathRetriever
    {
        public static string getPath(Document doc)
        {
            //Return a pre-set file path depending on the value of the input Document enumeration
            switch (doc)
            {
                case Document.INSPECTORTOOL_DESCRIPTION:
                    return "ReuseSchemeTool.model.text_files.InspectorTool_LongDescription.txt";
                case Document.SCHEMETOOL_DESCRIPTION:
                    return "ReuseSchemeTool.model.text_files.SchemingTool_LongDescription.txt";
                default:
                    return null;
            }
        }
    }
}
