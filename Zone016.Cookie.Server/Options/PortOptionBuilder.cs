// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Cookie.Server.Options;

public class PortOptionBuilder : IOptionBuilder<int[]>
{
    public Option<int[]> Build()
    {
        var option = new Option<int[]>(["--ports", "-p"], getDefaultValue: () => [8080, 8443])
        {
            Description = "Specify the ports to listen on", ArgumentHelpName = "80, 443, ...", IsRequired = true
        };

        option.AddValidator(result =>
        {
            foreach (var token in result.Tokens)
            {
                if (!int.TryParse(token.Value, out var port))
                {
                    result.ErrorMessage = $"The value {token.Value} is not a valid port number!";
                }

                if (port is < IPEndPoint.MinPort or > IPEndPoint.MaxPort)
                {
                    result.ErrorMessage = $"The port number {port} is out of range!";
                }
            }
        });

        return option;
    }
}
