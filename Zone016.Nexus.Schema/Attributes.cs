// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Nexus.Schema;

public record Attributes(
    [property: JsonPropertyName("proxy")] Proxy? Proxy = default
);
