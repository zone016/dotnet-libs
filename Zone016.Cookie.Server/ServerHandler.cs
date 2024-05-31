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
            Logger.PrintInformational("Server started. Press CTRL+C to stop...");

            await Server.AcceptClientsAsync(HandleClientAsync);

            Server.Stop();
            Logger.PrintInformational("Server stopped gracefully.");
        }
        catch (OperationCanceledException)
        {
            Logger.PrintWarning("Cancellation requested, stopping server...");
            Server.Stop();
        }
    }

    private async Task HandleClientAsync(TcpClient client)
    {
        var connection = client.Client.RemoteEndPoint;
        if (connection is not IPEndPoint ip)
        {
            Logger.PrintWarning("Received a invalid connection attempt.");
            return;
        }

        Logger.PrintInformational($"New session from {ip.Address}:{ip.Port}");
        
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
            Logger.PrintInformational("Client handling canceled.");
        }
    }
}
