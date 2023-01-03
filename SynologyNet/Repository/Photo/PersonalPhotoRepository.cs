using RestSharp;
using SynologyNet.Attributes;
using SynologyNet.Helpers;
using SynologyNet.Models.Requests.Photo;
using SynologyNet.Models.Responses;
using SynologyNet.Models.Responses.Photo;
using System.Text.Json;
using System.Threading.Tasks;

namespace SynologyNet.Repository
{
    [SynologyRepository(DefaultPath = "entry.cgi", RequiresAuthentication = true)]
    class PersonalPhotoRepository : BaseRepository
    {
        [Request(Api = "SYNO.Foto.Browse.Folder", Method = "list")]
        public async Task<BaseDataResponse<ListObject<Folder>>> GetFolders(CollectionFilter? collectionFilter = null)
        {
            collectionFilter ??= new();

            var request = PrepareRequest();
            request.AddParameter("offset", collectionFilter.Offset);
            request.AddParameter("limit", collectionFilter.Limit);
            request.AddParameter("sort_by", collectionFilter.SortBy.GetValue());
            request.AddParameter("sort_direction", collectionFilter.SortDirection.GetValue());

            return await _client.GetAsync<BaseDataResponse<ListObject<Folder>>>(request);
        }

        [Request(Api = "SYNO.Foto.Browse.Album", Method = "list")]
        public async Task<BaseDataResponse<ListObject<Album>>> GetAlbums(CollectionFilter? collectionFilter = null)
        {
            collectionFilter ??= new();

            var request = PrepareRequest();
            request.AddParameter("offset", collectionFilter.Offset);
            request.AddParameter("limit", collectionFilter.Limit);
            request.AddParameter("sort_by", collectionFilter.SortBy.GetValue());
            request.AddParameter("sort_direction", collectionFilter.SortDirection.GetValue());

            var b = await _client.GetAsync(request);

            return await _client.GetAsync<BaseDataResponse<ListObject<Album>>>(request);
        }

        [Request(Api = "SYNO.Foto.Sharing.Misc", Method = "list_shared_with_me_album", Version = 1)]
        public async Task<BaseDataResponse<ListObject<Album>>> GetSharedAlbums(CollectionFilter? collectionFilter = null)
        {
            collectionFilter ??= new();

            var request = PrepareRequest();
            request.AddParameter("offset", collectionFilter.Offset);
            request.AddParameter("limit", collectionFilter.Limit);
            request.AddParameter("sort_by", collectionFilter.SortBy.GetValue());
            request.AddParameter("sort_direction", collectionFilter.SortDirection.GetValue());

            return await _client.GetAsync<BaseDataResponse<ListObject<Album>>>(request);
        }

        [Request(Api = "SYNO.Foto.Browse.Item", Method = "list")]
        public async Task<BaseDataResponse<ListObject<Photo>>> GetAlbumPhotos(string passphrase = null, CollectionFilter? collectionFilter = null)
        {
            collectionFilter ??= new();

            var request = PrepareRequest();
            request.AddParameter("offset", collectionFilter.Offset);
            request.AddParameter("limit", collectionFilter.Limit);
            request.AddParameter("sort_by", collectionFilter.SortBy.GetValue());
            request.AddParameter("sort_direction", collectionFilter.SortDirection.GetValue());
            request.AddParameter("type", "photo");
            request.AddParameter("passphrase", passphrase);

            return await _client.GetAsync<BaseDataResponse<ListObject<Photo>>>(request);
        }

        [Request(Api = "SYNO.Foto.Browse.RecentlyAdded", Method = "list", Version = 3)]
        public async Task<BaseDataResponse<ListObject<Photo>>> GetRecentlyAddedPhotos(CollectionFilter? collectionFilter = null)
        {
            collectionFilter ??= new();

            var request = PrepareRequest();
            request.AddParameter("offset", collectionFilter.Offset);
            request.AddParameter("limit", collectionFilter.Limit);

            return await _client.GetAsync<BaseDataResponse<ListObject<Photo>>>(request);
        }

        [Request(Api = "SYNO.Foto.Download", Method = "download")]
        public async Task<byte[]> DownloadPhoto(int photoId, string passphrase)
        {
            var request = PrepareRequest();
            request.AddParameter("unit_id", $"[{photoId}]");
            request.AddParameterIfNotNull("passphrase", passphrase);

            return await _client.DownloadDataAsync(request);
        }
    }
}
