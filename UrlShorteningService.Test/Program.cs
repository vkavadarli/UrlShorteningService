using UrlShorteningService.Business.Handlers;

namespace UrlShorteningService.Test
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var value = 1234945;
			var encoded = BijectionFunction.Encode(value);
			var decoded = BijectionFunction.Decode(encoded);
			Console.WriteLine($"For value:{value} Encoded:{encoded} Decoded:{decoded}");
		}
	}
}