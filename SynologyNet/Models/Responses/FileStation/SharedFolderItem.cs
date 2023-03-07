using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SynologyNet.Models.Responses.FileStation {
	public class SharedFolderItem {
		[JsonPropertyName( "name" )]
		public string Name { get; set; }

		[JsonPropertyName( "path" )]
		public string Path { get; set; }

		[JsonPropertyName( "isdir" )]
		public bool IsDir { get; set; }
	}
}
