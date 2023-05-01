using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShorteningService.Core.Requests;

namespace UrlShorteningService.Business.Validators
{
	public class RedirectionRequestValidator : IRequestValidator
	{
		public RedirectionRequest request;

		public RedirectionRequestValidator(RedirectionRequest request)
		{
			this.request = request;
		}

		public void Validate()
		{
			
		}
	}
}
