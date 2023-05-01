using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShorteningService.Core.Entities;

namespace UrlShorteningService.Data
{
	//this class might be implemented from DbContext for real-world application
	public class DatabaseContext
	{		
		public List<UrlDefinition> UrlDefinitions { get; set; }

		public DatabaseContext() 
		{ 
			this.UrlDefinitions = new List<UrlDefinition>();
		}

	}
}
