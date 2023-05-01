using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UrlShorteningService.Business.Validators;
using UrlShorteningService.Core.Requests;
using UrlShorteningService.Core.Responses;
using UrlShorteningService.Core.Services;

namespace UrlShorteningService.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class UrlShorteningController : BaseController
	{
		public IUrlService _service;

		public UrlShorteningController(IUrlService service)
		{
			this._service = service;
		}

		[HttpPost]
		public ShorteningResponse Shortening(ShorteningRequest request)
		{
			var validator = new ShorteningRequestValidator(request);
			return ProcessRequest(request, _service.Shortening, validator);
		}

		[HttpGet]
		public RedirectResult Redirection(string shortenedUrl)
		{
			var request = new RedirectionRequest { ShortenedUrl = shortenedUrl };

			var validator = new RedirectionRequestValidator(request);

			var response = ProcessRequest(request, _service.Redirection, validator);

			//if response has error, then redirect to a custom error page.
			return Redirect(response.OriginalUrl);
		}

		[HttpPost]
		public CustomUrlResponse CustomUrl(CustomUrlRequest request)
		{
			var validator = new CustomUrlRequestValidator(request);

			return ProcessRequest(request, _service.CustomUrl, validator);			
		}
	}
}
