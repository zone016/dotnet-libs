// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Boxer.Schema;

public record ListChallengeResponse
{
    [JsonPropertyName("data")] public required List<Challenge> Challenges { get; init; }
    [JsonPropertyName("meta")] public required Metadata Metadata { get; init; }
}
