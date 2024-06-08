// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Native.Shared.Structs;

[StructLayout(LayoutKind.Sequential)]
public struct ProcessBasicInformation
{
    public readonly IntPtr ExitStatus;
    public readonly IntPtr PebBaseAddress;
    public readonly IntPtr AffinityMask;
    public readonly IntPtr BasePriority;
    public readonly UIntPtr UniqueProcessId;
    public readonly int InheritedFromUniqueProcessId;

    public static int Size => Marshal.SizeOf(typeof(ProcessBasicInformation));
}
