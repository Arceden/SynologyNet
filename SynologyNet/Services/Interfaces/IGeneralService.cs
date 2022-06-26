using SynologyNet.Models.Responses;
using System.Threading.Tasks;

namespace SynologyNet.Services.Interfaces
{
    /// <summary>
    /// GeneralService interface
    /// </summary>
    public interface IGeneralService
    {
        /// <summary>
        /// Get list of Synology API information items
        /// </summary>
        /// <returns>Synology API Information list</returns>
        Task<InformationList> GetApiInformation();
    }
}
