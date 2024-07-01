// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Native;

public static class User32
{
    /// <summary>
    /// Installs an application-defined hook procedure into a hook chain.
    /// </summary>
    /// <param name="idHook">Type of hook procedure to be installed.</param>
    /// <param name="lpfn">Pointer to the hook procedure.</param>
    /// <param name="hMod">Handle to the DLL containing the hook procedure.</param>
    /// <param name="dwThreadId">Identifier of the thread with which the hook procedure is associated.</param>
    /// <returns>If successful, returns the handle to the hook procedure; otherwise, returns IntPtr.Zero.</returns>
    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern IntPtr SetWindowsHookEx(int idHook, LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);

    /// <summary>
    /// Removes a hook procedure installed in a hook chain.
    /// </summary>
    /// <param name="hhk">Handle to the hook procedure to be removed.</param>
    /// <returns>True if successful; otherwise, false.</returns>
    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool UnhookWindowsHookEx(IntPtr hhk);

    /// <summary>
    /// Passes the hook information to the next hook procedure in the chain.
    /// </summary>
    /// <param name="hhk">Handle to the current hook.</param>
    /// <param name="nCode">Hook code passed to the current hook procedure.</param>
    /// <param name="wParam">Parameter passed to the current hook procedure.</param>
    /// <param name="lParam">Parameter passed to the current hook procedure.</param>
    /// <returns>Value returned by the next hook procedure in the chain.</returns>
    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

    /// <summary>
    /// Determines whether a key is up or down at the time the function is called.
    /// </summary>
    /// <param name="vKey">The virtual-key code.</param>
    /// <returns>Value specifying the status of the specified virtual key.</returns>
    [DllImport("user32.dll")]
    public static extern short GetAsyncKeyState(KeyboardVirtualKeyCode vKey);
    
    /// <summary>
    /// Registers a window class for subsequent use in calls to the CreateWindow or CreateWindowEx function.
    /// </summary>
    /// <param name="lpwcx">A pointer to a WNDCLASSEX structure.</param>
    /// <returns>
    /// If the function succeeds, the return value is a class atom that uniquely identifies the class being
    /// registered. If the function fails, the return value is zero.
    /// </returns>
    [DllImport("User32", SetLastError = true, CharSet = CharSet.Unicode, EntryPoint = "RegisterClassExW")]
    public static extern ushort RegisterClassEx(ref WindowClassEx lpwcx);

    /// <summary>
    /// Unregisters a window class, freeing the memory required for the class.
    /// </summary>
    /// <param name="lpClassName">A null-terminated string or a class atom.</param>
    /// <param name="hInstance">A handle to the instance of the module.</param>
    /// <returns>
    /// If the function succeeds, the return value is true. If the function fails, the return value is false.
    /// </returns>
    [DllImport("User32", SetLastError = true, CharSet = CharSet.Unicode, EntryPoint = "UnregisterClassW")]
    public static extern bool UnregisterClass(string lpClassName, IntPtr hInstance);

    /// <summary>
    /// Creates an overlapped, pop-up, or child window with an extended window style.
    /// </summary>
    /// <param name="dwExStyle">The extended window style of the window being created.</param>
    /// <param name="lpClassName">A null-terminated string or a class atom.</param>
    /// <param name="lpWindowName">The window name.</param>
    /// <param name="dwStyle">The style of the window being created.</param>
    /// <param name="x">The initial horizontal position of the window.</param>
    /// <param name="y">The initial vertical position of the window.</param>
    /// <param name="nWidth">The width of the window.</param>
    /// <param name="nHeight">The height of the window.</param>
    /// <param name="hWndParent">A handle to the parent window.</param>
    /// <param name="hMenu">A handle to a menu.</param>
    /// <param name="hInstance">A handle to the instance of the module.</param>
    /// <param name="lpParam">
    /// A pointer to a value to be passed to the window through the CREATESTRUCT structure.
    /// </param>
    /// <returns>
    /// If the function succeeds, the return value is a handle to the new window.
    /// If the function fails, the return value is IntPtr.Zero.
    /// </returns>
    [DllImport("User32", SetLastError = true, CharSet = CharSet.Unicode, EntryPoint = "CreateWindowExW")]
    public static extern IntPtr CreateWindowEx(
        int dwExStyle,
        uint lpClassName,
        string? lpWindowName,
        WindowStyle dwStyle,
        int x,
        int y,
        int nWidth,
        int nHeight,
        IntPtr hWndParent,
        IntPtr hMenu,
        IntPtr hInstance,
        IntPtr lpParam);

    /// <summary>
    /// Destroys the specified window.
    /// </summary>
    /// <param name="hwnd">A handle to the window to be destroyed.</param>
    /// <returns>
    /// If the function succeeds, the return value is true. If the function fails, the return value is false.
    /// </returns>
    [DllImport("User32", SetLastError = true)]
    public static extern bool DestroyWindow(IntPtr hwnd);

