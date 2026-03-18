using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer.SDK
{
	public class HttpRequestLineParser : IRequestLineParser
	{
		public HttpRequestLine ParseLine(string line)
		{
			var lineComponents = line.Split(' ');
			string lineMethod = lineComponents[0];

			var method = MSHttpMethods.Get;
			if ("GET".Equals(lineMethod,StringComparison.OrdinalIgnoreCase))
			{
				method = MSHttpMethods.Get;
			}
			else if ("POST".Equals(lineMethod, StringComparison.OrdinalIgnoreCase))
			{
				method = MSHttpMethods.Post;
			}
			else if ("PUT".Equals(lineMethod, StringComparison.OrdinalIgnoreCase))
			{
				method = MSHttpMethods.Put;
			}
			else if ("PATCH".Equals(lineMethod, StringComparison.OrdinalIgnoreCase))
			{
				method = MSHttpMethods.Patch;
			}
			else if ("DELETE".Equals(lineMethod, StringComparison.OrdinalIgnoreCase))
			{
				method = MSHttpMethods.Delete; 
			}
			else
			{
				throw new Exception($"HTTP Method: {lineMethod} current not support");
			}

			var path = lineComponents[1];
			var version = lineComponents[2];

			return new HttpRequestLine() { Method = method, Path = path, Version = version };
		}
	}
}
