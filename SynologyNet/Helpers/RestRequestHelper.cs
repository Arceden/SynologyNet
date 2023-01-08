using RestSharp;
using System;

namespace SynologyNet.Helpers
{
    public static class RestRequestHelper
    {
        /// <summary>
        /// Add request parameter if value is not null
        /// </summary>
        /// <param name="request">RestRequest object</param>
        /// <param name="name">Parameter name</param>
        /// <param name="value">Parameter value</param>
        /// <returns>RestRequest</returns>
        public static RestRequest AddParameterIfNotNull(this RestRequest request, string name, string? value)
        {
            return value != null ? request.AddParameter(name, value) : request;
        }

        [Obsolete("Dit werkt niet echt goed ivm enum values")]
        public static RestRequest AddDynamicParameter(RestRequest request, string name, dynamic value)
            => Type.GetTypeCode(value.GetType()) switch
            {
                TypeCode.Int16 or TypeCode.Int32 or TypeCode.Int64 => request.AddParameter(name, (int) value),
                TypeCode.String => request.AddParameter(name, (string) value),
                //TypeCode.Enum => request.AddParameter(name, ((Enum) value).GetValue()),
                _ => throw new NotImplementedException($"No support for filter with type {value.GetType()}.")
            };

    }
}
