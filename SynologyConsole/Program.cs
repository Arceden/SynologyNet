using Microsoft.Extensions.Configuration;
using SynologyNet;
using SynologyNet.Models.Requests.Filters;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

var config = new ConfigurationBuilder()
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddUserSecrets<Program>()
    .Build();




//var filter = new SortableFilter() { SortBy = SortByType.ModifiedTime };

//var type = filter.GetType();
//var property = type.GetProperty("SortBy");
//var value = property.GetValue(filter, null);

//var valueType = value.GetType();
//var valueMember = valueType.GetMember(value.ToString());
//var valueAttribute = valueMember.FirstOrDefault().GetCustomAttribute<EnumMemberAttribute>(false);
//var endValue = valueAttribute?.va;


//Console.WriteLine();

var host = config["Synology:Host"];
var username = config["Synology:Username"];
var password = config["Synology:Password"];
var synology = new Synology(host, username, password);


// General
var info = await synology.General.GetApiInformation();

// Login
await synology.Authentication.Login();

var photoStation = synology.PhotoStation.Personal;

foreach (var album in await photoStation.GetAlbums())
{
    Console.WriteLine(album.Name);
}

//// Photos
//var photoStation = synology.PhotoStation.Personal;

//// Personal albums and photos
//Console.WriteLine("My albums");
//var albums = await photoStation.GetAlbums(new CollectionFilter() { Offset = 0, SortDirection = SortDirectionType.Desc });
//foreach (var album in albums)
//{
//    Console.WriteLine($" - {album.Name}");

//    var photos = await photoStation.GetAlbumPhotos(album);

//    foreach (var photo in photos)
//        Console.WriteLine($"\t+ {photo.Filename}");
//}
//Console.WriteLine();

//// Shared with me
//Console.WriteLine("Shared with me");
//var sharedAlbums = await photoStation.GetSharedAlbums();
//foreach (var album in sharedAlbums)
//{
//    Console.WriteLine($" - {album.Name} {album.Shared}");

//    var photos = await photoStation.GetSharedAlbumPhotos(album);

//    foreach (var photo in photos)
//        Console.WriteLine($"\t+ {photo.Filename}");
//}
//Console.WriteLine();

//// Download own photo
//Console.WriteLine("Download a photo from my own list");
//var photoToDownload = (await photoStation.GetPhotos(new CollectionFilter() { Limit = 1 })).FirstOrDefault();
//Console.WriteLine($" - Downloading {photoToDownload.Filename}");
//var a = await photoStation.DownloadPhoto(photoId: photoToDownload.Id);
//using var stream = File.Create($"./{photoToDownload.Filename}");
//stream.Write(a, 0, a.Length);
//Console.WriteLine($"\t+ File downloaded: {a.Length} of {photoToDownload.FileSize} bytes");
//Console.WriteLine();

//// Download shared photo
//Console.WriteLine("Download a photo from a shared album");
//var sharedPhotoToDownload = (await photoStation.GetSharedAlbumPhotos(sharedAlbums.First())).FirstOrDefault();
//Console.WriteLine($" - Downloading {sharedPhotoToDownload.Filename}");
//var b = await photoStation.DownloadPhoto(sharedPhotoToDownload.Id, sharedAlbums.First().Passphrase);
//using var stream2 = File.Create($"./{sharedPhotoToDownload.Filename}");
//stream2.Write(b, 0, b.Length);
//Console.WriteLine($"\t+ File downloaded: {b.Length} of {sharedPhotoToDownload.FileSize} bytes");
//Console.WriteLine();

//// Misc
//var folders = await photoStation.GetFolders();
//var recentlyAddedPhotos = await photoStation.GetRecentlyAddedPhotos();

//// Surveillance
//var cameras = await synology.SurveillanceStation.GetCameras();
//var liveViewPaths = await synology.SurveillanceStation.GetLiveViewPaths();

// Logout
//await synology.Authentication.Logout();

Console.WriteLine("Waiting for user input..");
Console.ReadKey();