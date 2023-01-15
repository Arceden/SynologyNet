using System.Text.Json.Serialization;

namespace SynologyNet.Models.Requests.Photo.Filters;

/// <summary>
/// Paging filters for a collection
/// </summary>
public class PagingFilter : IFilter
{
    /// <summary>
    /// Fetch collection with an offset which skips x amount of items
    /// </summary>
    [JsonPropertyName("offset")]
    public int Offset { get; set; } = 0;

    /// <summary>
    /// Limit the amount of items to return
    /// </summary>
    /// <remarks>
    /// The API can only accept a value between 0 and 5000
    /// </remarks>
    [JsonPropertyName("limit")]
    public int Limit { get; set; } = 5000;
}
