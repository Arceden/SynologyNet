using SynologyNet.Models.Responses.Surveillance;
using SynologyNet.Repository;
using SynologyNet.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynologyNet.Services
{
    public class SurveillanceStationService : BaseService, ISurveillanceStationService
    {
        private SurveillanceRepository Repository { get; set; }

        public SurveillanceStationService()
            => Repository = new SurveillanceRepository();

        public async Task<IEnumerable<LiveViewPathInfo>> GetLiveViewPaths()
        {
            var cameras = await GetCameras();
            var ids = cameras.Select(c => c.Id).ToArray();

            return await GetLiveViewPaths(ids);
        }

        public async Task<IEnumerable<LiveViewPathInfo>> GetLiveViewPaths(int[] cameraIds)
        {
            var response = await Repository.GetLiveViewPaths(cameraIds);

            CheckErrorCode(response);

            return response.Data;
        }

        public async Task<IEnumerable<Camera>> GetCameras()
        {
            var response = await Repository.GetCameras();

            CheckErrorCode(response);

            return response.Data.Cameras;
        }
    }
}
