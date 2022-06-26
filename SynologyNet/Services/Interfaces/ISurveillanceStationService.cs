using SynologyNet.Models.Responses.Surveillance;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SynologyNet.Services.Interfaces
{
    public interface ISurveillanceStationService
    {
        /// <summary>
        /// Get LiveViewPathInformation objects for all cameras
        /// </summary>
        /// <returns>List of LiveViewPathInfo objects</returns>
        Task<IEnumerable<LiveViewPathInfo>> GetLiveViewPaths();

        /// <summary>
        /// Get LiveViewPathInformation objects for the specified cameras
        /// </summary>
        /// <param name="cameraIds">Camera identifiers</param>
        /// <returns>List of LiveViewPathInfo objects</returns>
        Task<IEnumerable<LiveViewPathInfo>> GetLiveViewPaths(int[] cameraIds);

        /// <summary>
        /// Get list of available cameras
        /// </summary>
        /// <returns>List of Camera objects</returns>
        Task<IEnumerable<Camera>> GetCameras();
    }
}
