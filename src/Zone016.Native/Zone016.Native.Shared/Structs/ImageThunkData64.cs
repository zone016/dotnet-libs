// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Native.Shared.Structs;

[StructLayout(LayoutKind.Explicit)]
public struct ImageThunkData64
{
    [FieldOffset(0)] public ulong ForwarderString;
    [FieldOffset(0)] public ulong Function;
    [FieldOffset(0)] public ulong Ordinal;
    [FieldOffset(0)] public ulong AddressOfData;
}
