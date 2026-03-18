using MyWebServer.SDK;
using System.Net;
using System.Net.Sockets;

namespace MyWebServer
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = Host.CreateApplicationBuilder(args);

			var IP = builder.Configuration.GetSection("Server").GetValue<string>("IP") ?? throw new KeyNotFoundException("IP in configuration not found");
			int port = builder.Configuration.GetSection("Server").GetValue<int>("Port");

			var socketEndpoint = new IPEndPoint(IPAddress.Parse(IP), port);
			var socket = new Socket(socketEndpoint.AddressFamily,SocketType.Stream, ProtocolType.Tcp);

			socket.Bind(socketEndpoint);
			socket.Listen();

			builder.Services.AddTransient<Socket>(builder => socket);
			builder.Services.AddHostedService<Worker>();

			var host = builder.Build();
			host.Run();
		}
	}
}