    /// <summary>
    /// Calls the default window procedure to provide default processing for any window messages that an
    /// application does not process.
    /// </summary>
    /// <param name="hWnd">A handle to the window procedure that received the message.</param>
    /// <param name="msg">The message.</param>
    /// <param name="wParam">
    /// Additional message information. The contents of this parameter depend on the value of the Msg parameter.
    /// </param>
    /// <param name="lParam">
    /// Additional message information. The contents of this parameter depend on the value of the Msg parameter.
    /// </param>
    /// <returns>The return value is the result of the message processing and depends on the message sent.</returns>
    [DllImport("User32")]
    public static extern IntPtr DefWindowProc(
        IntPtr hWnd,
        uint msg,
        IntPtr wParam,
        IntPtr lParam);

    /// <summary>
    /// Defines a system-wide hot key.
    /// </summary>
    /// <param name="hWnd">A handle to the window that will receive WM_HOTKEY messages generated by the hot key.</param>
    /// <param name="id">The identifier of the hot key.</param>
    /// <param name="fsModifiers">
    /// The keys that must be pressed in combination with the key specified by the vk parameter in order to
    /// generate the WM_HOTKEY message.
    /// </param>
    /// <param name="vk">The virtual-key code of the hot key.</param>
    /// <returns>
    /// If the function succeeds, the return value is true. If the function fails, the return value is false.
    /// </returns>
    [DllImport("User32", SetLastError = true)]
    public static extern bool RegisterHotKey(
        IntPtr hWnd,
        int id,
        Modifiers fsModifiers,
        KeyboardVirtualKeyCode vk);

    /// <summary>
    /// Frees a hot key previously registered by the calling thread.
    /// </summary>
    /// <param name="hWnd">A handle to the window associated with the hot key to be freed.</param>
    /// <param name="id">The identifier of the hot key to be freed.</param>
    /// <returns>
    /// If the function succeeds, the return value is true. If the function fails, the return value is false.
    /// </returns>
    [DllImport("User32", SetLastError = true)]
    public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

    /// <summary>
    /// Retrieves a message from the calling thread's message queue.
    /// </summary>
    /// <param name="lpMsg">
    /// A pointer to an MSG structure that receives message information from the thread's message queue.
    /// </param>
    /// <param name="hwnd">A handle to the window whose messages are to be retrieved.</param>
    /// <param name="wMsgFilterMin">The integer value of the lowest message value to be retrieved.</param>
    /// <param name="wMsgFilterMax">The integer value of the highest message value to be retrieved.</param>
    /// <returns>
    /// If the function retrieves a message other than WM_QUIT, the return value is nonzero.
    /// If the function retrieves the WM_QUIT message, the return value is zero.
    /// If there is an error, the return value is -1.
    /// </returns>
    [DllImport("User32", SetLastError = true)]
    public static extern int GetMessage(
        out Message lpMsg,
        IntPtr hwnd,
        uint wMsgFilterMin,
        uint wMsgFilterMax);

    /// <summary>
    /// Posts a message to the message queue of the specified thread.
    /// </summary>
    /// <param name="hWnd">A handle to the window whose window procedure will receive the message.</param>
    /// <param name="Msg">The message to be posted.</param>
    /// <param name="wParam">Additional message-specific information.</param>
    /// <param name="lParam">Additional message-specific information.</param>
    /// <returns>
    /// If the function succeeds, the return value is true. If the function fails, the return value is false.
    /// </returns>
    [DllImport("User32", SetLastError = true)]
    public static extern bool PostMessage(
        IntPtr hWnd,
        uint Msg,
        IntPtr wParam,
        IntPtr lParam);

    /// <summary>
    /// Translates virtual-key messages into character messages.
    /// </summary>
    /// <param name="lpMsg">
    /// A pointer to an MSG structure that contains message information retrieved from the calling thread's
    /// message queue.
    /// </param>
    /// <returns>
    /// If the function succeeds, the return value is true. If the function fails, the return value is false.
    /// </returns>
    [DllImport("User32", SetLastError = true)]
    public static extern bool TranslateMessage(ref Message lpMsg);

    /// <summary>
    /// Dispatches a message to a window procedure.
    /// </summary>
    /// <param name="lpMsg">A pointer to an MSG structure that contains the message.</param>
    /// <returns>
    /// The return value specifies the value returned by the window procedure.
    /// Although its meaning depends on the message being dispatched, the return value generally is ignored.
    /// </returns>
    [DllImport("User32", SetLastError = true)]
    public static extern IntPtr DispatchMessage(ref Message lpMsg);

