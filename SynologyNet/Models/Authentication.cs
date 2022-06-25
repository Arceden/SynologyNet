using System;

namespace SynologyNet.Models
{
    internal class Authentication
    {
        public string Sid { get; }
        public DateTime Aquired { get; } = DateTime.Now;

        public Authentication(string sid)
           => Sid = sid;
    }
}
