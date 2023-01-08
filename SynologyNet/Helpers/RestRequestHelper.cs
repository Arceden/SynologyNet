using RestSharp;

namespace SynologyNet.Helpers
{
    static class RestRequestHelper
    {
        /// <summary>
        /// Add request parameter if value is not null
        /// </summary>
        /// <param name="request">RestRequest object</param>
        /// <param name="name">Parameter name</param>
        /// <param name="value">Parameter value</param>
        /// <returns>RestRequest</returns>
        public static RestRequest AddParameterIfNotNull(this RestRequest request, string name, string? value)
            => value != null ? request.AddParameter(name, value) : request;
    }
}
