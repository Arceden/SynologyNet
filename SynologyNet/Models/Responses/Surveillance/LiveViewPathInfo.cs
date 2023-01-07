using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SynologyNet.Models.Responses.Surveillance
{
    public record LiveViewPathInfoContainer : BaseDataResponse<List<LiveViewPathInfo>>
    { }

    public record LiveViewPathInfo
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("mjpegHttpPath")]
        public string MjpegHttpPath { get; set; }

        [JsonPropertyName("multicstPath")]
        public string MulticstPath { get; set; }

        [JsonPropertyName("mxpegHttpPath")]
        public string MxpegHttpPath { get; set; }

        [JsonPropertyName("rtspOverHttpPath")]
        public string RtspOverHttpPath { get; set; }

        [JsonPropertyName("rtspPath")]
        public string RtspPath { get; set; }
    }
}
