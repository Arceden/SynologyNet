using SynologyNet.Models.Requests.Filters;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json.Serialization;

namespace SynologyNet.Helpers;

internal static class FilterHelper
{
    /// <summary>
    /// Convert filter options with JsonPropertyName attributes into a dictionary
    /// </summary>
    /// <param name="filter">Filter object</param>
    /// <returns>Dictionary with filtering options</returns>
    public static Dictionary<string, string> ToDictionary(this IFilter filter)
    {
        var dictionary = new Dictionary<string, string>();
        var properties = filter.GetType().GetProperties();

        foreach (var property in properties)
        {
            var value = property.GetValue(filter, null);
            var key = property.GetCustomAttribute<JsonPropertyNameAttribute>()?.Name;

            if (key == null || value == null)
                continue;

            if (value.GetType().IsEnum)
                value = value.GetEnumMemberName();

            dictionary.Add(key, $"{value}");
        }

        return dictionary;
    }
}
