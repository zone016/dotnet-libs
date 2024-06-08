// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Native.Shared.Structs;

/// <summary>
/// Represents a doubly linked list entry.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct ListEntry
{
    /// <summary>
    /// A pointer to the next entry in the list.
    /// </summary>
    public IntPtr Flink;

    /// <summary>
    /// A pointer to the previous entry in the list.
    /// </summary>
    public IntPtr Blink;
}
