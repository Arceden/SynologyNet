using System;

namespace SynologyNet.Exceptions
{
    internal class AuthenticationException : Exception
    {
        internal AuthenticationException()
        { }

        internal AuthenticationException(string message) : base(message)
        { }
    }
}
