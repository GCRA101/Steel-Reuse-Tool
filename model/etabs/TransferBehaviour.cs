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

public abstract class TransferBehaviour : DataTransfer
{

    // ATTRIBUTES 
    protected int ret;
    protected ETABSv1.cSapModel sourceEtabsModel, targetEtabsModel;

    // CONSTRUCTOR
    // Overloaded
    public TransferBehaviour(ETABSv1.cSapModel sourceEtabsModel, ETABSv1.cSapModel targetEtabsModel)
    {
        this.sourceEtabsModel = sourceEtabsModel;
        this.targetEtabsModel = targetEtabsModel;
    }

    // METHODS
    public virtual void transfer(bool overwrite = false)
    {
        throw new NotImplementedException();
    }
}
