using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using SynologyNet.Models.Responses;
using SynologyNet.Models.Responses.FileStation;
using SynologyNet.Repository.FileStation;
using SynologyNet.Services.Interfaces;

namespace SynologyNet.Services
{
    public class FileStationService : BaseService, IFileStationService
    {
        private FileStationRepository Repository = new FileStationRepository();

        public async Task<Info> Info()
        {
            var response = await Repository.Info();
            CheckErrorCode(response);
            return response.Data;
        }
        
        public async Task<ListSharedFolders> ListSharedFolders()
        {
            var response = await Repository.ListSharedFolders();
            CheckErrorCode(response);
            return response.Data;
        }
        
        public async Task<DirSize> DirSize(string path)
        {
            var startResponse = await Repository.DirSizeStart(path);
            CheckErrorCode(startResponse);
            var taskid = startResponse.Data.TaskId;

            BaseDataResponse<DirSize> response = null;
            do
            {
                await Task.Delay(500);
                response = await Repository.DirSizeStatus(taskid);
                CheckErrorCode(response);
            } while(response.Data.Finished == false);

            return response.Data;
        }

        public async Task<ListSharedFolderItems> ListSharedFolderItems( string path, bool recursive )
        {
            var response = await Repository.ListSharedFolderItems( path, recursive );
            CheckErrorCode( response );
            return response.Data;
        }

        public async Task<Stream> DownloadFile( string path ) { 
            var response = await Repository.DownloadFile( path );
            return response;
        }
    }
}
