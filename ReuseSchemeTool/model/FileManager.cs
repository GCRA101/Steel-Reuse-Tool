using Autodesk.Revit.DB;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace ReuseSchemeTool.model
{

    public static class FileManager
    {

    //METHODS
        public static string setDatedFolderPath(string folderPath, string subFolderName)
            {
                DateTime dateObj = DateTime.Now;
                string datedFolderPath = "";

                //Add current time and date in front of subfolder name
                datedFolderPath = folderPath + "\\" + dateObj.Year.ToString() + dateObj.Month.ToString("D2") +
                    dateObj.Day.ToString("D2") + dateObj.Hour.ToString() + dateObj.Minute.ToString() + "_" + subFolderName;

                return datedFolderPath;
            }

        public static string setDatedFilePath(string folderPath, string fileName)
        {
            DateTime dateObj = DateTime.Now;
            string datedFilePath = "";

            // If the input directory doesn't exist, create one.
            if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);

            // Add current time and date in front of the fileName.
            datedFilePath = folderPath + "\\" + dateObj.Year.ToString() + dateObj.Month.ToString("D2") +
                dateObj.Day.ToString("D2") + dateObj.Hour.ToString() + dateObj.Minute.ToString() + "_" + fileName;

            return datedFilePath;
        }


        public static string setNewFilePath(string oldFilePath, string acronym)
        {
            string newFilePath;
            DateTime dateObj = DateTime.Now;

            char[] sep = { '/', '\\', '/' };

            /* Add Label in front of file name containing info about current date and iteration number.
               File gets saved in the same folder of the original */
            string[] parts = oldFilePath.Split(sep, StringSplitOptions.None);
            string lastPart = parts.Last();
            newFilePath = oldFilePath.Remove(oldFilePath.LastIndexOf(lastPart)) + acronym +
                          dateObj.Year.ToString() + dateObj.Month.ToString("D2") + dateObj.Day.ToString("D2") + "_" +
                          dateObj.Hour.ToString("D2") + dateObj.Minute.ToString("D2") + "_" + lastPart;

            return newFilePath;
        }

        public static string setNewFilePath(string oldFilePath, string acronym, int iterNum)
        {
            string newFilePath;
            DateTime dateObj = DateTime.Now;

            char[] sep = { '/', '\\', '/' };

            /* Add Label in front of file name containing info about current date and iteration number.
               File gets saved in the same folder of the original */
            string[] parts = oldFilePath.Split(sep, StringSplitOptions.None);
            string lastPart = parts.Last();
            newFilePath = oldFilePath.Remove(oldFilePath.LastIndexOf(lastPart)) + acronym +
                          dateObj.Year.ToString() + dateObj.Month.ToString("D2") + dateObj.Day.ToString("D2") + "_" +
                          dateObj.Hour.ToString("D2") + dateObj.Minute.ToString("D2") + "_" + "Iteration_" +
                          iterNum.ToString() + "_" + lastPart;

            return newFilePath;
        }


        public static string setNewFilePath(string oldFilePath, string destinationFolderPath, string acronym, int iterNum)
        {
            string newFilePath;
            DateTime dateObj = DateTime.Now;

            //Add Label in front of file name containing info about current date and iteration number.
            //File gets saved in a different folder than the original

            newFilePath = destinationFolderPath + "\\" + acronym + dateObj.Year.ToString() + dateObj.Month.ToString("D2") +
                dateObj.Day.ToString("D2") + "_" + "Iteration_" + iterNum.ToString();

            return newFilePath;

        }

    }

}