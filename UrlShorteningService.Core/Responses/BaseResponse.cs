using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShorteningService.Core.Enums;

namespace UrlShorteningService.Core.Responses
{
	public class BaseResponse
	{
		public ResponseCode ResponseCode { get; set; }
		public string ResponseMessage { get; set; }
	}
}
