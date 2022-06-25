using SynologyNet.Models;
using SynologyNet.Repository;
using SynologyNet.Services.Interfaces;
using System.Threading.Tasks;

namespace SynologyNet.Services
{
    public class GeneralService : IGeneralService
    {
        private InformationRepository Repository { get; } 

        public GeneralService()
            => Repository = new InformationRepository();

        public async Task<InformationList> GetApiInformation()
        {
            return await Repository.GetInfo();
        }
    }
}
