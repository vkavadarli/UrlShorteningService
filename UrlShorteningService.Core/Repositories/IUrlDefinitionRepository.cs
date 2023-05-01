using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShorteningService.Core.Entities;

namespace UrlShorteningService.Core.Repositories
{
	public interface IUrlDefinitionRepository
	{
		UrlDefinition? GetById(int id);
		void Save(UrlDefinition entity);
		int GetMaxId();
	}
}
