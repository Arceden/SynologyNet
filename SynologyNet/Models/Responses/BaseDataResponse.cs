using System.Text.Json.Serialization;

namespace SynologyNet.Models.Responses
{
    /// <summary>
    /// Base record for the data response
    /// </summary>
    /// <typeparam name="T">Datatype of the response content</typeparam>
    public class BaseDataResponse<T> : BaseResponse
    {
        /// <summary>
        /// Requested response content
        /// </summary>
        [JsonPropertyName("data")]
        public T? Data { get; set; }
    }
}
