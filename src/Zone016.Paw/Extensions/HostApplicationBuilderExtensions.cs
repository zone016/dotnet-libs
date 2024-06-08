// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Paw.Extensions;

internal static class HostApplicationBuilderExtensions
{
    public static void AddServices(this HostApplicationBuilder builder)
    {
        builder.Services.AddHostedService<KeyListener>();
        builder.Services.AddWindowsService();
    }

    public static void AddSingletons(this HostApplicationBuilder builder)
    {
        builder.Services.AddSingleton<IHotKeyManager, HotKeyManager>();
    }

    public static void EnsureEnvironmentSetup(this HostApplicationBuilder _)
    {
        if (!Directory.Exists(Constants.HomePath))
        {
            Directory.CreateDirectory(Constants.HomePath);
        }

        if (!File.Exists(Constants.ConfigurationFilePath))
        {
            var configuration = new Settings
            {
                Actions =
                [
                    new SettingsAction
                    {
                        Modifiers = ["ALT"],
                        Key = "F1",
                        Command = "wt.exe"
                    }
                ]
            };

            var literal = JsonSerializer.Serialize(configuration, SettingsContext.Default.Settings);
            File.WriteAllText(Constants.ConfigurationFilePath, literal);
        }
    }
}
