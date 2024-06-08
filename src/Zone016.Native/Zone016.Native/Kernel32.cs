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
    public static extern IntPtr GetModuleHandle(
        string? lpModuleName
    );

    /// <summary>
    /// Retrieves the thread ID of the specified thread.
    /// </summary>
    /// <param name="hThread">Handle to the thread.</param>
    /// <returns>The thread ID of the specified thread.</returns>
    [DllImport("Kernel32")]
    public static extern uint GetThreadId(
        IntPtr hThread
    );

    /// <summary>
    /// Opens an existing thread object.
    /// </summary>
    /// <param name="dwDesiredAccess">The access rights for the thread.</param>
    /// <param name="bInheritHandle">Whether the handle is inheritable.</param>
    /// <param name="dwThreadId">The identifier of the thread to be opened.</param>
    /// <returns>A handle to the thread if successful; otherwise, IntPtr.Zero.</returns>
    [DllImport("Kernel32")]
    public static extern IntPtr OpenThread(
        ThreadAccess dwDesiredAccess,
        bool bInheritHandle,
        uint dwThreadId
    );

    /// <summary>
    /// Closes an open object handle.
    /// </summary>
    /// <param name="hObject">A valid handle to an open object.</param>
    /// <returns>True if successful; otherwise, false.</returns>
    [DllImport("Kernel32", SetLastError = true)]
    public static extern bool CloseHandle(
        IntPtr hObject
    );

    /// <summary>
    /// Retrieves the description (name) of the specified thread.
    /// </summary>
    /// <param name="hThread">Handle to the thread.</param>
    /// <param name="ppszThreadDescription">Pointer to the thread description.</param>
    /// <returns>True if successful; otherwise, false.</returns>
    [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern bool GetThreadDescription(
        IntPtr hThread,
        out IntPtr ppszThreadDescription
    );

    [DllImport("kernel32.dll")]
    public static extern IntPtr CreateToolHelp32Snapshot(
        uint dwFlags,
        uint th32ProcessID
    );

    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern bool Process32First(
        IntPtr hSnapshot,
        ref ProcessEntry32 lppe
    );

    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern bool Process32Next(
        IntPtr hSnapshot,
        ref ProcessEntry32 lppe
    );
    
    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern bool ReadProcessMemory(
        SafeProcessHandle hProcess,
        IntPtr lpBaseAddress,
        IntPtr lpBuffer,
        long dwSize,
        out IntPtr lpNumberOfBytesRead
    );

    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern bool ReadProcessMemory(
        SafeProcessHandle hProcess,
        IntPtr lpBaseAddress,
        [Out] byte[] lpBuffer,
        long dwSize,
        out IntPtr lpNumberOfBytesRead
    );

    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern IntPtr VirtualAllocEx(
        SafeProcessHandle processHandle,
        IntPtr baseAddress,
        int allocationSize,
        AllocationType allocationType,
        MemoryProtection protectionType
    );

    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern bool VirtualFreeEx(
        SafeProcessHandle processHandle,
        IntPtr baseAddress,
        int freeSize,
        FreeType freeType
    );

    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern bool VirtualProtectEx(
        SafeProcessHandle processHandle,
        IntPtr baseAddress,
        int protectionSize,
        MemoryProtection protectionType,
        out MemoryProtection oldProtectionType
    );

    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern bool VirtualQueryEx(
        SafeProcessHandle processHandle,
        IntPtr baseAddress,
        out MemoryBasicInformation memoryInformation,
        int length
    );

    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern bool WriteProcessMemory(
        SafeProcessHandle processHandle,
        IntPtr baseAddress,
        IntPtr bufferToWrite,
        int bytesToWriteSize,
        out IntPtr numberOfBytesWrittenBuffer
    );

    [DllImport("kernel32.dll")]
    public static extern void GetNativeSystemInfo(
        ref SystemInfo lpSystemInfo
    );

    [DllImport("kernel32.dll")]
    public static extern void GetSystemInfo(
        ref SystemInfo lpSystemInfo
    );
}
