using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShorteningService.Business.Handlers
{
	public class TransactionLocker
	{
		private IMemoryCache _memoryCache;

		public TransactionLocker(IMemoryCache memoryCache)
		{
			this._memoryCache = memoryCache;
		}

		//this method will be deprecated if we have more servers,
		//some noSql db can be used for lock operation
		public bool Lock(int id)
		{
			DateTime result;
			if (!_memoryCache.TryGetValue(id, out result))
			{
				_memoryCache.Set(id, DateTime.Now, DateTimeOffset.MinValue);

				return true;
			}

			return false;
		}
	}
}
