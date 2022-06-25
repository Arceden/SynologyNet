using System.Text.Json.Serialization;

namespace SynologyNet.Models.Photo
{
    public class Photo
    {
        [JsonPropertyName("filename")]
        public string Filename { get; set; }

        [JsonPropertyName("filesize")]
        public int FileSize { get; set; }

        [JsonPropertyName("folder_id")]
        public int FolderId { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        // Number bigger than int.MaxValue
        //[JsonPropertyName("indexed_time")]
        //public int IndexedTime { get; set; }

        [JsonPropertyName("owner_user_id")]
        public int OwnerUserId { get; set; }

        [JsonPropertyName("time")]
        public int Time { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
