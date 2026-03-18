using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer.SDK
{
	public interface IRequestLineParser // Stupid but practice
	{
		RequestLine ParseLine(string line);
	}
}
