using RestSharp;
using SynologyNet.Attributes;
using SynologyNet.Models;
using System.Threading.Tasks;

namespace SynologyNet.Repository
{
    [SynologyRepository(DefaultPath = "entry.cgi", RequiresAuthentication = true)]
    public class PhotoRepository : BaseRepository
    {
        [Request(Api = "SYNO.Foto.Browse.RecentlyAdded", Method = "list", Version = 3)]
        public async Task<BaseDataResponse<Models.Photo.ListObject<Models.Photo.Photo>>> GetRecentlyAddedPhotos()
        {
            var request = PrepareRequest();
            request.AddParameter("offset", 0);
            request.AddParameter("limit", 100);

            return await _client.GetAsync<BaseDataResponse<Models.Photo.ListObject<Models.Photo.Photo>>>(request);
        }

        [Request(Api = "SYNO.Foto.Sharing.Misc", Method = "list_shared_with_me_album", Version = 1)]
        public async Task<BaseDataResponse<Models.Photo.ListObject<Models.Photo.Album>>> GetSharedAlbums()
        {
            var request = PrepareRequest();
            request.AddParameter("offset", 0);
            request.AddParameter("limit", 100);

            return await _client.GetAsync<BaseDataResponse<Models.Photo.ListObject<Models.Photo.Album>>>(request);
        }

        [Request(Api = "SYNO.Foto.Browse.Item", Method = "list")]
        public async Task<BaseDataResponse<Models.Photo.ListObject<Models.Photo.Photo>>> GetPhotosFromAlbum(Models.Photo.Album album)
        {
            var request = PrepareRequest();
            request.AddParameter("offset", 0);
            request.AddParameter("limit", 100);
            request.AddParameter("type", "photo");
            request.AddParameter("passphrase", album.Passphrase);

            return await _client.GetAsync<BaseDataResponse<Models.Photo.ListObject<Models.Photo.Photo>>>(request);
        }

        [Request(Api = "SYNO.Foto.Download", Method = "download")]
        public async Task<byte[]> DownloadPhoto(Models.Photo.Photo photo, string passphrase)
        {
            var request = PrepareRequest();
            request.AddParameter("passphrase", passphrase);
            request.AddParameter("unit_id", $"[{photo.Id}]");

            return await _client.DownloadDataAsync(request);
        }
    }
}
