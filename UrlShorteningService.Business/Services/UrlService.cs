using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShorteningService.Business.Handlers;
using UrlShorteningService.Core.Entities;
using UrlShorteningService.Core.Repositories;
using UrlShorteningService.Core.Requests;
using UrlShorteningService.Core.Resources;
using UrlShorteningService.Core.Responses;
using UrlShorteningService.Core.Services;

namespace UrlShorteningService.Business.Services
{
	public class UrlService : IUrlService
	{
		private readonly IUrlDefinitionRepository _repository;
		private readonly TransactionLocker transactionLocker;

		//these fields can be moved to configurations
		private const int retryCount = 10;
		private const string shortUrlBase = "http://sample.site/";

		public UrlService(IUrlDefinitionRepository urlDefinitionRepository, TransactionLocker transactionLocker)
		{
			this._repository = urlDefinitionRepository;
			this.transactionLocker = transactionLocker;
		}

		public ShorteningResponse Shortening(ShorteningRequest request)
		{
			int retry = 0;
			var maxId = _repository.GetMaxId();
			bool locked = false;

			int newId = maxId + 1;

			while (retry < retryCount && !locked) 
			{
				newId = newId + retry;
				locked = transactionLocker.Lock(newId);

				retry++;
			}

			if (locked)
			{
				var hashPortion = BijectionFunction.Encode(newId);

				var shortenedUrl = shortUrlBase + hashPortion;

				var entity = new UrlDefinition { Id = newId, OriginalUrl = request.OriginalUrl, ShortenedUrl = shortenedUrl };

				_repository.Save(entity);

				return new ShorteningResponse { ShortenedUrl = shortenedUrl, ResponseCode = Core.Enums.ResponseCode.Success, ResponseMessage = ResponseMessages.SuccessMessage };
			}
			else 
			{
				return new ShorteningResponse { ResponseCode = Core.Enums.ResponseCode.GeneralError, ResponseMessage = ResponseMessages.TimeoutErrorMessage };
			}
			
		}

		public RedirectionResponse Redirection(RedirectionRequest request)
		{
			var hashPortion = UrlParser.GetHashPortion(request.ShortenedUrl);

			var id = BijectionFunction.Decode(hashPortion);

			var existed = _repository.GetById(id);

			if (existed == null)
			{
				return new RedirectionResponse { ResponseCode = Core.Enums.ResponseCode.ParameterError, ResponseMessage = ResponseMessages.ShortenedUrlNotFoundMessage };
			}

			return new RedirectionResponse { ResponseCode = Core.Enums.ResponseCode.Success, ResponseMessage = ResponseMessages.SuccessMessage, OriginalUrl = existed.OriginalUrl };
		}

		public CustomUrlResponse CustomUrl(CustomUrlRequest request)
		{
			var hashPortion = UrlParser.GetHashPortion(request.CustomUrl);

			int id = BijectionFunction.Decode(hashPortion);

			var existed = _repository.GetById(id);

			if (existed != null)
			{
				return new CustomUrlResponse { ResponseCode = Core.Enums.ResponseCode.ParameterError, ResponseMessage = ResponseMessages.DuplicateHashPortionErrorMessage };
			}
			else
			{
				UrlDefinition entity = new UrlDefinition() { Id = id, OriginalUrl = request.OriginalUrl, ShortenedUrl = request.CustomUrl };
				_repository.Save(entity);
			}

			return new CustomUrlResponse { ResponseCode = Core.Enums.ResponseCode.Success, ResponseMessage = ResponseMessages.SuccessMessage };
		}

	}
}