    /// <summary>
    /// Sends the specified message to a window or windows.
    /// </summary>
    /// <param name="hWnd">A handle to the window whose window procedure will receive the message.</param>
    /// <param name="Msg">The message to be sent.</param>
    /// <param name="wParam">Additional message-specific information.</param>
    /// <param name="lParam">Additional message-specific information.</param>
    /// <returns>
    /// The return value specifies the result of the message processing and depends on the message sent.
    /// </returns>
    [DllImport("User32", SetLastError = true)]
    public static extern IntPtr SendMessage(
        IntPtr hWnd,
        uint Msg,
        IntPtr wParam,
        IntPtr lParam);

    /// <summary>
    /// Copies the text of the specified window's title bar (if it has one). If the specified window is a control,
    /// the text of the control is copied. However, GetWindowText cannot retrieve the text of a control in another
    /// application.
    /// </summary>
    /// <param name="hWnd">A handle to the window or control containing the text.</param>
    /// <param name="lpString">The buffer that will receive the text.</param>
    /// <param name="nMaxCount">
    /// The maximum number of characters to copy to the buffer, including the null character.
    /// </param>
    /// <returns>
    /// If the function succeeds, the return value is the length, in characters, of the copied string,
    /// not including the terminating null character. If the window has no title bar or text,
    /// if the title bar is empty, or if the window or control handle is invalid, the return value is zero.
    /// </returns>
    [DllImport("User32", SetLastError = true, CharSet = CharSet.Unicode, EntryPoint = "GetWindowTextW")]
    public static extern int GetWindowTextW(
        IntPtr hWnd,
        StringBuilder lpString,
        int nMaxCount);

    /// <summary>
    /// Retrieves the length, in characters, of the specified window's title bar text (if the window has a title bar).
    /// If the specified window is a control, the function retrieves the length of the text within the control.
    /// However, GetWindowTextLength cannot retrieve the length of the text of a control in another application.
    /// </summary>
    /// <param name="hWnd">A handle to the window or control.</param>
    /// <returns>
    /// If the function succeeds, the return value is the length, in characters, of the text. Under certain
    /// conditions, this value may actually be greater than the length of the text. For example, certain accented
    /// characters or characters in other languages can be represented as a combination of multiple characters.
    /// </returns>
    [DllImport("User32", SetLastError = true, CharSet = CharSet.Unicode, EntryPoint = "GetWindowTextLengthW")]
    public static extern int GetWindowTextLengthW(IntPtr hWnd);

    /// <summary>
    /// Retrieves the length, in characters, of the specified window's title bar text (if the window has a title bar).
    /// If the specified window is a control, the function retrieves the length of the text within the control.
    /// However, GetWindowTextLength cannot retrieve the length of the text of a control in another application.
    /// </summary>
    /// <param name="hWnd">A handle to the window or control.</param>
    /// <returns>
    /// If the function succeeds, the return value is the length, in characters, of the text. Under certain
    /// conditions, this value may actually be greater than the length of the text. For example, certain accented
    /// characters or characters in other languages can be represented as a combination of multiple characters.
    /// </returns>
    [DllImport("User32", SetLastError = true, CharSet = CharSet.Ansi, EntryPoint = "GetWindowTextLengthA")]
    public static extern int GetWindowTextLengthA(IntPtr hWnd);

    /// <summary>
    /// Copies the text of the specified window's title bar (if it has one). If the specified window is a control,
    /// the text of the control is copied. However, GetWindowText cannot retrieve the text of a control in another
    /// application.
    /// </summary>
    /// <param name="hWnd">A handle to the window or control containing the text.</param>
    /// <param name="lpString">The buffer that will receive the text.</param>
    /// <param name="nMaxCount">
    /// The maximum number of characters to copy to the buffer, including the null character.
    /// </param>
    /// <returns>
    /// If the function succeeds, the return value is the length, in characters, of the copied string,
    /// not including the terminating null character. If the window has no title bar or text,
    /// if the title bar is empty, or if the window or control handle is invalid, the return value is zero.
    /// </returns>
    [DllImport("User32", SetLastError = true, CharSet = CharSet.Ansi, EntryPoint = "GetWindowTextA")]
    public static extern int GetWindowTextA(
        IntPtr hWnd,
        StringBuilder lpString,
        int nMaxCount);

    /// <summary>
    /// Changes the text of the specified window's title bar (if it has one). If the specified window is a control,
    /// the text of the control is changed. However, SetWindowText cannot change the text of a control in another
    /// application.
    /// </summary>
    /// <param name="hWnd">A handle to the window or control whose text is to be changed.</param>
    /// <param name="lpString">The new title or control text.</param>
    /// <returns>
    /// If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.
    /// </returns>
    [DllImport("User32", SetLastError = true, CharSet = CharSet.Ansi, EntryPoint = "SetWindowTextA")]
    public static extern bool SetWindowTextA(IntPtr hWnd, string lpString);

