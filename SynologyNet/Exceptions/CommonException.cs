using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynologyNet.Exceptions
{
    internal class CommonException : Exception
    {
        internal CommonException()
        { }

        internal CommonException(string message) : base(message)
        { }
    }
}
