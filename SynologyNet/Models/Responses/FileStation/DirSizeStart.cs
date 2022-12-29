using System.Text.Json.Serialization;

namespace SynologyNet.Models.Responses.FileStation;

public class DirSizeStart
{
	[JsonPropertyName("taskid")]
	public string TaskId { get; set; }
}
