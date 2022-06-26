using System.Text.Json.Serialization;

namespace SynologyNet.Models.Responses.Photo
{
    public class Folder
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("owner_user_id")]
        public int OwnerUserId { get; set; }
        [JsonPropertyName("parent")]
        public int Parent { get; set; }
        [JsonPropertyName("passphrase")]
        public string Passphrase { get; set; }
        [JsonPropertyName("shared")]
        public bool Shared { get; set; }
        [JsonPropertyName("sort_by")]
        public string SortBy { get; set; }
        [JsonPropertyName("sort_direction")]
        public string SortDirection { get; set; }
    }
}
