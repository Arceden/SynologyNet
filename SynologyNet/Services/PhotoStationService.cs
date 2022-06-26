using SynologyNet.Services.Interfaces;
using System;

namespace SynologyNet.Services
{
    public class PhotoStationService : IPhotoStationService
    {
        public IPhotoStationPersonalService Personal { get; } = new PhotoStationPersonalService();
        public IPhotoStationSharedService Shared => throw new NotImplementedException();
    }
}
