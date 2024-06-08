// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Native.Shared.Structs;

[StructLayout(LayoutKind.Explicit)]
public struct ImageThunkData32
{
    [FieldOffset(0)] public uint ForwarderString;
    [FieldOffset(0)] public uint Function;
    [FieldOffset(0)] public uint Ordinal;
    [FieldOffset(0)] public uint AddressOfData;
}
