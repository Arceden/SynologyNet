using System.IO;
using System.Threading.Tasks;
using SynologyNet.Models.Responses.FileStation;

namespace SynologyNet.Services.Interfaces
{
    /// <summary>
    /// FileStationService interface
    /// </summary>
    public interface IFileStationService
    {
        Task<Info> Info();
        
        Task<ListSharedFolders> ListSharedFolders();
        
        Task<DirSize> DirSize(string path);
        
        Task<ListSharedFolderItems> ListSharedFolderItems( string path, bool recursive );
        
        Task<Stream> DownloadFile( string path );
    }
}