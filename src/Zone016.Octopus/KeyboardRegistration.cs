// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Octopus;

public class KeyboardRegistration(IntPtr result, IntPtr hWnd) : IRegistration
{
    private const uint UnregisterKey = 0x0401u;

    public bool IsSuccessful => checked((int)result) != -1;
    public int Id => checked((int)result);

    public void Dispose()
    {
        if (checked((int)result != -1))
        {
            User32.SendMessage(hWnd, UnregisterKey, result, IntPtr.Zero);
        }
    }
}
