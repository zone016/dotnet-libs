// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

using CommandLineBuilder = System.CommandLine.Builder.CommandLineBuilder;

namespace Zone016.Cookie.Server.Interfaces;

public interface ICommandLineBuilder
{
    CommandLineBuilder Build();
}
