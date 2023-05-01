using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShorteningService.Core.Resources
{
	public static class ResponseMessages
	{
		public static string SuccessMessage = "Operation successful.";
		public static string GeneralErrorMessage = "An unexpected error occurred.";
		public static string AuthenticationErrorMessage = "Unauthorized access.";
		public static string DuplicateHashPortionErrorMessage = "Invalid custom url, hash portion already exist.";
		public static string ShortenedUrlNotFoundMessage = "Invalid shortened url.";
		public static string TimeoutErrorMessage = "The request could not be executed in a specific time period. Please try again.";
	}
}
