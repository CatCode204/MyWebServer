using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer.SDK.Response
{
	public class MSHttpResponseWriter : IResponseWriter
	{
		private readonly MSHttpResponse httpResponse;

		public MSHttpResponseWriter(MSHttpResponse httpResponse)
		{
			this.httpResponse = httpResponse;
		}

		public async Task WriteAsync(Stream stream)
		{
			var streamWriter = new StreamWriter(stream);

			string responseLine = $"{httpResponse.Version} {httpResponse.StatusCode} {httpResponse.StatusMessage}";
			await streamWriter.WriteLineAsync(responseLine);

			foreach (var keyAndValue in httpResponse.Headers)
			{
				await streamWriter.WriteLineAsync($"{keyAndValue.Key}: {keyAndValue.Value}");
			}

			await streamWriter.WriteLineAsync();
			await streamWriter.FlushAsync();

			await httpResponse.BodyWriter.WriteAsync(stream);
		}
	}
}
