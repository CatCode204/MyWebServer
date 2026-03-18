using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer.SDK.Request
{
	public interface IRequestLineParser // Stupid but practice
	{
		HttpRequestLine ParseLine(string line);
	}
}
