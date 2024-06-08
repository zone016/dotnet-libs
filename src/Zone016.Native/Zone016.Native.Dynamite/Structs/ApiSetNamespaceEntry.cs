// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Native.Dynamite.Structs;

[StructLayout(LayoutKind.Explicit)]
public struct ApiSetNamespaceEntry
{
    [FieldOffset(0x04)] public int NameOffset;
    [FieldOffset(0x08)] public int NameLength;
    [FieldOffset(0x10)] public int ValueOffset;
    [FieldOffset(0x14)] public int ValueLength;
}
