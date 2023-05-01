using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShorteningService.Business.Handlers
{
	public class UrlParser
	{
		public static string? GetHashPortion(string url) 
		{
			var reversed = Reverse(url);

			if (reversed == null)
				return null;

			string substr = "";
			var rightPivot = reversed.IndexOf('/');

			if (reversed[0] == '/')
			{
				substr = reversed.Substring(1, rightPivot);
			}
			else 
			{
				substr = reversed.Substring(0, rightPivot);
			}

			return Reverse(substr);
		}

		private static string Reverse(string s)
		{
			char[] charArray = s.ToCharArray();
			Array.Reverse(charArray);
			return new string(charArray);
		}
	}
}
