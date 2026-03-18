using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer.SDK
{
	public class HeadersParser : IHeadersParser
	{
		public Dictionary<string, string> ParseHeaders(string strHeaders)
		{
			var headerLines = strHeaders.Split("\r\n",StringSplitOptions.RemoveEmptyEntries);
			Dictionary<string,string> ret = [];
			foreach (var line in headerLines)
			{
				var keyValue = line.Split(':');
				if (keyValue.Length != 2)
				{
					throw new Exception($"Can't Parse Header Line: {line}");
				}
				var key = keyValue[0].Trim();
				var value = keyValue[1].Trim();
				ret.Add(key, value);
			}

			return ret;
		}
	}
}
