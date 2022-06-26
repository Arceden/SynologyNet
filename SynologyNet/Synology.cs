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

        public IAuthenticationService Authentication { get; }
        public IGeneralService General { get; }
        public IPhotoStationService PhotoStation { get; }
        public IFileStationService FileStation { get; }
        public ISurveillanceStationService SurveillanceStation { get; }
    }
}
