// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Cookie.Server.Commands;

public class RootCommandBuilder : ICommandBuilder
{
    public Command Build()
    {
        var command = new RootCommand("TCP Server for multiple connections")
        {
            Name = "cookie"
        };

        var portOption = new PortOptionBuilder().Build();
        var interfaceOption = new InterfaceOptionBuilder().Build();

        command.AddOption(portOption);
        command.AddOption(interfaceOption);

        command.SetHandler(async (ports, networkInterface) =>
        {
            Logger.PrintInformational(
                $"Listening on port(s) {string.Join(", ", ports)} " +
                $"on interface {networkInterface}...");
            await Task.Delay(TimeSpan.FromSeconds(1));
            // await TcpListenerManager.StartTcpListeners(ports, interfaceIp);
        }, portOption, interfaceOption);

        return command;
    }
}
