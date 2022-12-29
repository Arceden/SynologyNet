using System.Text.Json.Serialization;

namespace SynologyNet.Models.Responses.FileStation;

public class DirSize
{
	[JsonPropertyName("finished")]
	public bool Finished { get; set; }
	
	[JsonPropertyName("total_size")]
	public long TotalSize { get; set; }
}
