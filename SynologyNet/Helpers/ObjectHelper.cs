using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace SynologyNet.Helpers;

static class ObjectHelper
{
    public static string? GetEnumMemberName(this object? obj)
        => obj?
        .GetType()
        .GetMember(obj.ToString())
        .FirstOrDefault()?
        .GetCustomAttribute<EnumMemberAttribute>(false)?.Value;
}

