using System;

namespace SynologyNet.Exceptions
{
    internal class SynologyException : Exception
    {
        internal SynologyException()
        { }

        internal SynologyException(string message) : base(message)
        { }
    }
}
