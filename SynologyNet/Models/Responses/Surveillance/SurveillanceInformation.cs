using System.Text.Json.Serialization;

namespace SynologyNet.Models.Responses.Surveillance
{
    public record SurveillanceInformation : BaseDataResponse<SurveillanceInformationData>
    { }

    public record SurveillanceInformationData
    {
        [JsonPropertyName("version")]
        public Version Version { get; set; }
        [JsonPropertyName("customizedPortHttp")]
        public int CustomizedPortHttp { get; set; }
        [JsonPropertyName("customizedPortHttps")]
        public int CustomizedPortHttps { get; set; }
        [JsonPropertyName("cameraNumber")]
        public int CameraNumber { get; set; }
        [JsonPropertyName("licenseNumber")]
        public int LicenseNumber { get; set; }
        [JsonPropertyName("maxCameraSupport")]
        public int MaxCameraSupport { get; set; }
        [JsonPropertyName("serial")]
        public string Serial { get; set; }
        [JsonPropertyName("isAdmin")]
        public bool IsAdmin { get; set; }
        [JsonPropertyName("isLicenseEnough")]
        public bool IsLicenseEnough { get; set; }
        [JsonPropertyName("path")]
        public string Path { get; set; }
    }

    public record Version
    {
        [JsonPropertyName("major")]
        public int Major { get; set; }
        [JsonPropertyName("minor")]
        public int Minor { get; set; }
        [JsonPropertyName("build")]
        public int Build { get; set; }
    }
}
