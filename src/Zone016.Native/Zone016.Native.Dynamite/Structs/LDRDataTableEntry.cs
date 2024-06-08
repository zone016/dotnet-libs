// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Native.Dynamite.Structs;

// ReSharper disable once InconsistentNaming
[StructLayout(LayoutKind.Sequential)]
public struct LDRDataTableEntry
{
    public ListEntry InLoadOrderLinks;
    public ListEntry InMemoryOrderLinks;
    public ListEntry InInitializationOrderLinks;

    public IntPtr DllBase;
    public IntPtr EntryPoint;

    public uint SizeOfImage;

    public UnicodeString FullDllName;
    public UnicodeString BaseDllName;
}
