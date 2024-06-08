if (args.Length != 1)
{
    Printer.WriteError("Only the program name or PID is expected as an argument.");
    Environment.Exit(1);
}

var identity = WindowsIdentity.GetCurrent();
var principal = new WindowsPrincipal(identity);

if (!principal.IsInRole(WindowsBuiltInRole.Administrator))
{
    Printer.WriteError("The program must be run as an administrator.");
    Environment.Exit(1);
}

Printer.WriteWarning("If your program have more than one instance, the first one will be selected.");
var process = int.TryParse(args[0], out var pid)
    ? Process.GetProcessById(pid)
    : Process.GetProcesses()
        .FirstOrDefault(process => process.ProcessName.Contains(args[0], StringComparison.OrdinalIgnoreCase));

if (process is null)
{
    Printer.WriteError("The program was not found.");
    Environment.Exit(1);
}

var cancellationTokenSource = new CancellationTokenSource();
Console.CancelKeyPress += (_, eventArgs) =>
{
    Printer.WriteLine("Canceling the operation...");

    eventArgs.Cancel = true;
    cancellationTokenSource.Cancel();
};

Printer.WriteLine($"Found [b]{process.ProcessName}[/] with PID [b]{process.Id}[/].", false);
Printer.WriteLine($"Monitoring handle [b]0x{process.Handle:X}[/]...", false);

process.Exited += (_, _) =>
{
    var exitCode = process.ExitCode; 
    Printer.WriteError($"The program has exited [b]({exitCode}[/].", false);
    cancellationTokenSource.Cancel();
};

try
{
    await Task.Delay(Timeout.Infinite, cancellationTokenSource.Token);
}
catch (TaskCanceledException)
{
    Printer.WriteLine("Operation canceled.");
}
