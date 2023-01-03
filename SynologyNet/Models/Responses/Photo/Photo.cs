using System.Text.Json.Serialization;

namespace SynologyNet.Models.Responses.Photo
{
    /// <summary>
    /// Photo model
    /// </summary>
    public record Photo
    {
        /// <summary>
        /// Name of the file as stored on the Synology filesystem
        /// </summary>
        [JsonPropertyName("filename")]
        public string Filename { get; set; }

        /// <summary>
        /// Size of the file
        /// </summary>
        [JsonPropertyName("filesize")]
        public int FileSize { get; set; }

        /// <summary>
        /// Folder identifier
        /// </summary>
        [JsonPropertyName("folder_id")]
        public int FolderId { get; set; }

        /// <summary>
        /// File identifier
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        // Number bigger than int.MaxValue
        //[JsonPropertyName("indexed_time")]
        //public int IndexedTime { get; set; }

        /// <summary>
        /// User identifier of the owner
        /// </summary>
        [JsonPropertyName("owner_user_id")]
        public int OwnerUserId { get; set; }

        /// <summary>
        /// Time of the photo
        /// </summary>
        [JsonPropertyName("time")]
        public int Time { get; set; }

        /// <summary>
        /// File type
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
