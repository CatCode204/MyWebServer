using MyWebServer.SDK.ConnectionHandler;
using System.Net.Sockets;

namespace MyWebServer
{
	public class Worker : BackgroundService
	{
		private readonly ILogger<Worker> _logger;
		private readonly Socket _socket;

		public Worker(ILogger<Worker> logger, Socket socket)
		{
			_logger = logger;
			_socket = socket;
		}

		protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{
			//while (!stoppingToken.IsCancellationRequested)
			//{
			//	if (_logger.IsEnabled(LogLevel.Information))
			//	{
			//		_logger.LogInformation("Worker is running at: {time}", DateTimeOffset.Now);
			//	}
			//	await Task.Delay(1000,stoppingToken);
			//}
			IConnectionHandler connectionHandler = MSHttpConnectionHandlerBuilder.Build(_socket, stoppingToken);
			await connectionHandler.HandleConnectionAsync();
		}
	}
}
