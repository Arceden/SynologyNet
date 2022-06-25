using RestSharp;
using SynologyNet.Attributes;
using SynologyNet.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace SynologyNet.Repository
{
    public class BaseRepository
    {
        protected readonly RestClient _client;
        protected readonly SynologyRepositoryAttribute _repository;

        public static IEnumerable<MethodInfo> RequestMethods { get; set; }
        public static string BaseAddress { get; set; }

        public BaseRepository()
        {
            _client = new RestClient(BaseAddress);
            _repository = (SynologyRepositoryAttribute)Attribute.GetCustomAttribute(this.GetType(), typeof(SynologyRepositoryAttribute));
        }

        protected RestRequest PrepareRequest()
        {
            var method = GetMethod();
            var metadata = (RequestAttribute)Attribute.GetCustomAttribute(method, typeof(RequestAttribute));
            var request = new RestRequest(metadata.Path ?? _repository.DefaultPath);

            request.AddParameter("api", metadata.Api ?? _repository.DefaultApi);
            request.AddParameter("method", metadata.Method);
            request.AddParameter("version", metadata.Version);
            request.AddParameterIfNotNull("query", metadata.Query);

            if (metadata.RequiresAuthentication || _repository.RequiresAuthentication)
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

        private RestRequest AddAuthentication(RestRequest request)
        {
            request.AddParameter("_sid", KeyHelper.GetSession().Sid);
            return request;
        }
    }
}
