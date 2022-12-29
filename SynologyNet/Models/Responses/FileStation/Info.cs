using System.Text.Json.Serialization;

namespace SynologyNet.Models.Responses.FileStation;

public class Info
{
	[JsonPropertyName("is_manager")]
	public bool IsManager { get; set; }
	
	[JsonPropertyName("support_virtual_protocol")]
	public string SupportVirtualProtocol { get; set; }
	
	[JsonPropertyName("support_sharing")]
	public bool SupportSharing { get; set; }
	
	[JsonPropertyName("hostname")]
	public string Hostname { get; set; }
}
