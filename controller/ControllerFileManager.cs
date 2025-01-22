using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace ReuseSchemeTool.controller
{
    public class ControllerFileManager
    {

        // METHODS
        public string getFilePath(OpenFileDialog ofd, String dialogTitle, String filter)
        {
            //Initialize the fileName string variable
            string fileName = null;

            //Run the OpenFileDialog to get the File path from the user
            ofd.Title = dialogTitle;
            ofd.InitialDirectory="C:\\";
            ofd.Multiselect = false;
            ofd.Filter = filter;

            DialogResult dialogResult= ofd.ShowDialog();

            if (dialogResult==System.Windows.Forms.DialogResult.OK)
            {
                fileName=ofd.FileName;
            }

            return fileName;

        }

        public string getDocText(Document doc)
        {
            // Get the File Path of the input Document class instance
            string resourceName = FilePathRetriever.getPath(doc);

            // Get the stream for the embedded resource
            Stream stream;
            stream= Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName);

            if (stream == null) {
                throw new FileNotFoundException("The specified resource was not found.", resourceName);
            }

            // Return the text content from the stream
            StreamReader streamReader = new StreamReader(stream);
            return streamReader.ReadToEnd();
        }










    }
}
