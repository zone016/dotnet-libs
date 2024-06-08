// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Native.Shared.Structs;

[StructLayout(LayoutKind.Sequential)]
public struct ClientId
{
    public IntPtr UniqueProcess;
    public IntPtr UniqueThread;
}
