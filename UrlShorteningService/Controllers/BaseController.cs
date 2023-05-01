using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Security.Authentication;
using UrlShorteningService.Business.Validators;
using UrlShorteningService.Core.Requests;
using UrlShorteningService.Core.Resources;
using UrlShorteningService.Core.Responses;

namespace UrlShorteningService.Controllers
{
	public class BaseController : ControllerBase
	{
		public TResponse ProcessRequest<TRequest, TResponse>(TRequest request,
			Func<TRequest, TResponse> func, IRequestValidator validator)
			where TRequest : BaseRequest, new()
			where TResponse : BaseResponse, new()
		{
			TResponse response;

			try
			{
				validator.Validate();
				Authorize(request.AuthData?.ServiceUser, request.AuthData?.ServicePassword);

				response = func.Invoke(request);

			}
			catch (AuthenticationException ex)
			{
				response = new TResponse() 
				{ 
					ResponseCode = Core.Enums.ResponseCode.AuthenticationError, 
					ResponseMessage = ex.Message 
				};
			}
			catch (ValidationException ex)
			{
				response = new TResponse()
				{
					ResponseCode = Core.Enums.ResponseCode.ParameterError,
					ResponseMessage = ex.Message
				};
			}
			catch (Exception ex)
			{
				//log.ErrorFormat("ERROR BaseController: {0}", ex);

				response = new TResponse()
				{
					ResponseCode = Core.Enums.ResponseCode.GeneralError,
					ResponseMessage = ResponseMessages.GeneralErrorMessage
				};
			}

			//request-response logging can be handled here.

			return response;
		}

		private void Authorize(string? user, string? password)
		{
			//if needed, user-password based auth can be implemented here.
			if (false)
				throw new AuthenticationException(ResponseMessages.AuthenticationErrorMessage);
		}
	}
}
