using System.Text.Json.Serialization;

namespace SynologyNet.Models
{
    public class AuthenticationResponse : BaseDataResponse<AuthenticationData>
    { }

    public class AuthenticationData
    {
        [JsonPropertyName("sid")]
        public string SID { get; set; }
    }
}
