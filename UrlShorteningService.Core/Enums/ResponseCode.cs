using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShorteningService.Core.Enums
{
	public enum ResponseCode
	{
		Success = 1200,
		AuthenticationError = 1401,
		ParameterError = 1402,
		GeneralError = 1500
	}
}
