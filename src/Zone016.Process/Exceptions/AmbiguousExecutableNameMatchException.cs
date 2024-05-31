// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Process.Exceptions;

public class AmbiguousExecutableNameMatchException(string executable, string[] paths)
    : Exception($"Binary {executable} has multiple matches: {string.Join(", ", paths)}.");
