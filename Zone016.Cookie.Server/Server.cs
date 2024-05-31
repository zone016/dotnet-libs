// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Cookie.Server;

internal class Server(IPAddress address, IEnumerable<int> ports, CancellationToken cancellationToken)
{
    private readonly List<TcpListener> _listeners = [];

    public void Start()
    {
        foreach (var port in ports)
        {
            var listener = new TcpListener(address, port);
            listener.Start();
            _listeners.Add(listener);
        }
    }

    public void Stop()
    {
        foreach (var listener in _listeners)
        {
            listener.Stop();
        }

        _listeners.Clear();
    }

    public async Task AcceptClientsAsync(Func<TcpClient, Task> onClientAccepted)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            var connectionTasks = new List<Task<TcpClient>>();
            foreach (var listener in _listeners)
            {
                if (!listener.Pending())
                {
                    continue;
                }

                connectionTasks.Add(listener.AcceptTcpClientAsync(cancellationToken).AsTask());
            }

            if (connectionTasks.Count > 0)
            {
                try
                {
                    var completedTask = await Task.WhenAny(connectionTasks);
                    await onClientAccepted(await completedTask);
                }
                catch (OperationCanceledException)
                {
                    break;
                }
            }
            else
            {
                await Task.Delay(100, cancellationToken);
            }
        }
    }
}
