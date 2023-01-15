using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SynologyNet.Models.Requests.Photo.Filters;

/// <summary>
/// Filter for sortable collections
/// </summary>
public class SortableFilter : IFilter
{
    /// <summary>
    /// Sort by specific piece of file information
    /// </summary>
    [JsonPropertyName("sort_by")]
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public SortByType SortBy { get; set; } = SortByType.Default;

    /// <summary>
    /// Sort with ascending or decending values
    /// </summary>
    [JsonPropertyName("sort_direction")]
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public SortDirectionType SortDirection { get; set; } = SortDirectionType.Asc;
}

/// <summary>
/// Sort by type
/// </summary>
public enum SortByType
{
    /// <summary>
    /// Default type
    /// </summary>
    [EnumMember(Value = "")]
    Default,

    /// <summary>
    /// Filename
    /// </summary>
    [EnumMember(Value = "name")]
    Name,

    /// <summary>
    /// File size
    /// </summary>
    [EnumMember(Value = "size")]
    Size,

    /// <summary>
    /// File owner
    /// </summary>
    [EnumMember(Value = "user")]
    User,

    /// <summary>
    /// File group
    /// </summary>
    [EnumMember(Value = "group")]
    Group,

    /// <summary>
    /// Last modified time
    /// </summary>
    [EnumMember(Value = "mtime")]
    ModifiedTime,

    /// <summary>
    /// Last access time
    /// </summary>
    [EnumMember(Value = "atime")]
    AccessTime,

    /// <summary>
    /// Last change time
    /// </summary>
    [EnumMember(Value = "ctime")]
    ChangedTime,

    /// <summary>
    /// Created time
    /// </summary>
    [EnumMember(Value = "crtime")]
    CreatedTime,

    /// <summary>
    /// POSIX permission
    /// </summary>
    [EnumMember(Value = "posix")]
    POSIX,

    /// <summary>
    /// File extension
    /// </summary>
    [EnumMember(Value = "type")]
    Type,
}

/// <summary>
/// Sort direction type
/// </summary>
public enum SortDirectionType
{
    /// <summary>
    /// Sort with ascending values
    /// </summary>
    [EnumMember(Value = "asc")]
    Asc,

    /// <summary>
    /// Sort with descending values
    /// </summary>
    [EnumMember(Value = "desc")]
    Desc
}