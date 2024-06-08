// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Native.Dynamite.Structs;

[StructLayout(LayoutKind.Sequential)]
public struct ImageBaseRelocation
{
    public uint VirtualAddress;
    public uint SizeOfBlock;
}
