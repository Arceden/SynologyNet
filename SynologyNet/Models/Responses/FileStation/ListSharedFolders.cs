using System.Collections;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SynologyNet.Models.Responses.FileStation;

public class ListSharedFolders
{
	[JsonPropertyName("shares")]
	public ICollection<SharedFolder> SharedFolders { get; set; }
	
	[JsonPropertyName("total")]
	public int Total { get; set; }
	
	[JsonPropertyName("offset")]
	public int Offset { get; set; }
}
