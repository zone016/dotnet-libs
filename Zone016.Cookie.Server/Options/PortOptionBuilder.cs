// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Cookie.Server.Options;

public class PortOptionBuilder : IOptionBuilder<int[]>
{
    public Option<int[]> Build() => new(["--ports", "-p"], getDefaultValue: () => [8080, 8443])
    {
        Description = "Specify the ports to listen on",
        ArgumentHelpName = "80, 443, ...",
        IsRequired = true
    };
}
