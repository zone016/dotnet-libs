// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

var builder = Host.CreateApplicationBuilder(args);
builder.EnsureEnvironmentSetup();
builder.AddServices();
builder.AddSingletons();

var host = builder.Build();
host.Run();
