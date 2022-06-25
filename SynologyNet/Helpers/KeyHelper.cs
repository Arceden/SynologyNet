using SynologyNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynologyNet.Helpers
{
    internal class KeyHelper
    {
        private const string DefaultSession = "general";
        public static Dictionary<string, Authentication> Sessions { get; } = new Dictionary<string, Authentication>();

        public static void AddSession(string sid, string session = DefaultSession)
            => Sessions.Add(session ?? DefaultSession, new Authentication(sid));

        public static Authentication GetSession(string session = DefaultSession)
            => Sessions[session ?? DefaultSession];

        public static void ClearSession(string session = DefaultSession)
            => Sessions.Remove(session ?? DefaultSession);

        public static bool HasSession(string session = DefaultSession)
            => Sessions.ContainsKey(session ?? DefaultSession);
    }
}
