using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReuseSchemeTool.model
{
    public class MissingInputsException : Exception
    {
        public MissingInputsException(string message) : base(message) { }

    }
}
