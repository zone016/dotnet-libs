// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Notion.Scheme;

public record NotionQueryResult
{
    [JsonPropertyName("object")] public required string Object { get; init; }
    [JsonPropertyName("results")] public required List<NotionEntity> Results { get; init; }
}
