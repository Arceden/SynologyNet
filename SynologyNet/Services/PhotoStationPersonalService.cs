using SynologyNet.Exceptions;
using SynologyNet.Models.Requests.Photo.Filters;
using SynologyNet.Models.Responses;
using SynologyNet.Models.Responses.Photo;
using SynologyNet.Repository;
using SynologyNet.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynologyNet.Services
{
    class PhotoStationPersonalService : BaseService, IPhotoStationPersonalService
    {
        private PersonalPhotoRepository Repository { get; }

        public PhotoStationPersonalService()
            => Repository = new PersonalPhotoRepository();

        public async Task<IEnumerable<Folder>> GetFolders(PagingFilter? pagingFilter = null)
        {
            var response = await Repository.GetFolders(pagingFilter: pagingFilter);

            CheckErrorCode(response);

            return response.Data?.List ?? new List<Folder>();
        }

        public async Task<IEnumerable<Album>> GetAlbums(PagingFilter? pagingFilter = null)
        {
            var response = await Repository.GetAlbums(pagingFilter: pagingFilter);

            CheckErrorCode(response);

            return response.Data?.List ?? new List<Album>();
        }

		public async Task<Album> CreateNormalAlbum(string albumName)
		{
			var response = await Repository.CreateNormalAlbum(albumName);

			CheckErrorCode(response);

			return response.Data?.Album ?? new Album();
		}

		public async Task<IEnumerable<Album>> GetSharedAlbums(PagingFilter? pagingFilter = null)
        {
            var response = await Repository.GetSharedAlbums(pagingFilter: pagingFilter);

            CheckErrorCode<PhotoErrorCode>(response);

            return response.Data?.List ?? new List<Album>();
        }

        public async Task<IEnumerable<Photo>> GetPhotos(PagingFilter? pagingFilter = null)
        {
            var response = await Repository.GetPhotos(pagingFilter: pagingFilter);

            CheckErrorCode<PhotoErrorCode>(response);

            return response.Data?.List ?? new List<Photo>();
        }

        public async Task<IEnumerable<Photo>> GetAlbumPhotos(Album album, PagingFilter? pagingFilter = null)
        {
            var response = await Repository.GetAlbumPhotos(album, pagingFilter: pagingFilter);

            CheckErrorCode<PhotoErrorCode>(response);

            return response.Data?.List ?? new List<Photo>();
        }

        public async Task<IEnumerable<Photo>> GetRecentlyAddedPhotos(PagingFilter? pagingFilter = null)
        {
            var response = await Repository.GetRecentlyAddedPhotos(pagingFilter: pagingFilter);

            CheckErrorCode<PhotoErrorCode>(response);

            return response.Data?.List ?? new List<Photo>();
        }

        public async Task<byte[]> DownloadPhoto(int photoId)
        {
            var response = await Repository.DownloadPhoto(photoId, null);

            CheckErrorCode<PhotoErrorCode>(response);

            return response.Data ?? System.Array.Empty<byte>();
        }

        public async Task<byte[]> DownloadPhoto(int photoId, string passphrase)
        {
            var response = await Repository.DownloadPhoto(photoId, passphrase);

            CheckErrorCode<PhotoErrorCode>(response);

            return response.Data ?? System.Array.Empty<byte>();
        }

        public Task<byte[]> DownloadPhoto(Photo photo)
        {
            return DownloadPhoto(photo.Id);
        }

        public Task<byte[]> DownloadPhoto(Photo photo, Album album)
        {
            return DownloadPhoto(photo.Id, album.Passphrase);
        }

		public async Task<bool> AddItemToAlbum(Photo item, Album album)
		{
			var response = await Repository.AddItemToAlbum(item, album);

			CheckErrorCode<PhotoErrorCode>(response);

            return response.Data?.ErrorList?.Count() == 0;
		}

		public async Task<IEnumerable<Photo>> SearchForPhotos(SearchFilter? searchFilter = null)
		{
			var response = await Repository.SearchForPhotos(searchFilter: searchFilter);

			CheckErrorCode(response);

			return response.Data?.List ?? new List<Photo>();
		}
	}
}
