using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SynologyNet.Models.Photo
{
    public class ListObject<T>
    {
        [JsonPropertyName("list")]
        public IEnumerable<T> List { get; set; }
    }
}
