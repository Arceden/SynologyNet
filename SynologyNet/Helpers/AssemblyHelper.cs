using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SynologyNet.Helpers
{
    internal class AssemblyHelper
    {
        /// <summary>
        /// Get list of methods using the specified custom attribute type
        /// </summary>
        /// <param name="attributeType">Attribute to search for</param>
        /// <returns>List of MethodInfo objects utilizing the specified Attribute</returns>
        internal static IEnumerable<MethodInfo> GetMethodsWithCustomAttributes(Type attributeType)
        {
            Assembly assembly = typeof(Synology).Assembly;

            return assembly.GetTypes()
                .SelectMany(t => t.GetMethods())
                .Where(m => m.GetCustomAttributes(attributeType, false).Length > 0)
                .ToArray();
        }
    }
}
