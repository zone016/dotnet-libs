// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Cookie.Server.Options;

public class PortOptionBuilder : IOptionBuilder<int[]>
{
    public Option<int[]> Build()
    {
        var option = new Option<int[]>(["--ports", "-p"], getDefaultValue: () => [8080, 8443])
        {
            Description = "Specify the ports to listen on",
            ArgumentHelpName = "80, 443, ...",
            IsRequired = true
        };

        option.AddValidator(result =>
        {
            foreach (var token in result.Tokens)
            {
                if (!int.TryParse(token.Value, out var port))
                {
                    Logger.PrintError($"The port number {token.Value} is not a valid number!");
                }

                if (port is < IPEndPoint.MinPort or > IPEndPoint.MaxPort)
                {
                    Logger.PrintError($"The port number {port} is out of range!");
                    Environment.Exit(1);
                }
            }
        });

        return option;
    }
}
