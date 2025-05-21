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
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using CSiAPIv1;
using ETABSv1;
using ETABS_Base_Reactions_Exchange.model.Model;
using ETABS_Base_Reactions_Exchange.controller.BRE_Controller;
using System.Threading;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.ComponentModel;



public class ETABSConnector : ETABSConnection
{

    // ATTRIBUTES ***********************************************************************************'

    // Private Instance - SINGLETON PATTERN
    private static ETABSConnector instance;
    // ETABS OAPI Interoperability Variables
    private ETABSv1.cHelper helperObject;   // Helper Class Object Variable                  'O(1)
    private ETABSv1.cOAPI ETABSApp;         // ETABS Application Object Variable             'O(1)
    // Utility Variables
    private int ret;                                                                    // O(1)
    const bool etabsVisibility = false;                                                  // O(1)


    // PRIVATE CONSTRUCTOR **********************************************************************************'
    private ETABSConnector()
    {
    }


    // METHODS **************************************************************************************'

    // GETINSTANCE() METHOD - SINGLETON PATTERN
    public static ETABSConnector getInstance()
    {
        if (instance == null)
            instance = new ETABSConnector();
        return instance;
    }


    // INITIALIZEETABS() METHOD
    public void initialize()
    {
        // Helper Class Object Variable
        helperObject = new ETABSv1.Helper();                                                                            // O(1)
        // ETABS Application Object Variable                                                                           'O(1)
        ETABSApp = null;                                                                                           // O(1)
        ETABSApp = helperObject.CreateObjectProgID("CSI.ETABS.API.ETABSObject");                                      // O(1)
    }


    // DISPOSEETABS() METHOD
    public void dispose()
    {
        // Close the ETABS Application
        ETABSApp.ApplicationExit(false); // O(1)
        // Release Memory
        ETABSApp = null;              // O(1)
    }


    // SETETABSVISIBILITY() METHOD
    public void setEtabsVisibility(bool @bool)
    {
        if (@bool == false)
            ret = ETABSApp.Hide();
        else
            ret = ETABSApp.Unhide();
    }


    // Getters

    // GET ETABS APP
    public ETABSv1.cOAPI getEtabsApp()
    {
        return this.ETABSApp;
    }
}
