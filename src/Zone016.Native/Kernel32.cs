// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Native;

public static class Kernel32
{
    /// <summary>
    /// Retrieves a module handle for the specified module.
    /// </summary>
    /// <param name="lpModuleName">The name of the module.</param>
    /// <returns>A handle to the specified module, or IntPtr.Zero if the module is not found.</returns>
    [DllImport("Kernel32", SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern IntPtr GetModuleHandle(string? lpModuleName);

    /// <summary>
    /// Retrieves the thread ID of the specified thread.
    /// </summary>
    /// <param name="hThread">Handle to the thread.</param>
    /// <returns>The thread ID of the specified thread.</returns>
    [DllImport("Kernel32")]
    public static extern uint GetThreadId(IntPtr hThread);

    /// <summary>
    /// Opens an existing thread object.
    /// </summary>
    /// <param name="dwDesiredAccess">The access rights for the thread.</param>
    /// <param name="bInheritHandle">Whether the handle is inheritable.</param>
    /// <param name="dwThreadId">The identifier of the thread to be opened.</param>
    /// <returns>A handle to the thread if successful; otherwise, IntPtr.Zero.</returns>
    [DllImport("Kernel32")]
    public static extern IntPtr OpenThread(ThreadAccess dwDesiredAccess, bool bInheritHandle, uint dwThreadId);

    /// <summary>
    /// Closes an open object handle.
    /// </summary>
    /// <param name="hObject">A valid handle to an open object.</param>
    /// <returns>True if successful; otherwise, false.</returns>
    [DllImport("Kernel32", SetLastError = true)]
    public static extern bool CloseHandle(IntPtr hObject);

    /// <summary>
    /// Retrieves the description (name) of the specified thread.
    /// </summary>
    /// <param name="hThread">Handle to the thread.</param>
    /// <param name="ppszThreadDescription">Pointer to the thread description.</param>
    /// <returns>True if successful; otherwise, false.</returns>
    [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern bool GetThreadDescription(IntPtr hThread, out IntPtr ppszThreadDescription);
}
