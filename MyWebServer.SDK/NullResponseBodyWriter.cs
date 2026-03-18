using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer.SDK
{
	public class NullResponseBodyWriter : IResponseBodyWriter
	{
		public Task WriteAsync(Stream stream)
		{
			// Do Nothing
			return Task.CompletedTask;
		}
	}
}
