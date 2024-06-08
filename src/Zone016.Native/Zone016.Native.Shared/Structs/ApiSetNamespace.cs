// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Native.Shared.Structs;

[StructLayout(LayoutKind.Explicit)]
public struct ApiSetNamespace
{
    [FieldOffset(0x0C)] public int Count;
    [FieldOffset(0x10)] public int EntryOffset;
}
