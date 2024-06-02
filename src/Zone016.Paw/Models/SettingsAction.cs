// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Paw.Models;

internal record SettingsAction
{
    [JsonPropertyName("modifiers")] public required string[] Modifiers { get; init; }
    [JsonPropertyName("key")] public required string Key { get; init; }
    [JsonPropertyName("command")] public required string Command { get; init; }
    [JsonPropertyName("arguments")] public List<string>? Arguments { get; init; }
}
