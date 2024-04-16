// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

using System.Net.NetworkInformation;

namespace Zone016.Cookie.Server.Options;

public class InterfaceOptionBuilder : IOptionBuilder<string>
{
    public Option<string> Build() => new(["--interface", "-i"], getDefaultValue: () =>
    {
        var interfaces = NetworkInterface.GetAllNetworkInterfaces();
        var defaultInterface = interfaces
            .FirstOrDefault(i => i.OperationalStatus == OperationalStatus.Up &&
                                 i.NetworkInterfaceType != NetworkInterfaceType.Loopback);

        return defaultInterface is null ? string.Empty : defaultInterface.Name;
    })
    {
        Description = "Specify the network interface by name",
        ArgumentHelpName = "eth0, wlan0, ...",
        IsRequired = true
    };
}
