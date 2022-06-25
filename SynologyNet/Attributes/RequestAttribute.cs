using System;

namespace SynologyNet.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class RequestAttribute : Attribute
    {
        public virtual string Api { get; set; }
        public virtual string Path { get; set; }
        public virtual string Method { get; set; } = "query";
        public virtual string Query { get; set; }
        public virtual int Version { get; set; } = 1;
        public virtual bool RequiresAuthentication { get; set; } = false;
    }
}
