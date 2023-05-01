using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShorteningService.Core.Responses
{
	public class RedirectionResponse : BaseResponse
	{
		public string OriginalUrl { get; set; }
	}
}
