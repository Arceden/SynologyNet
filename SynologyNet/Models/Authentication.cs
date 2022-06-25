using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
