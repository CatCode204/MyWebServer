using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer.SDK.Response.BodyWriter
{
	public class StringResponseBodyWriterFactory : IResponseBodyWriterFactory
	{
		private readonly string content;

		public StringResponseBodyWriterFactory(string content)
		{
			this.content = content;
		}

		public IResponseBodyWriter CreateInstance()
		{
			return new StringResponseBodyWriter(content);
		}
	}
}
