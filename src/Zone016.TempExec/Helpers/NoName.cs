// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.TempExec.Helpers;

internal class NoName(int processId, CancellationToken cancellationToken)
{
    public void Run()
    {
        Task.Run(async () => await ChangeWindowTitlesPeriodically(), cancellationToken);
    }

    private async Task ChangeWindowTitlesPeriodically()
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            ChangeProcessWindowTitles(processId);
            try
            {
                await Task.Delay(TimeSpan.FromMilliseconds(100), cancellationToken);
            }
            catch (TaskCanceledException)
            {
                break;
            }
        }
    }

    private static void ChangeProcessWindowTitles(int processId)
    {
        User32.EnumWindows(EnumWindowsCallback, IntPtr.Zero);
        return;

        bool EnumWindowsCallback(IntPtr hWnd, IntPtr lParam)
        {
            _ = User32.GetWindowThreadProcessId(hWnd, out var windowProcessId);
            if (windowProcessId != processId || !User32.IsWindowVisible(hWnd))
            {
                return true;
            }

            var length = User32.GetWindowTextLengthW(hWnd);
            if (length <= 0)
            {
                return true;
            }

            var builder = new StringBuilder(length + 1);
            var windowTextWLength = User32.GetWindowTextW(hWnd, builder, builder.Capacity);
            if (windowTextWLength == 0)
            {
                Printer.WriteWarning("Window does not have title, or an error happened.");
            }
            
            var randomName = Guid.NewGuid().ToString("N");
            if (!User32.SetWindowTextW(hWnd, randomName))
            {
                Printer.WriteWarning("Failed to set the window title.");
            }

            return true;
        }
    }
}
