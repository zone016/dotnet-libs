// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Cookie.Server.Commands;

public class RootCommandBuilder : ICommandBuilder
{
    public Command Build()
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

        command.SetHandler((ports, networkInterface) =>
        {
            
        }, portOption, interfaceOption);

        return command;
    }
}
