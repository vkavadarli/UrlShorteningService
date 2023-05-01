using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShorteningService.Core.Requests
{
	public class RedirectionRequest : BaseRequest
	{
        public string ShortenedUrl { get; set; }
    }
}
