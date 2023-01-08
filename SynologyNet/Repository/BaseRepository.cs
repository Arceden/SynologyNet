using RestSharp;
using SynologyNet.Attributes;
using SynologyNet.Helpers;
using SynologyNet.Models.Requests.Photo.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace SynologyNet.Repository
{
    class BaseRepository
    {
        protected readonly RestClient _client;
        protected readonly SynologyRepositoryAttribute _repository;

        public static IEnumerable<MethodInfo> RequestMethods { get; set; } = new List<MethodInfo>();
        public static string BaseAddress { get; set; } = string.Empty;

        public BaseRepository()
        {
            _client = new RestClient(BaseAddress);
            _repository = (SynologyRepositoryAttribute?) Attribute.GetCustomAttribute(this.GetType(), typeof(SynologyRepositoryAttribute)) ?? new();
        }

        protected RestRequest PrepareRequest(params IFilter[] filters)
        {
            var method = GetMethod();
            var metadata = (RequestAttribute?) Attribute.GetCustomAttribute(method, typeof(RequestAttribute));
            var request = new RestRequest(metadata?.Path ?? _repository.DefaultPath);

            // Apply repository filters
            request.AddParameter("api", metadata?.Api ?? _repository.DefaultApi);
            request.AddParameter("method", metadata?.Method ?? string.Empty);
            request.AddParameter("version", metadata?.Version ?? 1);
            request.AddParameterIfNotNull("query", metadata?.Query ?? string.Empty);

            // Apply user filters
            foreach (var filter in filters)
                foreach (var option in filter.ToDictionary())
                    request.AddParameter(option.Key, option.Value);

            // Apply authentication
            if ((metadata != null && metadata.RequiresAuthentication) || _repository.RequiresAuthentication)
                request = AddAuthentication(request);

            return request;
        }

        /// <summary>
        /// Get the utilized repository method
        /// </summary>
        /// <returns>MethodInfo using the RequestAttribute</returns>
        private MethodInfo GetMethod()
        {
            var stackFrames = new StackTrace().GetFrames();
            return RequestMethods
                .Where(requestMethod => stackFrames.Any(stackFrame => stackFrame.GetMethod().MetadataToken.Equals(requestMethod.MetadataToken)))
                .First();
        }

        /// <summary>
        /// Add authentication details to te request
        /// </summary>
        /// <param name="request">HTTP Request object</param>
        /// <returns>HTTP Request object</returns>
        private static RestRequest AddAuthentication(RestRequest request)
            => request.AddParameter("_sid", KeyHelper.GetSession().Sid);
    }
}
