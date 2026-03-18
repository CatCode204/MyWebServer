namespace MyWebServer.SDK
{
	public class MSHttpRequest
	{
		public required RequestLine RequestLine { get; set; }
		public required Dictionary<string, string> Headers { get; set; } = [];
		public byte[]? Body { get; set; } = null;
	}
}
