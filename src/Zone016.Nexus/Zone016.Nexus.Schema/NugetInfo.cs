// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Nexus.Schema;

public record NugetInfo(
    [property: JsonPropertyName("is_latest_version")] bool IsLatestVersion,
    [property: JsonPropertyName("is_prerelease")] bool IsPrerelease
);
