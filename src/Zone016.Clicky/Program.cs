Printer.WriteLine("Registering hotkeys...");

var cancellationTokenSource = new CancellationTokenSource();
Console.CancelKeyPress += (_, eventArgs) =>
{
    Printer.WriteLine("Canceling the operation...");
    
    eventArgs.Cancel = true;
    cancellationTokenSource.Cancel();
};

// using var manager = new MouseManager();
// manager.RegisterMouse(Modifiers.Alt, MouseButtons.Left);
//
// manager.MousePressed += (_, args) =>
// {
//     var combination = args.MouseCombination;
//     Printer.WriteLine($"Hotkey pressed: {combination.Modifiers}+{combination.Button}.");
// };

Printer.WriteSuccess("Hotkeys registered successfully.");
Printer.WriteLine("Press [b]CTRL+C[/] to cancel the operation.", false);

try
{ 
    await Task.Delay(Timeout.Infinite, cancellationTokenSource.Token);
}
catch (TaskCanceledException)
{
    Printer.WriteWarning("Operation canceled.");
}
