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

namespace model
{
    public class LoadCaseStaticLinear : LoadCaseStatic
    {

        // ATTRIBUTES
        // All inherited from super-classes

        // CONSTRUCTORS
        // Default
        public LoadCaseStaticLinear() : base()
        {
        }
        // Overloaded
        public LoadCaseStaticLinear(string loadCaseName, string initialCaseName, int numLoads, string[] loadTypes, string[] loadNames, double[] sfs) : base(loadCaseName, initialCaseName, numLoads, loadTypes, loadNames, sfs)
        {
        }
    }
}
