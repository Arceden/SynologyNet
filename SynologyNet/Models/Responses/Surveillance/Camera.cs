using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SynologyNet.Models.Responses.Surveillance
{
    public record Camera
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("model")]
        public string Model { get; set; }

        [JsonPropertyName("vendor")]
        public string Vendor { get; set; }

        [JsonPropertyName("channel")]
        public string Channel { get; set; }

        [JsonPropertyName("ip")]
        public string Ip { get; set; }

        [JsonPropertyName("port")]
        public int Port { get; set; }

        [JsonPropertyName("enable_low_profile")]
        public bool EnableLowProfile { get; set; }

        [JsonPropertyName("stream1")]
        public Stream Stream1 { get; set; }

        [JsonPropertyName("stream2")]
        public Stream Stream2 { get; set; }

        [JsonPropertyName("stream3")]
        public Stream Stream3 { get; set; }
    }

    public record Stream
    {
        [JsonPropertyName("bitrateCtrl")]
        public int BitrateControl { get; set; }

        [JsonPropertyName("constantBitrate")]
        public int ConstantBitrate { get; set; }

        [JsonPropertyName("fps")]
        public int Fps { get; set; }

        [JsonPropertyName("quality")]
        public int Quality { get; set; }

        [JsonPropertyName("resolution")]
        public string Resolution { get; set; }
    }

    public record CameraListData
    {
        [JsonPropertyName("total")]
        public int Total { get; set; }

        [JsonPropertyName("cameras")]
        public IEnumerable<Camera> Cameras { get; set; }
    }

    public record CameraList : BaseDataResponse<CameraListData>
    { }
}
