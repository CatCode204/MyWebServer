using MyWebServer.SDK;

namespace MyWebServer.Tests
{
	[TestClass]
	public sealed class MyWebServerLineParserTest
	{
		[TestMethod]
		public void TestParse1()
		{
			var line = "GET / HTTP/1.1";
			IRequestLineParser requestLineParser = new HttpRequestLineParser();
			var requestLine = requestLineParser.ParseLine(line);
			Assert.IsNotNull(requestLine);
			Assert.AreEqual(MSHttpMethods.Get, requestLine.Method);
			Assert.AreEqual("/", requestLine.Path);
			Assert.AreEqual("HTTP/1.1", requestLine.Version);
		}

		[TestMethod]
		public void TestParse2()
		{
			var line = "get / HTTP/1.1";
			IRequestLineParser requestLineParser = new HttpRequestLineParser();
			var requestLine = requestLineParser.ParseLine(line);
			Assert.IsNotNull(requestLine);
			Assert.AreEqual(MSHttpMethods.Get, requestLine.Method);
			Assert.AreEqual("/", requestLine.Path);
			Assert.AreEqual("HTTP/1.1", requestLine.Version);
		}

		[TestMethod]
		public void TestParse3()
		{
			var line = "POST /id HTTP/1.1";
			IRequestLineParser requestLineParser = new HttpRequestLineParser();
			var requestLine = requestLineParser.ParseLine(line);
			Assert.IsNotNull(requestLine);
			Assert.AreEqual(MSHttpMethods.Post, requestLine.Method);
			Assert.AreEqual("/id", requestLine.Path);
			Assert.AreEqual("HTTP/1.1", requestLine.Version);
		}

		[TestMethod]
		public void TestParse4()
		{
			var line = "post /id HTTP/1.1";
			IRequestLineParser requestLineParser = new HttpRequestLineParser();
			var requestLine = requestLineParser.ParseLine(line);
			Assert.IsNotNull(requestLine);
			Assert.AreEqual(MSHttpMethods.Post, requestLine.Method);
			Assert.AreEqual("/id", requestLine.Path);
			Assert.AreEqual("HTTP/1.1", requestLine.Version);
		}

		[TestMethod]
		public void TestParse5()
		{
			var line = "PUT /user HTTP/1.1";
			IRequestLineParser requestLineParser = new HttpRequestLineParser();
			var requestLine = requestLineParser.ParseLine(line);
			Assert.IsNotNull(requestLine);
			Assert.AreEqual(MSHttpMethods.Put, requestLine.Method);
			Assert.AreEqual("/user", requestLine.Path);
			Assert.AreEqual("HTTP/1.1", requestLine.Version);
		}

		[TestMethod]
		public void TestParse6()
		{
			var line = "put /user HTTP/1.1";
			IRequestLineParser requestLineParser = new HttpRequestLineParser();
			var requestLine = requestLineParser.ParseLine(line);
			Assert.IsNotNull(requestLine);
			Assert.AreEqual(MSHttpMethods.Put, requestLine.Method);
			Assert.AreEqual("/user", requestLine.Path);
			Assert.AreEqual("HTTP/1.1", requestLine.Version);
		}

		[TestMethod]
		public void TestParse7()
		{
			var line = "PATCH /user HTTP/1.1";
			IRequestLineParser requestLineParser = new HttpRequestLineParser();
			var requestLine = requestLineParser.ParseLine(line);
			Assert.IsNotNull(requestLine);
			Assert.AreEqual(MSHttpMethods.Patch, requestLine.Method);
			Assert.AreEqual("/user", requestLine.Path);
			Assert.AreEqual("HTTP/1.1", requestLine.Version);
		}

		[TestMethod]
		public void TestParse8()
		{
			var line = "patch /user HTTP/1.1";
			IRequestLineParser requestLineParser = new HttpRequestLineParser();
			var requestLine = requestLineParser.ParseLine(line);
			Assert.IsNotNull(requestLine);
			Assert.AreEqual(MSHttpMethods.Patch, requestLine.Method);
			Assert.AreEqual("/user", requestLine.Path);
			Assert.AreEqual("HTTP/1.1", requestLine.Version);
		}

		[TestMethod]
		public void TestParse9()
		{
			var line = "DELETE /user HTTP/1.1";
			IRequestLineParser requestLineParser = new HttpRequestLineParser();
			var requestLine = requestLineParser.ParseLine(line);
			Assert.IsNotNull(requestLine);
			Assert.AreEqual(MSHttpMethods.Delete, requestLine.Method);
			Assert.AreEqual("/user", requestLine.Path);
			Assert.AreEqual("HTTP/1.1", requestLine.Version);
		}

		[TestMethod]
		public void TestParse10()
		{
			var line = "delete /user HTTP/1.1";
			IRequestLineParser requestLineParser = new HttpRequestLineParser();
			var requestLine = requestLineParser.ParseLine(line);
			Assert.IsNotNull(requestLine);
			Assert.AreEqual(MSHttpMethods.Delete, requestLine.Method);
			Assert.AreEqual("/user", requestLine.Path);
			Assert.AreEqual("HTTP/1.1", requestLine.Version);
		}

		[TestMethod]
		public void TestParse11()
		{
			var line = "delete /user HTTP/1.1";
			IRequestLineParser requestLineParser = new HttpRequestLineParser();
			var requestLine = requestLineParser.ParseLine(line);
			Assert.IsNotNull(requestLine);
			Assert.AreEqual(MSHttpMethods.Delete, requestLine.Method);
			Assert.AreEqual("/user", requestLine.Path);
			Assert.AreEqual("HTTP/1.1", requestLine.Version);
		}

		[TestMethod]
		public void TestParse12()
		{
			var line = "hello /user HTTP/1.1";
			IRequestLineParser requestLineParser = new HttpRequestLineParser();
			try
			{
				requestLineParser.ParseLine(line);
				Assert.Fail("Request line parse expect to be failed, success found");
			} catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}
	}
}