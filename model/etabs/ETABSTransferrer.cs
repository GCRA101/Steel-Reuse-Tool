using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

public abstract class ETABSTransferrer
{

    // ATTRIBUTES ***********************************************************************************'

    // Behaviour Object
    protected DataTransfer transferMode;
    // ETABS Models
    protected ETABSv1.cSapModel sourceEtabsModel;  // ETABS Model Object Variable              'O(1)
    protected ETABSv1.cSapModel targetEtabsModel;  // Target ETABS Model Object Variable       'O(1)
    // Source and Target FileNames
    protected string sourceFileName, targetFileName;                                          // O(1)


    // CONSTRUCTORS **********************************************************************************'
    // Overloaded
    public ETABSTransferrer(ETABSv1.cSapModel sourceEtabsModel, ETABSv1.cSapModel targetEtabsModel)
    {
        this.sourceEtabsModel = sourceEtabsModel;
        this.targetEtabsModel = targetEtabsModel;
    }


    // METHODS ***************************************************************************************'

    // Setters
    public void setSourceEtabsModel(ETABSv1.cSapModel sourceEtabsModel)
    {
        this.sourceEtabsModel = sourceEtabsModel;
    }
    public void setTargetEtabsModel(ETABSv1.cSapModel targetEtabsModel)
    {
        this.targetEtabsModel = targetEtabsModel;
    }

    // Getters
    public ETABSv1.cSapModel getSourceEtabsModel()
    {
        return this.sourceEtabsModel;
    }
    public ETABSv1.cSapModel getTargetEtabsModel()
    {
        return this.targetEtabsModel;
    }


    // SETNEWFILEPATH() METHOD
    protected string setNewFilePath(string filePath)
    {
        string newFilePath;
        DateTime dateObj = DateTime.Today;

        char[] sep = new[] { "/", @"\", "//" };

        {
            var withBlock = dateObj;
            newFilePath = filePath.Remove(filePath.IndexOf(filePath.Split(sep).Last())) + "BRE" + withBlock.Year.ToString() + withBlock.Month.ToString("D2") + withBlock.Day.ToString("D2") + "_" + filePath.Split(sep).Last();
        }

        return newFilePath;
    }


    // TRANSFER METHOD
    public virtual void transfer(bool overwrite = false)
    {
    }
}
