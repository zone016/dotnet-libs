// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Project;

public class ProjectExplorer
{
    private readonly string _path;
    private DotNetInstallation? _installation;

    public static ProjectExplorer Open(string path) => new(path);

    public static IEnumerable<DotNetInstallation> GetDotNetInstallations()
    {
        var binaries = GetDotNetBinaries().ToArray();
        var buffer = new ConcurrentBag<string>();

        Task.WaitAll(binaries.Select(binary => Runner.Create(binary)
                .WithArguments("--list-sdks")
                .WithTimeout(TimeSpan.FromSeconds(1))
                // ReSharper disable once AccessToModifiedClosure
                .WithOutputDataReceivedCallback(stdout => buffer.Add(stdout))
                .RunAsync())
            .ToArray());

        var installations = buffer.SelectMany(line => line.Split(Environment.NewLine))
            .Select(line => line.Trim())
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .Select(line =>
            {
                var index = line.IndexOf(' ');
                var parts = new[] { line[..index], line[(index + 1)..][1..^1] };
                return new DotNetInstallation(Version.Parse(parts[0]), parts[1], DotNetInstallationKind.Sdk);
            }).ToArray();

        buffer = [];
        Task.WaitAll(binaries.Select(binary => Runner.Create(binary)
                .WithArguments("--list-runtimes")
                .WithTimeout(TimeSpan.FromSeconds(1))
                .WithOutputDataReceivedCallback(stdout => buffer.Add(stdout))
                .RunAsync())
            .ToArray());

        return installations.Concat(buffer.SelectMany(line => line.Split(Environment.NewLine))
            .Select(line => line.Trim())
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .Select(line =>
            {
                var start = line.IndexOf(' ') + 1;
                var end = line.IndexOf(' ', start);
                var version = line.Substring(start, end - start);

                start = line.IndexOf('[') + 1;
                end = line.IndexOf(']');
                var path = line.Substring(start, end - start);

                return new DotNetInstallation(Version.Parse(version), path, DotNetInstallationKind.Runtime);
            }));
    }

    public ProjectExplorer WithInstallation(DotNetInstallation installation)
    {
        _installation = GetDotNetInstallations()
            .FirstOrDefault(systemInstallations => installation == systemInstallations);

        if (_installation is null)
        {
            throw new RuntimeNotFound();
        }

        return this;
    }

    private ProjectExplorer(string path)
    {
        if (!Path.Exists(path))
        {
            throw new FileNotFoundException("The project file does not exist.", path);
        }

        _path = Path.GetFullPath(path);
    }

    private static IEnumerable<string> GetDotNetBinaries()
    {
        var binaryName = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
            ? "dotnet.exe"
            : "dotnet";

        return Runner.GetExecutablePathFromEnvironment(binaryName);
    }
}
