using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SynologyNet.Models.Responses.FileStation {
	public class ListSharedFolderItems {
		[JsonPropertyName( "files" )]
		public ICollection<SharedFolderItem> Files { get; set; }

		[JsonPropertyName( "total" )]
		public int Total { get; set; }

		[JsonPropertyName( "offset" )]
		public int Offset { get; set; }
	}
}
