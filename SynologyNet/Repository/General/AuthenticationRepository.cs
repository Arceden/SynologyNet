using RestSharp;
using SynologyNet.Attributes;
using SynologyNet.Models;
using System.Threading.Tasks;

namespace SynologyNet.Repository
{
    [SynologyRepository(DefaultApi = "SYNO.API.Auth", DefaultPath = "auth.cgi")]
    public class AuthenticationRepository : BaseRepository
    {
        [Request(Method = "login", Version = 3)]
        public async Task<AuthenticationResponse> Login(SynologyCredentials credentials, string session = null)
        {
            var request = PrepareRequest();
            request.AddParameter("account", credentials.Username);
            request.AddParameter("passwd", credentials.Password);
            request.AddParameter("enable_synotoken", "yes");

            if (session != null)
                request.AddParameter("session", session);

            return await _client.PostAsync<AuthenticationResponse>(request);
        }

        [Request(Method = "logout", Version = 3)]
        public async Task<BaseResponse> Logout(string session = null)
        {
            var request = PrepareRequest();

            if (session != null)
                request.AddParameter("session", session);

            return await _client.PostAsync<AuthenticationResponse>(PrepareRequest());
        }
    }
}
