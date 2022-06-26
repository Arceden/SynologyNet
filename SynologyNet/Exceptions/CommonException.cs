namespace SynologyNet.Exceptions
{
    internal class CommonException : SynologyException
    {
        internal CommonException()
        { }

        internal CommonException(string message) : base(message)
        { }
    }
}
