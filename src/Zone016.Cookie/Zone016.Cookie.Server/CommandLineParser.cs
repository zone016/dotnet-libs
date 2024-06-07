// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Cookie.Server;

internal static class CommandLineParser
{
    public static CommandLineBuilder Create()
    {
        var command = new RootCommand
        {
            Name = "cookie",
            Description = "A TCP server for generic reverse shells. It is basically a multi-client netcat clone, " +
                          "witch fancy features. Created to be used in HTB."
        };

        var portOption = new PortOptionBuilder().Build();
        var interfaceOption = new InterfaceOptionBuilder().Build();

        command.AddOption(portOption);
        command.AddOption(interfaceOption);

        command.SetHandler(async (ports, networkInterfaceName) =>
        {
            var networkInterface = NetworkInterface.GetAllNetworkInterfaces()
                .First(networkInterface => networkInterface.Name == networkInterfaceName);

            var address = networkInterface.GetIPProperties().UnicastAddresses
                .First(ipAddressInformation => ipAddressInformation.Address.AddressFamily == AddressFamily.InterNetwork)
                .Address;

            Printer.Write(
                $"Starting server at {address} from interface {networkInterface.Name} ({networkInterface.Description})...");

            var serverHandler = new ServerHandler(address, ports);
            await serverHandler.RunAsync();
        }, portOption, interfaceOption);

        var commandLineBuilder = new CommandLineBuilder(command)
            .UseDefaults()
            .UseExceptionHandler((exception, context) =>
            {
                Printer.WriteError(exception.Message);
                context.ExitCode = 1;
            });

        return commandLineBuilder;
    }
}
