using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShorteningService.Core.Requests;
using UrlShorteningService.Core.Responses;

namespace UrlShorteningService.Core.Services
{
	public interface IUrlService
	{
		ShorteningResponse Shortening(ShorteningRequest request);
		RedirectionResponse Redirection(RedirectionRequest request);
		CustomUrlResponse CustomUrl(CustomUrlRequest request);
	}
}
