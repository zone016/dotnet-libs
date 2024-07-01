// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Octopus;

public sealed class MouseManager : IMouseManager
{
    /// <summary>
    /// Installs a hook procedure that monitors low-level mouse input events.
    /// </summary>
    private const int LowLevelMouseHook = 14;
    
    private readonly LowLevelMouseProc _mouseProc;
    
    private IntPtr _mouseHookId = IntPtr.Zero;
    private Modifiers _registeredModifiers;
    private MouseButtons _registeredMouseButton;

    public event EventHandler<MousePressedEventArgs>? MousePressed;

    public MouseManager()
    {
        _mouseProc = MouseHookCallback;
    }

    public void Start()
    {
        _mouseHookId = SetMouseHook(_mouseProc);
    }

    public void Stop()
    {
        User32.UnhookWindowsHookEx(_mouseHookId);
    }

    public void RegisterMouse(Modifiers modifiers, MouseButtons mouseButton)
    {
        _registeredModifiers = modifiers;
        _registeredMouseButton = mouseButton;
    }

    private static IntPtr SetMouseHook(LowLevelMouseProc proc)
    {
        using var process = Process.GetCurrentProcess();
        using var curModule = process.MainModule!;

        var handle = Kernel32.GetModuleHandle(curModule.ModuleName);
        if (handle == IntPtr.Zero)
        {
            throw new Win32Exception(Marshal.GetLastWin32Error());
        }

        return User32.SetWindowsHookEx(LowLevelMouseHook, proc, handle, 0);
    }

    private IntPtr MouseHookCallback(int nCode, IntPtr wParam, IntPtr lParam)
    {
        if (nCode < 0 || (MouseMessages)wParam != MouseMessages.LeftButtonDown)
        {
            return User32.CallNextHookEx(_mouseHookId, nCode, wParam, lParam);
        }

        if (!IsModifierPressed(_registeredModifiers))
        {
            return User32.CallNextHookEx(_mouseHookId, nCode, wParam, lParam);
        }

        var combination = new MouseCombination(0, _registeredModifiers, _registeredMouseButton);
        OnMousePressed(new MousePressedEventArgs(combination));

        return User32.CallNextHookEx(_mouseHookId, nCode, wParam, lParam);
    }

    private static bool IsModifierPressed(Modifiers modifiers) => (modifiers & Modifiers.Alt) != 0;

    private void OnMousePressed(MousePressedEventArgs e)
    {
        MousePressed?.Invoke(this, e);
    }

    public void Dispose()
    {
        Stop();
    }
}
