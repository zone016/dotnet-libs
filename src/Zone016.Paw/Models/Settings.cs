// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Paw.Models;

internal record Settings
{
    [JsonPropertyName("actions")] public required SettingsAction[] Actions { get; init; }

public static Settings Load()
{
    using var stream = new FileStream(
        Constants.ConfigurationFilePath,
        FileMode.Open,
        FileAccess.Read,
        FileShare.ReadWrite);

    using var reader = new StreamReader(stream);
    var content = reader.ReadToEnd();
    return JsonSerializer.Deserialize(content, new SettingsContext().Settings)!;
}
}
