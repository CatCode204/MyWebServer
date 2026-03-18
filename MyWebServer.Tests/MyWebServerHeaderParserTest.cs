using MyWebServer.SDK.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer.Tests
{
	[TestClass]
	public class MyWebServerHeaderParserTest
	{
		[TestMethod]
		public void TestParseHeader_Simple()
		{
			var headers = "Host: example.com\r\nConnection: keep-alive\r\n";
			IHeadersParser parser = new HttpHeaderParser();
			var result = parser.ParseHeaders(headers);

			Assert.IsNotNull(result);
			Assert.HasCount(2, result);
			Assert.IsTrue(result.ContainsKey("Host"));
			Assert.AreEqual("example.com", result["Host"]);
			Assert.IsTrue(result.ContainsKey("Connection"));
			Assert.AreEqual("keep-alive", result["Connection"]);
		}

		[TestMethod]
		public void TestParseHeader_TrimsWhitespace()
		{
			var headers = "Content-Type:   text/plain; charset=utf-8  \r\nX-Custom:  value\r\n";
			IHeadersParser parser = new HttpHeaderParser();
			var result = parser.ParseHeaders(headers);

			Assert.IsTrue(result.ContainsKey("Content-Type"));
			Assert.AreEqual("text/plain; charset=utf-8", result["Content-Type"]);
			Assert.IsTrue(result.ContainsKey("X-Custom"));
			Assert.AreEqual("value", result["X-Custom"]);
		}

		[TestMethod]
		public void TestParseHeader_InvalidLine_Throws()
		{
			var headers = "BadHeaderLineWithoutColon\r\n";
			IHeadersParser parser = new HttpHeaderParser();

			try
			{
				parser.ParseHeaders(headers);
				Assert.Fail($"Parse header {headers} expect to be fail, success found");
			} catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}
	}
}
