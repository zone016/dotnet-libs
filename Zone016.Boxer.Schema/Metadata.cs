// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Boxer.Schema;

public record Metadata
{
    [JsonPropertyName("current_page")] public required int CurrentPage { get; init; }
    [JsonPropertyName("last_page")] public required int LastPage { get; init; }
}
