// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

// ReSharper disable InconsistentNaming
namespace Zone016.Native.Dynamite.Structs;

/// <summary>
/// Represents the status block of an I/O operation.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct IOStatusBlock
{
    /// <summary>
    /// The status of the I/O operation.
    /// </summary>
    public IntPtr Status;

    /// <summary>
    /// Additional information about the I/O operation.
    /// </summary>
    public IntPtr Information;
}
