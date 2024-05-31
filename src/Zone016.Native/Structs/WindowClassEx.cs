// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

using Zone016.Native.Delegates;

namespace Zone016.Native.Structs;

/// <summary>
/// Describes a window class.
/// </summary>
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
public struct WindowClassEx
{
    public int CbSize;
    public int Style;
    public WndProc LpfnWndProc;
    public int CbClsExtra;
    public int CbWndExtra;
    public IntPtr HInstance;
    public IntPtr HIcon;
    public IntPtr HCursor;
    public IntPtr HbrBackground;
    public string LpszMenuName;
    public string LpszClassName;
    public IntPtr HIconSm;
}
