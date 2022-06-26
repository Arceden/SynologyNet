using SynologyNet.Attributes;
using SynologyNet.Helpers;
using SynologyNet.Models;
using SynologyNet.Repository;
using SynologyNet.Services;
using SynologyNet.Services.Interfaces;

namespace SynologyNet
{
    /// <summary>
    /// Synology API wrapper
    /// </summary>
    public class Synology
    {
        /// <summary>
        /// SynologyNET constructor
        /// </summary>
        /// <param name="host">Synology API host url. e.g. http://192.168.178.10:5000/webapi/</param>
        /// <param name="username">Account username to login to</param>
        /// <param name="password">Account password to login with</param>
        public Synology(string host, string username, string password)
        {
            BaseRepository.BaseAddress = host;
            BaseRepository.RequestMethods = AssemblyHelper.GetMethodsWithCustomAttributes(typeof(RequestAttribute));

            var credentials = new SynologyCredentials
            {
                Username = username,
                Password = password
            };

            Authentication = new AuthenticationService(credentials);
            General = new GeneralService();
            PhotoStation = new PhotoStationService();
            FileStation = new FileStationService();
            SurveillanceStation = new SurveillanceStationService();
        }

        /// <summary>
        /// Authentication and user related functionality
        /// </summary>
        public IAuthenticationService Authentication { get; }

        /// <summary>
        /// Base-level functionality
        /// </summary>
        public IGeneralService General { get; }

        /// <summary>
        /// Synology Photos functionality
        /// </summary>
        public IPhotoStationService PhotoStation { get; }

        /// <summary>
        /// Synology FileStation functionality
        /// </summary>
        public IFileStationService FileStation { get; }

        /// <summary>
        /// Synology SurveillanceStation functionality
        /// </summary>
        public ISurveillanceStationService SurveillanceStation { get; }
    }
}
