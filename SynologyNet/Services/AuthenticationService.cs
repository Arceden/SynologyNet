using SynologyNet.Models;
using SynologyNet.Repository;
using System;
using System.Threading.Tasks;

namespace SynologyNet.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private AuthenticationRepository Repository { get; }
        private SynologyCredentials Credentials { get; }
        private string Key { get; set; }

        internal AuthenticationService(SynologyCredentials credentials)
        {
            Repository = new AuthenticationRepository();
            Credentials = credentials;
        }

        public bool IsAuthenticated => Key != null;

        public async Task<bool> Login()
        {
            var response = await Repository.Login(Credentials);
            CheckErrorCode(response);

            if (response.Success && response.Data.SID != null)
                Key = response.Data.SID;

            return response.Success && response.Data.SID != null;
        }

        public async Task<bool> Logout()
        {
            var response = await Repository.Logout();
            CheckErrorCode(response);

            if (response.Success)
                Key = null;

            return response.Success;
        }

        private static void CheckErrorCode(BaseResponse response)
        {
            if (response.Error == null)
                return;

            switch ((AuthenticationErrorCode)response.Error.Code)
            {
                case AuthenticationErrorCode.IncorrectCredentials:
                    throw new AuthenticationException("No such account or incorrect password");
                case AuthenticationErrorCode.AccountDisabled:
                    throw new AuthenticationException("Account disabled");
                case AuthenticationErrorCode.PermissionDenied:
                    throw new AuthenticationException("Permission denied");
                case AuthenticationErrorCode.TwoFactorAuthenticationRequired:
                    throw new AuthenticationException("2-step verification code required");
                case AuthenticationErrorCode.TwoFactorAuthenticationFailed:
                    throw new AuthenticationException("Failed to authenticate 2-step verification code");
            }
        }
    }

    internal enum AuthenticationErrorCode
    {
        IncorrectCredentials = 400,
        AccountDisabled = 401,
        PermissionDenied = 402,
        TwoFactorAuthenticationRequired = 403,
        TwoFactorAuthenticationFailed = 404,
    }

    internal class AuthenticationException : Exception
    {
        public AuthenticationException()
        { }

        public AuthenticationException(string message) : base(message)
        { }
    }

}
