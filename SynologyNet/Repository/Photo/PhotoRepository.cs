using RestSharp;
using SynologyNet.Attributes;
using SynologyNet.Models;
using SynologyNet.Models.Photo;
using System.Threading.Tasks;

namespace SynologyNet.Repository
{
    [SynologyRepository(DefaultPath = "entry.cgi", RequiresAuthentication = true)]
    public class PhotoRepository : BaseRepository
    {
        [Request(Api = "SYNO.Foto.Browse.RecentlyAdded", Method = "list", Version = 3)]
        public async Task<BaseDataResponse<ListObject<Photo>>> GetRecentlyAddedPhotos(int offset = 0, int limit = 100)
        {
            var request = PrepareRequest();
            request.AddParameter("offset", offset);
            request.AddParameter("limit", limit);

            return await _client.GetAsync<BaseDataResponse<ListObject<Photo>>>(request);
        }

        [Request(Api = "SYNO.Foto.Sharing.Misc", Method = "list_shared_with_me_album", Version = 1)]
        public async Task<BaseDataResponse<ListObject<Album>>> GetSharedAlbums(int offset = 0, int limit = 100)
        {
            var request = PrepareRequest();
            request.AddParameter("offset", offset);
            request.AddParameter("limit", limit);

            return await _client.GetAsync<BaseDataResponse<ListObject<Album>>>(request);
        }

        [Request(Api = "SYNO.Foto.Browse.Item", Method = "list")]
        public async Task<BaseDataResponse<ListObject<Photo>>> GetPhotosFromAlbum(int offset = 0, int limit = 100, string passphrase = null)
        {
            var request = PrepareRequest();
            request.AddParameter("offset", offset);
            request.AddParameter("limit", limit);
            request.AddParameter("type", "photo");
            request.AddParameter("passphrase", passphrase);

            return await _client.GetAsync<BaseDataResponse<ListObject<Photo>>>(request);
        }

        [Request(Api = "SYNO.Foto.Download", Method = "download")]
        public async Task<byte[]> DownloadPhoto(int photoId, string passphrase)
        {
            var request = PrepareRequest();
            request.AddParameter("passphrase", passphrase);
            request.AddParameter("unit_id", $"[{photoId}]");

            return await _client.DownloadDataAsync(request);
        }
    }
}
