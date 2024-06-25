// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

const string BinaryName = "cheatengine-x86_64-SSE4-AVX2.exe";

var identity = WindowsIdentity.GetCurrent();
var principal = new WindowsPrincipal(identity);

if (!principal.IsInRole(WindowsBuiltInRole.Administrator))
{
    Printer.WriteError("The program must be run as an administrator.");
    Environment.Exit(1);
}

var releases = new List<string>();
Directory
    .GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles))
    .Where(directory => directory.Contains("Cheat Engine "))
    .ToList()
    .ForEach(directory =>
    {
        var version = directory.Split(' ').Last();
        if (Version.TryParse(version, out _) && File.Exists(Path.Combine(directory, BinaryName)))
        {
            releases.Add(version);
            return;
        }
        
        Printer.WriteWarning($"The directory '{directory}' does not appears to be a valid CE installation.");
    });


var releaseVersion = string.Empty;
if (releases.Count == 0)
{
    Printer.WriteError("No valid Cheat Engine installation found.");
    Environment.Exit(1);
}

if (releases.Count > 1)
{
    var version = Environment.GetEnvironmentVariable("CE_VERSION");
    if (string.IsNullOrEmpty(version) && args.Length != 1)
    {
        Printer.WriteError("More than one valid Cheat Engine installation found.");
        Printer.WriteLine("Specify the version to use as the first argument or CE_VERSION environment variable.");
        Environment.Exit(1);
    }
    
    if (string.IsNullOrEmpty(version))
    {
        version = args[0];
    }
    
    if (!string.IsNullOrEmpty(version) && !Version.TryParse(version, out _))
    {
        Printer.WriteError("The provided version is not a valid version number.");
        Environment.Exit(1);
    }
    
    if (!releases.Contains(version))
    {
        Printer.WriteError("The provided version is not a valid Cheat Engine installation.");
        Environment.Exit(1);
    }
    
    releaseVersion = version;
}

if (releases.Count == 1)
{
    releaseVersion = releases.First();
}

Printer.WriteLine($"Using [b]Cheat Engine version {releaseVersion}[/].", false);

var path = Path.Combine(
    Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), 
    $"Cheat Engine {releaseVersion}", BinaryName);

var directoryName = Path.GetDirectoryName(path);

if (string.IsNullOrEmpty(directoryName))
{
    Printer.WriteError("The provided file does not have a directory.");
    Environment.Exit(1);
}

var fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(path);
var destination = Path.Combine(directoryName, fileName);
File.Copy(path, destination);

Printer.WriteSuccess($"Spawning CE {releaseVersion}...");
var process = new Process
{
    StartInfo = new ProcessStartInfo
    {
        FileName = Path.Combine(directoryName, fileName),
        WorkingDirectory = directoryName,
        UseShellExecute = true
    },
    EnableRaisingEvents = true
};

var cancellationTokenSource = new CancellationTokenSource();
process.Exited += (_, _) => cancellationTokenSource.Cancel();

process.Start();

Printer.WriteLine("Waiting for the CE to exit...");
Printer.WriteLine("Press CTRL + C to cancel the operation.");

var noName = new NoName(process.Id, cancellationTokenSource.Token);
noName.Run();

Console.CancelKeyPress += (_, eventArgs) =>
{
    Printer.WriteLine("Canceling the operation...");
    
    if (!process.HasExited)
    {
        Printer.WriteWarning("CE stills running. Close it manually.");
        eventArgs.Cancel = true;
        
        return;
    }

    eventArgs.Cancel = true;
    cancellationTokenSource.Cancel();
};

try
{
    await Task.Delay(Timeout.Infinite, cancellationTokenSource.Token);
}
catch (TaskCanceledException)
{
    Printer.WriteWarning("Operation canceled.");
}
finally
{
    if (File.Exists(destination))
    {
        File.Delete(destination);
        Printer.WriteSuccess("The new file has been deleted.");
    }
}
