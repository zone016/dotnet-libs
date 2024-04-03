// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Nexus.Schema;

public record Proxy(
    [property: JsonPropertyName("remoteUrl")] string RemoteUrl
);
