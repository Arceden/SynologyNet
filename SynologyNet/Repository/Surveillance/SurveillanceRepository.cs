using RestSharp;
using SynologyNet.Attributes;
using SynologyNet.Models.Responses.Surveillance;
using System;
using System.Threading.Tasks;

namespace SynologyNet.Repository
{
    [SynologyRepository(DefaultPath = "entry.cgi")]
    public class SurveillanceRepository : BaseRepository
    {
        [Request(Api = "SYNO.SurveillanceStation.Info", Method = "GetInfo", Version = 8)]
        public async Task<SurveillanceInformation> GetInfo()
        {
            return await _client.GetAsync<SurveillanceInformation>(PrepareRequest());
        }

        [Request(Api = "SYNO.SurveillanceStation.Camera", Method = "List", Version = 9, RequiresAuthentication = true)]
        public async Task<CameraList> GetCameras()
        {
            var request = PrepareRequest();
            request.AddParameter("privCamType", 1);
            request.AddParameter("camStm", 0);
            request.AddParameter("basic", true);
            request.AddParameter("streamInfo", true);

            return await _client.GetAsync<CameraList>(request);
        }

        [Request(Api = "SYNO.SurveillanceStation.Camera", Method = "GetLiveViewPath", Version = 9, RequiresAuthentication = true)]
        public async Task<LiveViewPathInfoContainer> GetLiveViewPaths(int[] cameraIds)
        {
            var request = PrepareRequest();
            request.AddParameter("idList", String.Join(",", cameraIds));

            return await _client.GetAsync<LiveViewPathInfoContainer>(request);
        }
    }
}