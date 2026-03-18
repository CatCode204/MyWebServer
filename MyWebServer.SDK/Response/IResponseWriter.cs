using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer.SDK.Response
{
	public interface IResponseWriter
	{
		Task WriteAsync(Stream stream);
	}
}
