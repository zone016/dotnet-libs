// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Native.Shared.Structs;

[StructLayout(LayoutKind.Sequential)]
public struct SystemInfo
{
    public readonly ushort wProcessorArchitecture;
    public readonly ushort wReserved;
    public readonly uint dwPageSize;
    public readonly IntPtr lpMinimumApplicationAddress;
    public readonly IntPtr lpMaximumApplicationAddress;
    public readonly UIntPtr dwActiveProcessorMask;
    public readonly uint dwNumberOfProcessors;
    public readonly uint dwProcessorType;
    public readonly uint dwAllocationGranularity;
    public readonly ushort wProcessorLevel;
    public readonly ushort wProcessorRevision;
}
