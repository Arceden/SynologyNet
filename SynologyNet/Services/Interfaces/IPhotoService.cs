using System;

namespace SynologyNet.Services.Interfaces
{
    public interface IPhotoService
    {
        /// <summary>
        /// Access photos and folders within the Personal Space of the Synology Photos API
        /// </summary>
        IPersonalPhotoService Personal { get; }

        /// <summary>
        /// Access photos and folders within the Shared Space of the Synology Photos API
        /// </summary>
        ISharedPhotoService Shared { get; }
    }

    public class PhotoService : IPhotoService
    {
        public IPersonalPhotoService Personal { get; }
        public ISharedPhotoService Shared => throw new NotImplementedException();

        public PhotoService()
        {
            Personal = new PersonalPhotoService();
        }
    }
}
