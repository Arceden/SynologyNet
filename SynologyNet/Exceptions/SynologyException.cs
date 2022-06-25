using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynologyNet.Exceptions
{
    internal class SynologyException: Exception
    {
        internal SynologyException()
        { }

        internal SynologyException(string message) : base(message)
        { }
    }
}
