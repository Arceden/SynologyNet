# Synology.Net
Class library to act as a wrapper for the Synology Api.

## Example usage
```csharp
using SynologyNet;

var synology = new Synology(host, username, password);

// Login
await synology.Authentication.Login()

// Synology Photo / Personal Space
var photoStation = synology.PhotoStation.Personal;
var sharedAlbums = await photoStation.GetSharedAlbums();
var sharedPhotos = await photoStation.GetAlbumPhotos(sharedAlbums.First());

// Synology Surveillance Station
var cameras = await synology.SurveillanceStation.GetCameras();
var liveViewPaths = await synology.SurveillanceStation.GetLiveViewPaths();

// Logout
await synology.Authentication.Logout();
```