using Microsoft.Extensions.Configuration;
using SynologyNet;
using SynologyNet.Models.Requests.Photo;
using System;
using System.Linq;

var config = new ConfigurationBuilder()
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddUserSecrets<Program>()
    .Build();

var host = config["Synology:Host"];
var username = config["Synology:Username"];
var password = config["Synology:Password"];
var synology = new Synology(host, username, password);

// General
var info = await synology.General.GetApiInformation();

// Login
await synology.Authentication.Login();

// Photos
var photoStation = synology.PhotoStation.Personal;

var a = (await photoStation.GetAlbums(new CollectionFilter() { Limit = 2, Offset = 0, SortDirection = SortDirectionType.Desc })).ToList();
a.ForEach(async e =>
    {
        Console.WriteLine(e.Name);

        var b = (await photoStation.GetAlbumPhotos(e, new CollectionFilter() { SortBy = SortByType.CreatedTime })).ToList();
        b.ForEach(n => Console.WriteLine($"\t{n.Filename}"));
    }
);



//var folders = await photoStation.GetFolders();
//var recentlyAddedPhotos = await photoStation.GetRecentlyAddedPhotos();
//var sharedAlbums = await photoStation.GetSharedAlbums();
//var sharedPhotos = await photoStation.GetAlbumPhotos(sharedAlbums.First());
//var sharedPhotoFile = await photoStation.DownloadPhoto(sharedPhotos.First().Id, sharedAlbums.First().Passphrase);
//var albums = await photoStation.GetAlbums();
//var photos = await photoStation.GetAlbumPhotos(albums.First());
//var photoFile = await photoStation.DownloadPhoto(photos.First().Id);

// Surveillance
var cameras = await synology.SurveillanceStation.GetCameras();
var liveViewPaths = await synology.SurveillanceStation.GetLiveViewPaths();

// Logout
await synology.Authentication.Logout();

Console.WriteLine("Waiting for user input..");
Console.ReadKey();