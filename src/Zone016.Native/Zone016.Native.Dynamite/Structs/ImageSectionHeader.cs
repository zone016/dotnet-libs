// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Native.Dynamite.Structs;

[StructLayout(LayoutKind.Explicit)]
public struct ImageSectionHeader
{
    [FieldOffset(0)]
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
    public char[] Name;

    [FieldOffset(8)] public uint VirtualSize;
    [FieldOffset(12)] public uint VirtualAddress;
    [FieldOffset(16)] public uint SizeOfRawData;
    [FieldOffset(20)] public uint PointerToRawData;
    [FieldOffset(24)] public uint PointerToRelocations;
    [FieldOffset(28)] public uint PointerToLineNumbers;
    [FieldOffset(32)] public ushort NumberOfRelocations;
    [FieldOffset(34)] public ushort NumberOfLineNumbers;
    [FieldOffset(36)] public DataSectionFlags Characteristics;

    public string Section => new(Name);
}
