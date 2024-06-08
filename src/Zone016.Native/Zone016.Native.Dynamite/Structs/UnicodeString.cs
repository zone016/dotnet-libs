// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Native.Dynamite.Structs;

[StructLayout(LayoutKind.Sequential)]
public struct UnicodeString(ushort length, ushort maximumLength, IntPtr buffer)
{
    public readonly ushort Length = length;
    public readonly ushort MaximumLength = maximumLength;
    public readonly IntPtr Buffer = buffer;
}
