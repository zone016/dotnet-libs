// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Cookie.Server.Options;

public class InterfaceOptionBuilder : IOptionBuilder<string>
{
    public Option<string> Build()
    {
        var option = new Option<string>(["--interface", "-i"], getDefaultValue: () =>
        {
            var networkInterfaces = NetworkInterface.GetAllNetworkInterfaces()
                .Where(networkInterface => networkInterface.OperationalStatus == OperationalStatus.Up)
                .ToArray();

            var defaultInterface = networkInterfaces.FirstOrDefault();
            return defaultInterface is null ? string.Empty : defaultInterface.Name;
        })
        {
            Description = "Specify the network interface by name",
            ArgumentHelpName = "tun0, eth0, ...",
            IsRequired = true
        };
        
        option.AddValidator(result =>
        {
            var networkInterfaceName = result.GetValueOrDefault<string>();
            var networkInterfaceNames = NetworkInterface.GetAllNetworkInterfaces()
                .Where(networkInterface => networkInterface.OperationalStatus == OperationalStatus.Up)
                .Select(networkInterface => networkInterface.Name)
                .ToArray();
            
            if (!networkInterfaceNames.Contains(networkInterfaceName))
            {
                result.ErrorMessage = $"Network interface {networkInterfaceName} not found or down!";
            }
        });

        return option;
    }
}
