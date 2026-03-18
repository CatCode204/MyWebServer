using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer.SDK
{
	public interface IResponseBodyWriter
	{
		Task WriteAsync(Stream stream);
	}
}
