using System.Text.Json.Serialization;

namespace SynologyNet.Models.Responses.FileStation;

public class SharedFolder
{
	[JsonPropertyName("name")]
	public string Name { get; set; }
	
	[JsonPropertyName("path")]
	public string Path { get; set; }
}
