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

public class FrameJointForces : NodalForces
{

    // ATTRIBUTES **********************************************************
    private ETABSv1.eItemTypeElm itemTypeElm { get; set; }
    private string[] pointElm { get; set; }



    // CONSTRUCTOR ************************************************************
    // Default Constructor
    public FrameJointForces() : base()
    {
    }
    // Overloaded
    public FrameJointForces(ETABSv1.eItemTypeElm itemTypeElm, int numRes, string[] obj, string[] elm, string[] pointElm, string[] loadCase, string[] stepType, double[] stepNum, double[] f1, double[] f2, double[] f3, double[] m1, double[] m2, double[] m3) : base(numRes, obj, elm, loadCase, stepType, stepNum, f1, f2, f3, m1, m2, m3)
    {
        {
            var withBlock = this;
            withBlock.itemTypeElm = itemTypeElm;
            withBlock.pointElm = pointElm;
        }
    }



    // METHODS ****************************************************************

    // GETTERS and SETTERS *********************

    // Setters
    public void setItemTypeElm(ETABSv1.eItemTypeElm itemTypeElm)
    {
        this.itemTypeElm = itemTypeElm;
    }
    public void setPointElm(string[] pointElm)
    {
        this.pointElm = pointElm;
    }


    // Getters
    public ETABSv1.eItemTypeElm getItemTypeElm()
    {
        return this.itemTypeElm;
    }
    public string[] getPointElm()
    {
        return this.pointElm;
    }
}
