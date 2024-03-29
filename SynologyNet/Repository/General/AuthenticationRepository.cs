﻿using RestSharp;
using SynologyNet.Attributes;
using SynologyNet.Models;
using SynologyNet.Models.Responses;
using System.Threading.Tasks;

namespace SynologyNet.Repository
{
    [SynologyRepository(DefaultApi = "SYNO.API.Auth", DefaultPath = "auth.cgi")]
    class AuthenticationRepository : BaseRepository
    {
        [Request(Method = "login", Version = 3)]
        public async Task<BaseDataResponse<AuthenticationResponse>> Login(SynologyCredentials credentials, string session = null)
        {
            var request = PrepareRequest();
            request.AddParameter("account", credentials.Username);
            request.AddParameter("passwd", credentials.Password);
            request.AddParameter("enable_synotoken", "yes");

            if (session != null)
                request.AddParameter("session", session);

            return await _client.PostAsync<BaseDataResponse<AuthenticationResponse>>(request);
        }

        [Request(Method = "logout", Version = 3)]
        public async Task<BaseDataResponse<AuthenticationResponse>> Logout(string session = null)
        {
            var request = PrepareRequest();

            if (session != null)
                request.AddParameter("session", session);

            return await _client.PostAsync<BaseDataResponse<AuthenticationResponse>>(PrepareRequest());
        }
    }
}
