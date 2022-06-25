using System.Threading.Tasks;

namespace SynologyNet.Services
{
    /// <summary>
    /// Synology Authentication service class
    /// </summary>
    public interface IAuthenticationService
    {
        /// <summary>
        /// Check wether or not the user is authenticated
        /// </summary>
        bool IsAuthenticated { get; }

        /// <summary>
        /// Uses the provided credentials to authenticate the user
        /// </summary>
        /// <returns>true if user was authenticated successfully</returns>
        Task<bool> Login();

        /// <summary>
        /// Logs the user out of the synology system
        /// </summary>
        /// <returns>true if user was logged out successfully</returns>
        Task<bool> Logout();
    }
}
