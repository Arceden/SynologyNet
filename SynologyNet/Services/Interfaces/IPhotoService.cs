using SynologyNet.Models.Photo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SynologyNet.Services.Interfaces
{
    public interface IPhotoService
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
        /// Get list of photos from a specified album
        /// </summary>
        /// <param name="album">Album to get photos from</param>
        /// <returns>List of photos</returns>
        Task<IEnumerable<Photo>> GetPhotosFromAlbum(Album album);
    }
}
