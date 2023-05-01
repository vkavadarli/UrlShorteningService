using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShorteningService.Core.Responses
{
	public class ShorteningResponse : BaseResponse
	{
		public string ShortenedUrl { get; set; }
	}
}
