using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer.SDK.Response.BodyWriter
{
	internal class NullResponseBodyFactory : IResponseBodyWriterFactory
	{
		public IResponseBodyWriter CreateInstance()
		{
			return new NullResponseBodyWriter();
		}
	}
}
