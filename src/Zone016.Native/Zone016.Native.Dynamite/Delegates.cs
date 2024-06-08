// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Native.Dynamite;

public static class Delegates
{
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate bool DllMain(
        IntPtr handle,
        uint fdwReason,
        IntPtr lpvReserved
    );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate NTStatus NtReadVirtualMemory(
        IntPtr processHandle,
        IntPtr baseAddress,
        IntPtr buffer,
        int size,
        IntPtr numberOfBytesRead
    );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate NTStatus NtWriteVirtualMemory(
        IntPtr processHandle,
        IntPtr baseAddress,
        IntPtr buffer,
        int size,
        IntPtr numberOfBytesWritten
    );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate NTStatus NtAllocateVirtualMemory(
        IntPtr processHandle,
        ref IntPtr baseAddress,
        IntPtr zeroBits,
        ref IntPtr regionSize,
        AllocationType allocationType,
        MemoryProtection protectionType
    );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate NTStatus NtQueryInformationProcess(
        IntPtr processHandle,
        int processInformationClass,
        IntPtr processInformation,
        int processInformationLength,
        int returnLength
    );
    
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate NTStatus NtOpenProcessDelegate(
        ref IntPtr processHandle,
        uint desiredAccess,
        ref ObjectAttributes objectAttributes,
        ref ClientId clientId
    );
}
