using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShorteningService.Core.Entities;
using UrlShorteningService.Core.Repositories;

namespace UrlShorteningService.Data.Repositories
{
	public class UrlDefinitionRepository : IUrlDefinitionRepository
	{
		private DatabaseContext _context;

		public UrlDefinitionRepository(DatabaseContext context) 
		{ 
			this._context = context;
		}

		public UrlDefinition? GetById(int id)
		{
			return _context.UrlDefinitions.Where(u => u.Id == id).FirstOrDefault();
		}

		public void Save(UrlDefinition entity)
		{
			_context.UrlDefinitions.Add(entity);
		}

		public int GetMaxId()
		{
			if (_context.UrlDefinitions.Count == 0)
				return 0;

			return _context.UrlDefinitions.Max(u => u.Id);
		}


	}
}
