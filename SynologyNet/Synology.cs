using SynologyNet.Attributes;
using SynologyNet.Helpers;
using SynologyNet.Models;
using SynologyNet.Repository;
using SynologyNet.Services;
using SynologyNet.Services.Interfaces;

namespace SynologyNet
{
    public class Synology
    {
        private SynologyCredentials Credentials { get; set; }

        public Synology(string host, string username, string password)
        {
            BaseRepository.BaseAddress = host;
            BaseRepository.RequestMethods = AssemblyHelper.GetMethodsWithCustomAttributes(typeof(RequestAttribute));

            Credentials = new SynologyCredentials
            {
                Username = username,
                Password = password
            };

            Authentication = new AuthenticationService(Credentials);
        }

        public IAuthenticationService Authentication { get; }
        public IPhotoService Photo { get; } = new PhotoService();
        public IFileStationService FileStation { get; } = new FileStationService();
        public ISurveillanceStationService SurveillanceStation { get; } = new SurveillanceStationService();
    }
}
