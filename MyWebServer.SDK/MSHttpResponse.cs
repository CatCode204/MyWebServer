using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer.SDK
{
	public class MSHttpResponse
	{
		public string Version { get; set; } = "HTTP/1.1";
		public int StatusCode { get; set; } = 200;

		public string StatusMessage => StatusCode switch { 
			200 => "OK",
			400 => "Bad Request",
			403 => "Forbidden",
			404 => "Not Found",
			_ => throw new ArgumentOutOfRangeException($"Unknow status code message {StatusCode}")
		};

		public Dictionary<string, string> Headers { get; set; } = [];
		public IResponseBodyWriter BodyWriter { get; set; } = new NullResponseBodyWriter();
	}
}
