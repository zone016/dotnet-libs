// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Native.Shared.Structs;

/// <summary>
/// Represents a point (x, y) in 2D space.
/// </summary>
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
public struct Point
{
    public int X;
    public int Y;
}
