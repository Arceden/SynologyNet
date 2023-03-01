using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SynologyNet.Models.Responses
{
    /// <summary>
    /// Base error object
    /// </summary>
    public class Error
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
    public class ErrorContent
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

	/// <summary>
	/// Error list object
	/// </summary>
	public class ErrorListObject
    {
		[JsonPropertyName("error_list")]
		public IEnumerable<ErrorContent> ErrorList { get; set; } // TODO: not tested, always received empty list with no structure, so the structure to deserialize is not known...
	}
}
