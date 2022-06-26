using SynologyNet.Exceptions;
using SynologyNet.Helpers;
using SynologyNet.Models;
using SynologyNet.Repository;
using System.Threading.Tasks;

namespace SynologyNet.Services
{
    public class AuthenticationService : BaseService, IAuthenticationService
    {
        private AuthenticationRepository Repository { get; }
        private SynologyCredentials Credentials { get; }

        internal AuthenticationService(SynologyCredentials credentials)
        {
            Repository = new AuthenticationRepository();
            Credentials = credentials;
        }

        public bool IsAuthenticated => KeyHelper.HasSession();

        public async Task<bool> Login(string session = null)
        {
            var response = await Repository.Login(Credentials, session: session);
            CheckErrorCode<AuthenticationErrorCode>(response);

            if (response.Success && response.Data.Sid != null)
            {
                if (KeyHelper.HasSession(session))
                    KeyHelper.ClearSession(session);

                KeyHelper.AddSession(response.Data.Sid, session: session);
            }

            return response.Success && response.Data.Sid != null;
        }

        public async Task<bool> Logout(string session = null)
        {
            var response = await Repository.Logout(session);
            CheckErrorCode<AuthenticationErrorCode>(response);

            if (response.Success)
                KeyHelper.ClearSession(session);

            return response.Success;
        }
    }
}
