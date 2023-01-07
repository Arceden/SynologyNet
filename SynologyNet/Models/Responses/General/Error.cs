using System.Text.Json.Serialization;

namespace SynologyNet.Models.Responses
{
    /// <summary>
    /// Base error object
    /// </summary>
    public record Error
    {
        /// <summary>
        /// Identifiable error code
        /// </summary>
        [JsonPropertyName("code")]
        public int Code { get; set; }

        /// <summary>
        /// Error description
        /// </summary>
        [JsonPropertyName("errors")]
        public ErrorContent? Errors { get; set; }
    }

    /// <summary>
    /// Descriptive error object
    /// </summary>
    public record ErrorContent
    {
        /// <summary>
        /// Name of the error
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// Error reasoning
        /// </summary>
        [JsonPropertyName("reason")]
        public string? Reason { get; set; }
    }
}
