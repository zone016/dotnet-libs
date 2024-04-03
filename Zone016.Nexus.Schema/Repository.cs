// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Nexus.Schema;

public record Repository(
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("format")] string Format,
    [property: JsonPropertyName("type")] string Type,
    [property: JsonPropertyName("url")] string Url,
    [property: JsonPropertyName("attributes")] Attributes Attributes
);
