﻿// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

using System.Text;

namespace Zone016.Process.Tests;

[TestClass]
public class UnitTestOfRunner
{
    [TestMethod]
    public async Task TestRun()
    {
        var shell = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
            ? "cmd.exe"
            : "/usr/bin/sh";

        var commands = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
            ? new[] { "/c", "dir" }
            : ["-c", "ls"];

        var buffer = new StringBuilder();
        await Runner.Create(shell)
            .WithArguments(commands)
            .WithOutputDataReceivedCallback(stdout => buffer.Append(stdout))
            .WithTimeout(TimeSpan.FromSeconds(10))
            .RunAsync();

        Assert.IsTrue(buffer.Length > 0);
    }
}