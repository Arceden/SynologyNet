using SynologyNet.Exceptions;
using SynologyNet.Models.Responses.Photo;
using SynologyNet.Repository;
using SynologyNet.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SynologyNet.Services
{
    public class PersonalPhotoService : BaseService, IPersonalPhotoService
    {
        private PersonalPhotoRepository Repository { get; }

        public PersonalPhotoService()
            => Repository = new PersonalPhotoRepository();

        public async Task<IEnumerable<Folder>> GetFolders()
        {
            var response = await Repository.GetFolders();

            CheckErrorCode(response);

            return response.Data.List;
        }

        public async Task<IEnumerable<Album>> GetAlbums()
        {
            var response = await Repository.GetAlbums();

            CheckErrorCode(response);

            return response.Data.List;
        }

        public async Task<IEnumerable<Album>> GetSharedAlbums()
        {
            var response = await Repository.GetSharedAlbums();

            CheckErrorCode<PhotoErrorCode>(response);

            return response.Data.List;
        }

        public async Task<IEnumerable<Photo>> GetAlbumPhotos(Album album)
        {
            var response = await Repository.GetAlbumPhotos(passphrase: album.Passphrase);

            CheckErrorCode<PhotoErrorCode>(response);

            return response.Data.List;
        }

        public async Task<IEnumerable<Photo>> GetRecentlyAddedPhotos()
        {
            var response = await Repository.GetRecentlyAddedPhotos();

            CheckErrorCode<PhotoErrorCode>(response);

            return response.Data.List;
        }

        public async Task<byte[]> DownloadPhoto(int photoId)
        {
            return await Repository.DownloadPhoto(photoId, null);
        }

        public async Task<byte[]> DownloadPhoto(int photoId, string passphrase)
        {
            return await Repository.DownloadPhoto(photoId, passphrase);
        }
    }
}
