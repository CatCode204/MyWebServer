using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer.SDK.Request
{
	public class HttpRequestLine
	{
		public MSHttpMethods Method { get; set; } = MSHttpMethods.Get;
		public string Path { get; set; } = string.Empty;
		public string Version { get; set; } = string.Empty;

		public static HttpRequestLine Default => new HttpRequestLine() { Method = MSHttpMethods.Get, Path = "/", Version = "HTTP/1.1" };
	}
}