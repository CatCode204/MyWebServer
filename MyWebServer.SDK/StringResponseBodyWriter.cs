using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer.SDK
{
	public class StringResponseBodyWriter : IResponseBodyWriter
	{
		public string Content { get; set; } = string.Empty;
		public StringResponseBodyWriter(string content)
		{
			Content = content;
		}

		public async Task WriteAsync(Stream stream)
		{
			var streamWriter = new StreamWriter(stream);
			await streamWriter.WriteLineAsync(Content);
			await streamWriter.FlushAsync();
		}
	}
}
