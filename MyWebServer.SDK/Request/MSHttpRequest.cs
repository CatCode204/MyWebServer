namespace MyWebServer.SDK.Request
{
	public class MSHttpRequest
	{
		public required HttpRequestLine RequestLine { get; set; }
		public required Dictionary<string, string> Headers { get; set; } = [];
		public byte[]? Body { get; set; } = null;
	}
}
