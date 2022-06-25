using SynologyNet.Exceptions;
using SynologyNet.Models.Photo;
using SynologyNet.Repository;
using SynologyNet.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SynologyNet.Services
{
    public class PhotoService : BaseService, IPhotoService
    {
        private PhotoRepository Repository { get; }

        public PhotoService()
            => Repository = new PhotoRepository();

        public async Task<IEnumerable<Photo>> GetPhotosFromAlbum(Album album)
        {
            var response = await Repository.GetPhotosFromAlbum(passphrase: album.Passphrase);

            CheckErrorCode<PhotoErrorCode>(response);

            return response.Data.List;
        }

        public async Task<IEnumerable<Photo>> GetRecentlyAddedPhotos()
        {
            var response = await Repository.GetRecentlyAddedPhotos();

            CheckErrorCode<PhotoErrorCode>(response);

            return response.Data.List;
        }

        public async Task<IEnumerable<Album>> GetSharedAlbums()
        {
            var response = await Repository.GetSharedAlbums();

            CheckErrorCode<PhotoErrorCode>(response);

            return response.Data.List;
        }

        public Task<byte[]> DownloadPhoto(int photoId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<byte[]> DownloadPhoto(int photoId, string passphrase)
        {
            return await Repository.DownloadPhoto(photoId, passphrase);
        }
    }
}
