﻿using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SynologyNet.Models.Responses
{
    public class InformationList : BaseResponse
    {
        [JsonPropertyName("data")]
        public Dictionary<string, Information> Data { get; set; }
    }

    public class Information
    {
        [JsonPropertyName("path")]
        public string Path { get; set; }
        [JsonPropertyName("minVersion")]
        public int MinVersion { get; set; }
        [JsonPropertyName("maxVersion")]
        public int MaxVersion { get; set; }
    }
}
