# Synology.Net
Class library to act as a wrapper for the Synology Api.

## Example usage
```csharp
using SynologyNet;

var synology = new Synology(host, username, password);

// Login
await synology.Authentication.Login()

// Get shared albums
var albums = await synology.Photo.GetSharedAlbums();

// Get camera objects
var cameras = await synology.SurveillanceStation.GetCameras();
```