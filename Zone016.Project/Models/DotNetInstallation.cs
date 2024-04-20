// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Project.Models;

public record DotNetInstallation(Version Version, string Path, DotNetInstallationKind Kind);
