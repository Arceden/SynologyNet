using System.Text.Json.Serialization;

namespace SynologyNet.Models.Responses
{
    /// <summary>
    /// Base response object for the response status
    /// </summary>
    public abstract class BaseResponse
    {
        /// <summary>
        /// True if the Synology endpoint returned with a valid response
        /// </summary>
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        /// <summary>
        /// Error object if the Synology endpoint did not return with a valid response
        /// </summary>
        [JsonPropertyName("error")]
        public Error? Error { get; set; }
    }
}
