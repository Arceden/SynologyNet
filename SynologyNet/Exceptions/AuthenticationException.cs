using System;

namespace SynologyNet.Exceptions
{
    internal class AuthenticationException : SynologyException
    {
        internal AuthenticationException()
        { }

        internal AuthenticationException(string message) : base(message)
        { }
    }
}
