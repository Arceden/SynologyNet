using System.Threading.Tasks;
using RestSharp;
using SynologyNet.Attributes;
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
}
