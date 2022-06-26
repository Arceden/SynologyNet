using RestSharp;
using SynologyNet.Attributes;
using SynologyNet.Models.Responses;
using System.Threading.Tasks;

namespace SynologyNet.Repository
{
    [SynologyRepository(DefaultApi = "SYNO.API.Info", DefaultPath = "query.cgi")]
    public class InformationRepository : BaseRepository
    {
        [Request(Version = 1, Method = "query")]
        public async Task<InformationList> GetInfo()
        {
            return await _client.GetAsync<InformationList>(PrepareRequest());
        }
    }
}
