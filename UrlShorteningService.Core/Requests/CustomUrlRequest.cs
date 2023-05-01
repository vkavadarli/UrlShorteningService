using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShorteningService.Core.Requests
{
	public class CustomUrlRequest : BaseRequest
	{
		public string OriginalUrl { get; set;}
        public string CustomUrl { get; set; }
    }
}
