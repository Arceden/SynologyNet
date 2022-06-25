using System.Text.Json.Serialization;

namespace SynologyNet.Models.Photo
{
    public class Album
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("item_count")]
        public int ItemCount { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("passphrase")]
        public string Passphrase { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }


        [JsonPropertyName("sort_by")]
        public string SortBy { get; set; }

        [JsonPropertyName("sort_direction")]
        public string SortDirection { get; set; }

        [JsonPropertyName("shared")]
        public bool Shared { get; set; }

        [JsonPropertyName("temporary_shared")]
        public bool TemporaryShared { get; set; }

        [JsonPropertyName("freeze_album")]
        public bool FreezeAlbum { get; set; }

        [JsonPropertyName("create_time")]
        public int CreateTime { get; set; }

        [JsonPropertyName("start_time")]
        public int StartTime { get; set; }

        [JsonPropertyName("end_time")]
        public int EndTime { get; set; }

        [JsonPropertyName("version")]
        public int Version { get; set; }
    }
}
