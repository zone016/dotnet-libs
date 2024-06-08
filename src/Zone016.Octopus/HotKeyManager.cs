// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Octopus;

public sealed class HotKeyManager : IHotKeyManager
{
    private const uint KeyCombination = 0x312u;
    private const uint RegisterKey = 0x0400u;
    private const uint UnregisterKey = 0x0401u;

    private static readonly string s_assemblyName = Assembly.GetExecutingAssembly().GetName().Name!;

    private readonly (Thread, IntPtr) _messageLoopThread;

    public event EventHandler<KeyPressedEventArgs>? KeyPressed;

    public HotKeyManager()
    {
        _messageLoopThread = InitializeMessageLoop();
    }

    public IRegistration Register(Modifiers modifiers, VirtualKeyCode key)
    {
        var (_, windowHandle) = _messageLoopThread;
        var result = User32.SendMessage(windowHandle, RegisterKey, (IntPtr)key, (IntPtr)modifiers);

        return new Registration(result, windowHandle);
    }

    private (Thread, IntPtr) InitializeMessageLoop()
    {
        var handle = new TaskCompletionSource<IntPtr>();
        var registrations = new Dictionary<int, KeyCombination?>();

        var thread = new Thread(() => MessageLoopThreadEntry(handle, registrations))
        {
            Name = $"{s_assemblyName} Message Loop"
        };

        thread.Start();
        return (thread, handle.Task.Result);
    }

    private void MessageLoopThreadEntry(TaskCompletionSource<IntPtr> handle, Dictionary<int, KeyCombination?> registrations)
    {
        var hInstance = Kernel32.GetModuleHandle(default);
        var wndProc = new WndProc((windowHandle, uMsg, wParam, lParam) => MessageHandler(windowHandle, uMsg, wParam, lParam, registrations));
        var wndClassEx = new WindowClassEx
        {
            cbSize = (uint)Marshal.SizeOf<WindowClassEx>(),
            style = 0,
            lpfnWndProc = Marshal.GetFunctionPointerForDelegate(wndProc),
            cbClsExtra = 0,
            cbWndExtra = 0,
            hInstance = Kernel32.GetModuleHandle(default),
            hIcon = IntPtr.Zero,
            hCursor = IntPtr.Zero,
            hbrBackground = IntPtr.Zero,
            lpszMenuName = default,
            lpszClassName = $"{s_assemblyName}-{Guid.NewGuid():N}",
            hIconSm = IntPtr.Zero
        };
        var registeredClass = User32.RegisterClassEx(ref wndClassEx);
        var windowHandle = User32.CreateWindowEx(0, registeredClass, default, WindowStyle.Overlapped, 0, 0, 640,
            480, IntPtr.Zero, IntPtr.Zero, hInstance, IntPtr.Zero);

        handle.SetResult(windowHandle);

        MessageLoop(windowHandle);
        Cleanup(windowHandle, hInstance, default, registrations);
    }

    private static void MessageLoop(IntPtr windowHandle)
    {
        while (User32.GetMessage(out var message, windowHandle, 0, 0) > 0)
        {
            User32.TranslateMessage(ref message);
            User32.DispatchMessage(ref message);
        }
    }

    private static void Cleanup(IntPtr windowHandle, IntPtr hInstance, WindowClassEx wndClassEx,
        Dictionary<int, KeyCombination?> registrations)
    {
        foreach (var id in registrations.Keys)
        {
            UnregisterKeyCombination(windowHandle, id, registrations);
        }

        User32.DestroyWindow(windowHandle);
        User32.UnregisterClass(wndClassEx.lpszClassName, hInstance);
    }

    private IntPtr MessageHandler(IntPtr windowHandle, uint uMsg, IntPtr wParam, IntPtr lParam,
        Dictionary<int, KeyCombination?> registrations)
    {
        switch (uMsg)
        {
            case RegisterKey:
                return HandleRegisterKeyCombination(windowHandle, wParam, lParam, registrations);

            case UnregisterKey:
                return HandleUnregisterKeyCombination(windowHandle, wParam, registrations);

            case KeyCombination:
                HandleKeyCombinationMessage(wParam, registrations);
                return 1;

            default:
                return User32.DefWindowProc(windowHandle, uMsg, wParam, lParam);
        }
    }

    private static IntPtr HandleRegisterKeyCombination(IntPtr windowHandle, IntPtr wParam, IntPtr lParam,
        Dictionary<int, KeyCombination?> registrations)
    {
        var id = GetNextId(registrations);
        var key = checked((VirtualKeyCode)(int)wParam);
        var modifiers = checked((Modifiers)(int)lParam);
        if (id.HasValue && RegisterKeyCombination(windowHandle, key, modifiers, id.Value, registrations))
        {
            return id.Value;
        }

        return -1;
    }

    private static IntPtr HandleUnregisterKeyCombination(IntPtr windowHandle, IntPtr wParam, Dictionary<int, KeyCombination?> registrations)
    {
        var id = checked((int)wParam);
        if (UnregisterKeyCombination(windowHandle, id, registrations))
        {
            return id;
        }

        return -1;
    }

    private void HandleKeyCombinationMessage(IntPtr wParam, Dictionary<int, KeyCombination?> registrations)
    {
        var keyCombinationId = checked((int)wParam);
        var keyCombination = registrations.GetValueOrDefault(keyCombinationId);
        if (keyCombination is null)
        {
            return;
        }

        OnKeyCombinationPressed(new KeyPressedEventArgs(keyCombination));
    }

    private static int? GetNextId(Dictionary<int, KeyCombination?> registrations)
    {
        for (var i = 0x0000; i <= 0xBFFF; i++)
        {
            if (!registrations.ContainsKey(i))
            {
                return i;
            }
        }

        return default;
    }

    private static bool RegisterKeyCombination(IntPtr windowHandle, VirtualKeyCode key, Modifiers modifiers, int id,
        Dictionary<int, KeyCombination?> registrations)
    {
        if (!User32.RegisterHotKey(windowHandle, id, modifiers, key))
        {
            return false;
        }

        registrations[id] = new KeyCombination(id, modifiers, key);
        return true;
    }

    private static bool UnregisterKeyCombination(IntPtr windowHandle, int id, Dictionary<int, KeyCombination?> registrations)
    {
        var registration = registrations.GetValueOrDefault(id);
        if (registration is null || !User32.UnregisterHotKey(windowHandle, registration.Id))
        {
            return false;
        }

        registrations.Remove(id);
        return true;
    }

    private void OnKeyCombinationPressed(KeyPressedEventArgs e)
    {
        KeyPressed?.Invoke(this, e);
    }

    public void Dispose()
    {
        var (thread, windowHandle) = _messageLoopThread;
        User32.PostMessage(windowHandle, (uint)WindowMessage.Quit, IntPtr.Zero, IntPtr.Zero);
        thread.Join();
    }
}
