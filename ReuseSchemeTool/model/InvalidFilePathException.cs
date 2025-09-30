using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReuseSchemeTool.model
{
    public class InvalidFilePathException: Exception
    {
        public InvalidFilePathException(string message) :base(message) { }
    }
}
