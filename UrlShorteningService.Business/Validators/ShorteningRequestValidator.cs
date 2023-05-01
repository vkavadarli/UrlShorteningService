using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShorteningService.Core.Requests;

namespace UrlShorteningService.Business.Validators
{
	public class ShorteningRequestValidator : IRequestValidator
	{
		public ShorteningRequest request;

		public ShorteningRequestValidator(ShorteningRequest request)
		{
			this.request = request;
		}

		public void Validate()
		{
			if (String.IsNullOrEmpty(request.OriginalUrl))
			{
				throw new ValidationException("Original Url is empty");
			}

			if (!CheckUrl(request.OriginalUrl)) 
			{
				throw new ValidationException("Original Url is not a valid url");
			}
		}

		private bool CheckUrl(string url) 
		{
			Uri uriResult;
			bool result = Uri.TryCreate(url, UriKind.Absolute, out uriResult)
				&& (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

			return result;
		}
	}
}
