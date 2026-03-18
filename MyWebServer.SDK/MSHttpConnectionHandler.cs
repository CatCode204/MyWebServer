using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer.SDK
{
	public class MSHttpConnectionHandler : IConnectionHandler
	{
		private const int CLIENT_NOT_SEND_TIMEOUT = 3000;

		private readonly Socket socket;
		private readonly CancellationToken cancellationToken;
		private readonly MSHttpRequestBuilder requestBuilder;

		private readonly List<Task> onClientConnectTasks = [];

		public MSHttpConnectionHandler(MSHttpRequestBuilder requestBuilder, Socket socket, CancellationToken cancellationToken)
		{
			this.socket = socket;
			this.cancellationToken = cancellationToken;
			this.requestBuilder = requestBuilder;
		}

		public async Task HandleConnectionAsync()
		{
			while (!cancellationToken.IsCancellationRequested)
			{
				var clientSocket = await socket.AcceptAsync(cancellationToken);
				onClientConnectTasks.Add(OnClientConnectHandleAsync(clientSocket));
			}
			await Task.WhenAll(onClientConnectTasks);
		}

		private async Task OnClientConnectHandleAsync(Socket clientSocket)
		{
			while (!cancellationToken.IsCancellationRequested)
			{
				var stopTokenSrc = new CancellationTokenSource(CLIENT_NOT_SEND_TIMEOUT);
				var stopToken = stopTokenSrc.Token;
				var stopConnectTokenSrc = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, stopToken);


				var request = await RecieveRequestAsync(clientSocket, stopTokenSrc.Token);

				var body = "<h1>Hello World!</h1>";
				var httpResponse = new MSHttpResponse();
				httpResponse.Headers.Add("Content-Length", Encoding.UTF8.GetByteCount(body).ToString());
				httpResponse.Headers.Add("Content-Type", "text/html");
				httpResponse.BodyWriter = new StringResponseBodyWriter(body);

				var networkStream = new NetworkStream(clientSocket);

				IResponseWriter writer = new MSHttpResponseWriter(httpResponse);
				await writer.WriteAsync(networkStream);

				clientSocket.Close();
			}
		}

		private async Task<MSHttpRequest> RecieveRequestAsync(Socket clientSocket, CancellationToken cancellationToken)
		{
			byte[] buffer = new byte[4096];
			var r = await clientSocket.ReceiveAsync(buffer,cancellationToken);
			string request = Encoding.UTF8.GetString(buffer, 0, r);

			var result = requestBuilder.Build(request);
			return result;
		}
	}
}