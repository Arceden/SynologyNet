using System;

namespace SynologyNet.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class SynologyRepositoryAttribute : Attribute
    {
        public virtual string DefaultApi { get; set; } = "SYNO.API.Info";
        public virtual string DefaultPath { get; set; } = null;
        public virtual bool RequiresAuthentication { get; set; } = false;
    }
}
