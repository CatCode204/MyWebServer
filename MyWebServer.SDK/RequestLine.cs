using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer.SDK
{
	public class RequestLine
	{
		public MSHttpMethods Method { get; set; } = MSHttpMethods.Get;
		public string Path { get; set; } = string.Empty;
		public string Version { get; set; } = string.Empty;

		public static RequestLine Default => new RequestLine() { Method = MSHttpMethods.Get, Path = "/", Version = "HTTP/1.1" };
	}
}