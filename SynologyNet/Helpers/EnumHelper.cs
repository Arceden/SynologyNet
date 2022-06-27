using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace SynologyNet
{
    public static class EnumHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        public static string GetDisplayName(this Enum enumValue)
        {
            return enumValue
                .GetType()
                .GetMember(enumValue.ToString())
                .First()
                .GetCustomAttribute<DisplayAttribute>()
                .GetName();
        }

        /// <summary>
        /// Get EnumMember value as string
        /// </summary>
        /// <param name="enumValue">Enum with the EnumMember Attribute</param>
        /// <returns>Value as string</returns>
        public static string GetValue(this Enum enumValue)
        {
            return enumValue
                .GetType()
                .GetMember(enumValue.ToString())
                .FirstOrDefault()
                ?.GetCustomAttribute<EnumMemberAttribute>(false)
                ?.Value;
        }
    }
}
