using MyWebServer.SDK;
using MyWebServer.SDK.ConnectionHandler;
using System.Net;
using System.Net.Sockets;

namespace MyWebServer
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = Host.CreateApplicationBuilder(args);

			builder.Services.AddTransient<MSHttpConnectionHandlerBuilder, MSHttpConnectionHandlerBuilder>();
			builder.Services.AddHostedService<Worker>(
				serviceProvider => {
					var IP = builder.Configuration.GetSection("Server").GetValue<string>("IP") ?? throw new KeyNotFoundException("IP in configuration not found");
					int port = builder.Configuration.GetSection("Server").GetValue<int>("Port");

					var socketEndpoint = new IPEndPoint(IPAddress.Parse(IP), port);
					var socket = new Socket(socketEndpoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

					socket.Bind(socketEndpoint);
					socket.Listen();

					return new Worker(serviceProvider.GetRequiredService<ILogger<Worker>>(), socket, serviceProvider.GetRequiredService<MSHttpConnectionHandlerBuilder>());
				}
			);

			var host = builder.Build();
			host.Run();
		}
	}
}