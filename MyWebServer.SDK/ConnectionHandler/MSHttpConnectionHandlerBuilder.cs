using MyWebServer.SDK.Request;
using MyWebServer.SDK.Request.HeaderParser;
using MyWebServer.SDK.Request.RequestLineParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer.SDK.ConnectionHandler
{
	public class MSHttpConnectionHandlerBuilder
	{
		public IRequestLineParser RequestLineParser { get; set; } = new HttpRequestLineParser();
		public IHeadersParser HeadersParser { get; set; } = new HttpHeaderParser();
		public IConnectionHandler Build(Socket socket, CancellationToken cancellationToken)
		{
			return new MSHttpConnectionHandler(
				new MSHttpRequestBuilder(RequestLineParser, HeadersParser),
				socket,
				cancellationToken
			);
		}
	}
}
