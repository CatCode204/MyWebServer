using MyWebServer.SDK.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer.SDK.ConnectionHandler
{
	public static class MSHttpConnectionHandlerBuilder
	{
		public static IRequestLineParser RequestLineParser { get; set; } = new HttpRequestLineParser();
		public static IHeadersParser HeadersParser { get; set; } = new HttpHeaderParser();
		public static IConnectionHandler Build(Socket socket, CancellationToken cancellationToken)
		{
			return new MSHttpConnectionHandler(
				new MSHttpRequestBuilder(RequestLineParser, HeadersParser),
				socket,
				cancellationToken
			);
		}
	}
}
