using System.Text.Json.Serialization;

namespace SynologyNet.Models.Responses
{
    public class AuthenticationResponse
    {
        [JsonPropertyName("sid")]
        public string Sid { get; set; }
        [JsonPropertyName("did")]
        public string Did { get; set; }
    }
}
