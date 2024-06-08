// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Native.Dynamite.Structs;

[StructLayout(LayoutKind.Explicit)]
public struct ApiSetValueEntry
{
    [FieldOffset(0x00)] public int Flags;
    [FieldOffset(0x04)] public int NameOffset;
    [FieldOffset(0x08)] public int NameCount;
    [FieldOffset(0x0C)] public int ValueOffset;
    [FieldOffset(0x10)] public int ValueCount;
}
