// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Nexus.Schema;

public record Checksum(
    [property: JsonPropertyName("sha1")] string Sha1,
    [property: JsonPropertyName("sha512")] string Sha512
);
