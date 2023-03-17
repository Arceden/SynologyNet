using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SynologyNet.Models.Requests.Photo.Filters
{
	/// <summary>
	/// Search filter for items
	/// </summary>
	public class SearchFilter : PagingFilter
	{
		/// <summary>
		/// Search items by a keyword
		/// </summary>
		[JsonPropertyName("keyword")]
		public string Keyword { get; set; }
	}
}