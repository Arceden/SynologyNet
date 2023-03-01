using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using RestSharp;
using SynologyNet.Attributes;
using SynologyNet.Models.Requests.File.Filters;
using SynologyNet.Models.Requests.Photo.Filters;
using SynologyNet.Models.Responses;
using SynologyNet.Models.Responses.FileStation;

namespace SynologyNet.Repository.FileStation;

[SynologyRepository(DefaultPath = "entry.cgi", RequiresAuthentication = true)]
class FileStationRepository : BaseRepository
{
	[Request(Api = "SYNO.FileStation.Info", Method = "get", Version = 2)]
	public Task<BaseDataResponse<Info>> Info()
	{
		return _client.GetAsync<BaseDataResponse<Info>>(PrepareRequest());
	}
	
	[Request(Api = "SYNO.FileStation.List", Method = "list_share", Version = 2)]
	public async Task<BaseDataResponse<ListSharedFolders>> ListSharedFolders()
	{
		var request = PrepareRequest();
		return await _client.GetAsync<BaseDataResponse<ListSharedFolders>>(request);
	}
	
	[Request(Api = "SYNO.FileStation.DirSize", Method = "start", Version = 2)]
	public async Task<BaseDataResponse<DirSizeStart>> DirSizeStart(string path)
	{
		var request = PrepareRequest();
		request.AddParameter("path", path);
		return await _client.GetAsync<BaseDataResponse<DirSizeStart>>(request);
	}
	
	[Request(Api = "SYNO.FileStation.DirSize", Method = "status", Version = 2)]
	public async Task<BaseDataResponse<DirSize>> DirSizeStatus(string taskid)
	{
		var request = PrepareRequest();
		request.AddParameter("taskid", taskid);
		return await _client.GetAsync<BaseDataResponse<DirSize>>(request);
	}

	[Request( Api = "SYNO.FileStation.List", Method = "list", Version = 2 )]
	public async Task<BaseDataResponse<ListSharedFolderItems>> ListSharedFolderItems( string path, bool recursive )
	{
		IFilter filter = new FolderNameFilter {
			FolderPath = path
		};
		var request = PrepareRequest( filter );
		return await _client.GetAsync<BaseDataResponse<ListSharedFolderItems>>( request );
	}

	[Request( Api = "SYNO.FileStation.Download", Method = "download", Version = 2 )]
	public async Task<Stream> DownloadFile( string path ) {
		var request = PrepareRequest();
		request.AddParameter("path", path);
		request.AddParameter("mode", "open");
		return await _client.DownloadStreamAsync( request );
	}

	private HttpMessageHandler MsgHandler( HttpMessageHandler arg ) {
		throw new NotImplementedException();
	}
}
