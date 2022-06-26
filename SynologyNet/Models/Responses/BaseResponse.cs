using System.Text.Json.Serialization;

namespace SynologyNet.Models.Responses
{
    public abstract class BaseResponse
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("error")]
        public Error Error { get; set; }
    }
}
