using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShorteningService.Core.Models;

namespace UrlShorteningService.Core.Requests
{
	public class BaseRequest
	{
		public AuthorizationData? AuthData { get; set; }
	}
}
