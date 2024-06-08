// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Native.Dynamite.Structs;

[StructLayout(LayoutKind.Sequential)]
public struct ImageImportDescriptor
{
    public uint OriginalFirstThunk;
    public uint TimeDateStamp;
    public uint ForwarderChain;
    public uint Name;
    public uint FirstThunk;
}
