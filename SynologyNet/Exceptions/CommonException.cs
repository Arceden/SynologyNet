using System;

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
