using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer.SDK
{
	public class MSHttpRequestBuilder
	{
		private readonly IRequestLineParser requestLineParser;
		private readonly IHeadersParser headersParser;

		public MSHttpRequestBuilder(IRequestLineParser requestLineParser, IHeadersParser headersParser)
		{
			this.requestLineParser = requestLineParser;
			this.headersParser = headersParser;
		}

		public MSHttpRequest Build(string requestStr)
		{
			string[] headerAndBody = requestStr.Split("\r\n\r\n",StringSplitOptions.RemoveEmptyEntries) ?? throw new Exception($"Can't split the requestStr: {requestStr}");
			string headerStr = headerAndBody[0];
			string[] headerList = headerStr.Split("\r\n");

			HttpRequestLine requestLine = requestLineParser.ParseLine(headerList[0]);
			Dictionary<string, string> headers = headersParser.ParseHeaders(String.Join("\r\n", headerList[1..]));
			byte[]? body = headerAndBody.Length > 1 ? Encoding.UTF8.GetBytes(headerAndBody[1]) : null;

			return new MSHttpRequest() { RequestLine = requestLine, Headers = headers, Body = body };
		}
	}
}
