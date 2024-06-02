// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Paw.Helpers;

internal static class Constants
{
    public static readonly string HomePath = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
        ".paw");

    public static readonly string ConfigurationFilePath = Path.Combine(HomePath, "configuration.json");
}
