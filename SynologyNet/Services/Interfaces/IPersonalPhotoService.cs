using SynologyNet.Models.Responses.Photo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SynologyNet.Services.Interfaces
{
    public interface IPersonalPhotoService
    {
        /// <summary>
        /// Get list of recently added photos
        /// </summary>
        /// <returns>List of photos</returns>
        Task<IEnumerable<Photo>> GetRecentlyAddedPhotos();

        /// <summary>
        /// Get list of shared albums with the current user
        /// </summary>
        /// <returns>List of shared albums</returns>
        Task<IEnumerable<Album>> GetSharedAlbums();

        /// <summary>
        /// Get list of albums made by the current user
        /// </summary>
        /// <returns>List of albums</returns>
        Task<IEnumerable<Album>> GetAlbums();

        /// <summary>
        /// Get list of photos from a specified album
        /// </summary>
        /// <param name="album">Album to get photos from</param>
        /// <returns>List of photos</returns>
        Task<IEnumerable<Photo>> GetAlbumPhotos(Album album);

        /// <summary>
        /// Get list of folders
        /// </summary>
        /// <returns>List of folders</returns>
        Task<IEnumerable<Folder>> GetFolders();

        /// <summary>
        /// Download photo as byte array
        /// </summary>
        /// <param name="photoId">Photo identifier</param>
        /// <returns>Photo as byte array</returns>
        Task<byte[]> DownloadPhoto(int photoId);

        /// <summary>
        /// Download photo from shared album as byte array
        /// </summary>
        /// <param name="photoId">Photo identifier</param>
        /// <param name="passphrase">Shared album passphrase</param>
        /// <returns>Photo as byte array</returns>
        Task<byte[]> DownloadPhoto(int photoId, string passphrase);
    }
}
