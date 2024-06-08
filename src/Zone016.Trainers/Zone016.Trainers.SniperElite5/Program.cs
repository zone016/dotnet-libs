if (!Environment.Is64BitProcess)
{
    Printer.WriteError("This game requires a 64-bit build to run.");
    Environment.Exit(1);
}

Printer.WriteLine("Searching for Sniper Elite 5 process...");

var process = Process.GetProcessesByName("Sniper5_dx12").FirstOrDefault();
if (process is null)
{
    Printer.WriteError("Sniper Elite 5 is not running.");
    Printer.WriteWarning("Vulkan game release is not support.");
    Environment.Exit(1);
}

var memoryUsage = process.WorkingSet64 / 1e+9;

Printer.WriteSuccess($"Game found on PID {process.Id} (with {process.Modules.Count} modules)");
Printer.WriteLine($"Also the game is using about [b]{memoryUsage:F}GB of your RAM[/]", false);

Printer.WriteLine("Searching for the sniper ammo pointer...");
if (process.MainModule is null)
{
    Printer.WriteError("Failed to get the main module of the game.");
    Environment.Exit(1);
}

Printer.WriteLine($"Starting traversing from [b]0x{process.MainModule.BaseAddress}[/]...", false);

var cancellationTokenSource = new CancellationTokenSource();
process.Exited += (_, _) =>
{
    var exitCode = process.ExitCode; 
    Printer.WriteError($"The game has exited [b]({exitCode}[/].", false);
    cancellationTokenSource.Cancel();
};

if (process.Handle == IntPtr.Zero)
{
    Printer.WriteError("Failed to get the handle of the game.");
    Environment.Exit(1);
}

var memory = new Referrer(process.Handle);

var pointer = process.MainModule.BaseAddress + 0x02846460;
pointer = memory.ReadVirtualMemory<IntPtr>(pointer, out var bytesRead);
Printer.WriteLine($"Read [b]{bytesRead}[/] bytes from [b]0x{pointer:X}[/].", false);

pointer += 0x0;
pointer = memory.ReadVirtualMemory<IntPtr>(pointer, out bytesRead);
Printer.WriteLine($"Read [b]{bytesRead}[/] bytes from [b]0x{pointer:X}[/].", false);

pointer += 0x1F0;
pointer = memory.ReadVirtualMemory<IntPtr>(pointer, out bytesRead);
Printer.WriteLine($"Read [b]{bytesRead}[/] bytes from [b]0x{pointer:X}[/].", false);

pointer += 0x50;
pointer = memory.ReadVirtualMemory<IntPtr>(pointer, out bytesRead);
Printer.WriteLine($"Read [b]{bytesRead}[/] bytes from [b]0x{pointer:X}[/].", false);

pointer += 0x110;
pointer = memory.ReadVirtualMemory<IntPtr>(pointer, out bytesRead);
Printer.WriteLine($"Read [b]{bytesRead}[/] bytes from [b]0x{pointer:X}[/].", false);

Printer.WriteSuccess($"Sniper ammo pointer found at [b]0x{pointer:X}+0x2C[/]!", false);
var sniperAmmo = memory.ReadVirtualMemory<int>(pointer + 0x2C, out bytesRead);
Printer.WriteLine($"Read [b]{bytesRead}[/] bytes from [b]0x{pointer:X}[/].", false);

Printer.WriteLine($"Current sniper ammo is [b]{sniperAmmo}[/] bullets.", false);
Printer.WriteLine("Writing the sniper ammo to [b]250[/] bullets...", false);

memory.WriteVirtualMemory(pointer + 0x2C, 250, out var bytesWritten);
Printer.WriteLine($"Written [b]{bytesWritten}[/] bytes to [b]0x{pointer:X}[/].", false);

sniperAmmo = memory.ReadVirtualMemory<int>(pointer + 0x2C, out bytesRead);
Printer.WriteLine($"Read [b]{bytesRead}[/] bytes from [b]0x{pointer:X}[/].", false);

if (sniperAmmo != 250)
{
    Printer.WriteError("Failed to write the sniper ammo.");
    Environment.Exit(1);
}

Printer.WriteSuccess("Sniper ammo has been set to [b]250[/] bullets!", false);
Printer.WriteLine("Press [b]Ctrl+C[/] to exit the program.", false);

try
{
    await Task.Delay(Timeout.Infinite, cancellationTokenSource.Token);
}
catch (TaskCanceledException)
{
    Printer.WriteWarning("Operation canceled.");
}
