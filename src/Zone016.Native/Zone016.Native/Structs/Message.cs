// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Native.Structs;

/// <summary>
/// Contains message information from a thread's message queue.
/// </summary>
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
public struct Message
{
    public IntPtr Hwnd;
    public uint MessageId;
    public IntPtr WParam;
    public IntPtr LParam;
    public uint Time;
    public Point Pt;
    private readonly uint _private;
}
