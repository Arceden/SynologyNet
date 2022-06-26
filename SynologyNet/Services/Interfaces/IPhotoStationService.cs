namespace SynologyNet.Services.Interfaces
{
    /// <summary>
    /// PhotoStationService interface
    /// </summary>
    public interface IPhotoStationService
    {
        /// <summary>
        /// Access photos and folders within the Personal Space of the Synology Photos API
        /// </summary>
        IPhotoStationPersonalService Personal { get; }

        /// <summary>
        /// Access photos and folders within the Shared Space of the Synology Photos API
        /// </summary>
        IPhotoStationSharedService Shared { get; }
    }
}
