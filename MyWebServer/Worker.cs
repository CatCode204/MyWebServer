using MyWebServer.SDK.ConnectionHandler;
using System.Net.Sockets;

namespace MyWebServer
{
	public class Worker : BackgroundService
	{
		private readonly ILogger<Worker> _logger;
		private readonly Socket _socket;
		private readonly MSHttpConnectionHandlerBuilder _httpConnectionHandlerBuilder;

		public Worker(ILogger<Worker> logger, Socket socket, MSHttpConnectionHandlerBuilder httpConnectionHandlerBuilder)
		{
			_logger = logger;
			_socket = socket;
			_httpConnectionHandlerBuilder = httpConnectionHandlerBuilder;
		}

		protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{
			IConnectionHandler connectionHandler = _httpConnectionHandlerBuilder.Build(_socket, stoppingToken);
			await connectionHandler.HandleConnectionAsync();
		}
	}
}
