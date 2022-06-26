using System.Text.Json.Serialization;

namespace SynologyNet.Models.Responses
{
    public class BaseDataResponse<T> : BaseResponse
    {
        [JsonPropertyName("data")]
        public T Data { get; set; }
    }
}
