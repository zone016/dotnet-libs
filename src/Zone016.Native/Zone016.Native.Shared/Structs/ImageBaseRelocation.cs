// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Native.Shared.Structs;

[StructLayout(LayoutKind.Sequential)]
public struct ImageBaseRelocation
{
    public uint VirtualAddress;
    public uint SizeOfBlock;
}
