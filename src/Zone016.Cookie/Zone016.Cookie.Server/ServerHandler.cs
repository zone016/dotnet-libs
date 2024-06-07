// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Cookie.Server;

internal class ServerHandler
{
    private Server Server { get; set; }
    private readonly CancellationTokenSource _cancellationTokenSource = new();

    public ServerHandler(IPAddress ipAddress, IEnumerable<int> ports)
    {
        Server = new Server(ipAddress, ports, _cancellationTokenSource.Token);
        Console.CancelKeyPress += (_, args) =>
        {
            args.Cancel = true;
            _cancellationTokenSource.Cancel();
        };
    }

    public async Task RunAsync()
    {
        try
        {
            Server.Start();
            Printer.Write("Server started. Press CTRL+C to stop...");

            await Server.AcceptClientsAsync(HandleClientAsync);

            Server.Stop();
            Printer.Write("Server stopped gracefully.");
        }
        catch (OperationCanceledException)
        {
            Printer.WriteWarning("Cancellation requested, stopping server...");
            Server.Stop();
        }
    }

    private async Task HandleClientAsync(TcpClient client)
    {
        var connection = client.Client.RemoteEndPoint;
        if (connection is not IPEndPoint ip)
        {
            Printer.WriteWarning("Received a invalid connection attempt.");
            return;
        }

        Printer.Write($"New session from {ip.Address}:{ip.Port}");

        var stream = client.GetStream();
        var buffer = new byte[1024];

        try
        {
            int bytesRead;
            while ((bytesRead = await stream.ReadAsync(buffer, _cancellationTokenSource.Token)) != 0)
            {
                await stream.WriteAsync(buffer.AsMemory(0, bytesRead), _cancellationTokenSource.Token);
            }
        }
        catch (OperationCanceledException)
        {
            Printer.Write("Client handling canceled.");
        }
    }
}
