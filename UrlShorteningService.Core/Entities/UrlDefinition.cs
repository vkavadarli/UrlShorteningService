using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShorteningService.Core.Entities
{
	public class UrlDefinition
	{
		public int Id { get; set; }
		public string OriginalUrl { get; set; }
		public string ShortenedUrl { get; set; }
	}
}
