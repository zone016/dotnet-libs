// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Boxer.Schema;

public record DifficultyChart
{
    [JsonPropertyName("counterCake")] public required int CounterCake { get; init; }
    [JsonPropertyName("counterVeryEasy")] public required int CounterVeryEasy { get; init; }
    [JsonPropertyName("counterEasy")] public required int CounterEasy { get; init; }
    [JsonPropertyName("counterTooEasy")] public required int CounterTooEasy { get; init; }
    [JsonPropertyName("counterMedium")] public required int CounterMedium { get; init; }
    [JsonPropertyName("counterBitHard")] public required int CounterBitHard { get; init; }
    [JsonPropertyName("counterHard")] public required int CounterHard { get; init; }
    [JsonPropertyName("counterTooHard")] public required int CounterTooHard { get; init; }
    [JsonPropertyName("counterExHard")] public required int CounterExHard { get; init; }
    [JsonPropertyName("counterBrainFuck")] public required int CounterBrainFuck { get; init; }
}
