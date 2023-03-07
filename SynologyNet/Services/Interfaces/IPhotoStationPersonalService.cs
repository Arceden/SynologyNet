using SynologyNet.Models.Requests.Photo.Filters;
using SynologyNet.Models.Responses.Photo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SynologyNet.Services.Interfaces
{
    /// <summary>
    /// PersonalSpace for PhotoStation interface
    /// </summary>
    public interface IPhotoStationPersonalService
    {
        /// <summary>
        /// Get list of albums made by the current user
        /// </summary>
        /// <param name="pagingFilter">Pagination filtering for the collection</param>
        /// <returns>List of albums</returns>
        Task<IEnumerable<Album>> GetAlbums(PagingFilter? pagingFilter = null);

        /// <summary>
        /// Create normal album
        /// </summary>
        /// <returns>Created album</returns>
        Task<Album> CreateNormalAlbum(string albumName);

        /// <summary>
        /// Get list of shared albums with the current user
        /// </summary>
        /// <param name="pagingFilter">Pagination filtering for the collection</param>
        /// <returns>List of shared albums</returns>
        Task<IEnumerable<Album>> GetSharedAlbums(PagingFilter? pagingFilter = null);

        /// <summary>
        /// Get a list of photos from the current user
        /// </summary>
        /// <param name="pagingFilter">Pagination filtering for the collection</param>
        /// <returns>List of photos</returns>
        Task<IEnumerable<Photo>> GetPhotos(PagingFilter? pagingFilter = null);

        /// <summary>
        /// Get list of recently added photos
        /// </summary>
        /// <param name="pagingFilter">Pagination filtering for the collection</param>
        /// <returns>List of photos</returns>
        Task<IEnumerable<Photo>> GetRecentlyAddedPhotos(PagingFilter? pagingFilter = null);

        /// <summary>
        /// Get list of photos from a specified <seealso cref="Album"/>
        /// </summary>
        /// <param name="album">Source <seealso cref="Album"/></param>
        /// <param name="pagingFilter">Pagination filtering for the collection</param>
        /// <returns>List of photos</returns>
        Task<IEnumerable<Photo>> GetAlbumPhotos(Album album, PagingFilter? pagingFilter = null);

        /// <summary>
        /// Get list of folders
        /// </summary>
        /// <param name="pagingFilter">Pagination filtering for the collection</param>
        /// <returns>List of folders</returns>
        Task<IEnumerable<Folder>> GetFolders(PagingFilter? pagingFilter = null);

        /// <summary>
        /// Download <seealso cref="Photo"/> as byte array
        /// </summary>
        /// <param name="photoId"><seealso cref="Photo"/> identifier</param>
        /// <returns>Photo as byte array</returns>
        Task<byte[]> DownloadPhoto(int photoId);

        /// <summary>
        /// Download <seealso cref="Photo"/> as byte array
        /// </summary>
        /// <param name="photo"><seealso cref="Photo"/> to download</param>
        /// <returns>Photo as bytearray</returns>
        Task<byte[]> DownloadPhoto(Photo photo);

        /// <summary>
        /// Download <seealso cref="Photo"/> from shared <seealso cref="Album"/> as byte array
        /// </summary>
        /// <param name="photoId"><seealso cref="Photo"/> identifier</param>
        /// <param name="passphrase">Shared <seealso cref="Album"/> passphrase</param>
        /// <returns>Photo as byte array</returns>
        Task<byte[]> DownloadPhoto(int photoId, string passphrase);

        /// <summary>
        /// Download <seealso cref="Photo"/> from shared <seealso cref="Album"/> as byte array
        /// </summary>
        /// <param name="photo"><seealso cref="Photo"/> to download</param>
        /// <param name="album">Source <seealso cref="Album"/></param>
        /// <returns></returns>
        Task<byte[]> DownloadPhoto(Photo photo, Album album);

		/// <summary>
		/// Add item to album
		/// </summary>
		/// <returns>true if no errors were sent as result of operation, otherwise false</returns>
		Task<bool> AddItemToAlbum(Photo item, Album album);

		/// <summary>
		/// Search for <seealso cref="Photo"/> by filter
		/// </summary>
		/// <param name="searchFilter">Search filtering for photos</param>
		/// <returns>List of photos</returns>
		Task<IEnumerable<Photo>> SearchForPhotos(SearchFilter? searchFilter = null);
	}
}
