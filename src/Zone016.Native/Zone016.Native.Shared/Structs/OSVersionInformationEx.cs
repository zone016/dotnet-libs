// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Native.Shared.Structs;

/// <summary>
/// Contains operating system version information.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct OSVersionInformationEx
{
    /// <summary>
    /// The size of the OS version information structure.
    /// </summary>
    public uint OSVersionInfoSize;

    /// <summary>
    /// The major version number of the operating system.
    /// </summary>
    public uint MajorVersion;

    /// <summary>
    /// The minor version number of the operating system.
    /// </summary>
    public uint MinorVersion;

    /// <summary>
    /// The build number of the operating system.
    /// </summary>
    public uint BuildNumber;

    /// <summary>
    /// The platform ID of the operating system.
    /// </summary>
    public uint PlatformId;

    /// <summary>
    /// The major version number of the service pack.
    /// </summary>
    public ushort ServicePackMajor;

    /// <summary>
    /// The minor version number of the service pack.
    /// </summary>
    public ushort ServicePackMinor;

    /// <summary>
    /// The suite mask.
    /// </summary>
    public ushort SuiteMask;

    /// <summary>
    /// The product type.
    /// </summary>
    public byte ProductType;

    /// <summary>
    /// Reserved for future use.
    /// </summary>
    public byte Reserved;

    /// <summary>
    /// A null-terminated string, such as "Service Pack 3", that indicates 
    /// the latest Service Pack installed on the system.
    /// </summary>
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
    public string CSDVersion;
}