    /// <summary>
    /// Changes the text of the specified window's title bar (if it has one). If the specified window is a control,
    /// the text of the control is changed. However, SetWindowText cannot change the text of a control in another
    /// application.
    /// </summary>
    /// <param name="hWnd">A handle to the window or control whose text is to be changed.</param>
    /// <param name="lpString">The new title or control text.</param>
    /// <returns>
    /// If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.
    /// </returns>
    [DllImport("User32", SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern bool SetWindowTextW(IntPtr hWnd, string lpString);

    /// <summary>
    /// Retrieves information about the specified window.
    /// </summary>
    /// <param name="hWnd">Handle to the window and, indirectly, the class to which the window belongs.</param>
    /// <param name="nIndex">Specifies the zero-based offset to the value to be retrieved.</param>
    /// <returns>
    /// If the function succeeds, the return value is the requested value. If the function fails, the return value
    /// is zero.
    /// </returns>
    [DllImport("User32", SetLastError = true)]
    public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

    /// <summary>
    /// Changes an attribute of the specified window.
    /// </summary>
    /// <param name="hWnd">Handle to the window and, indirectly, the class to which the window belongs.</param>
    /// <param name="nIndex">Specifies the zero-based offset to the value to be set.</param>
    /// <param name="dwNewLong">Specifies the replacement value.</param>
    /// <returns>
    /// If the function succeeds, the return value is the previous value of the specified 32-bit integer.
    /// If the function fails, the return value is zero.
    /// </returns>
    [DllImport("User32", SetLastError = true)]
    public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

    /// <summary>
    /// Retrieves the name of the class to which the specified window belongs.
    /// </summary>
    /// <param name="hWnd">Handle to the window and, indirectly, the class to which the window belongs.</param>
    /// <param name="lpClassName">The class name string.</param>
    /// <param name="nMaxCount">The length of the buffer.</param>
    /// <returns>
    /// If the function succeeds, the return value is the number of characters copied to the buffer.
    /// If the function fails, the return value is zero.
    /// </returns>
    [DllImport("User32", SetLastError = true, CharSet = CharSet.Auto)]
    public static extern int GetClassName(
        IntPtr hWnd,
        StringBuilder lpClassName,
        int nMaxCount);

    /// <summary>
    /// Retrieves a handle to the top-level window whose class name and window name match the specified strings.
    /// </summary>
    /// <param name="lpClassName">
    /// Class name or a class atom created by a previous call to the RegisterClass or RegisterClassEx function.
    /// </param>
    /// <param name="lpWindowName">Window name (the window's title).</param>
    /// <returns>
    /// If the function succeeds, the return value is a handle to the window that has the specified class name and
    /// window name. If the function fails, the return value is IntPtr.Zero.
    /// </returns>
    [DllImport("User32", SetLastError = true, CharSet = CharSet.Auto)]
    public static extern IntPtr FindWindow(string lpClassName, string? lpWindowName);

    /// <summary>
    /// Changes an attribute of the specified window.
    /// </summary>
    /// <param name="hWnd">Handle to the window and, indirectly, the class to which the window belongs.</param>
    /// <param name="nIndex">Specifies the zero-based offset to the value to be set.</param>
    /// <param name="dwNewLong">Specifies the replacement value.</param>
    /// <returns>
    /// If the function succeeds, the return value is the previous value of the specified 32-bit integer.
    /// If the function fails, the return value is zero.
    /// </returns>
    [DllImport("User32", SetLastError = true)]
    public static extern int SetWindowLong(
        IntPtr hWnd,
        WindowLongIndex nIndex,
        int dwNewLong);

    /// <summary>
    /// Determines the visibility state of the specified window.
    /// </summary>
    /// <param name="hWnd">A handle to the window to be tested.</param>
    /// <returns>
    /// If the specified window, its parent window, its parent's parent window, and so forth, have the WS_VISIBLE
    /// style, the return value is nonzero. Otherwise, the return value is zero.
    /// </returns>
    [DllImport("User32", SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern bool IsWindowVisible(IntPtr hWnd);

    /// <summary>
    /// Retrieves the identifier of the thread that created the specified window and, optionally,
    /// the identifier of the process that created the window.
    /// </summary>
    /// <param name="hWnd">A handle to the window.</param>
    /// <param name="lpdwProcessId">A pointer to a variable that receives the process identifier.</param>
    /// <returns>The return value is the identifier of the thread that created the window.</returns>
    [DllImport("User32", SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

    /// <summary>
    /// Enumerates all top-level windows on the screen by passing the handle to each window, in turn,
    /// to an application-defined callback function.
    /// </summary>
    /// <param name="lpEnumFunc">A pointer to an application-defined callback function.</param>
    /// <param name="lParam">An application-defined value to be passed to the callback function.</param>
    /// <returns>If the function succeeds, the return value is nonzero.</returns>
    [DllImport("User32", SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);
}
