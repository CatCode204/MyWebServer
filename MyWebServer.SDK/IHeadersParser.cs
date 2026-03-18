using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer.SDK
{
	public interface IHeadersParser
	{
		Dictionary<string, string> ParseHeaders(string strHeaders);
	}
}