using System.Text.Json.Serialization;
using SynologyNet.Models.Requests.Photo.Filters;

namespace SynologyNet.Models.Requests.File.Filters {
	internal class FolderNameFilter : IFilter {
		[JsonPropertyName( "folder_path" )]
		public string FolderPath { get; set; }
	}
}
