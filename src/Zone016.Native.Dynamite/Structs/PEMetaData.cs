// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Native.Dynamite.Structs;

// ReSharper disable once InconsistentNaming
[StructLayout(LayoutKind.Sequential)]
public struct PEMetaData
{
    public uint Pe;
    public bool Is32Bit;
    public ImageFileHeader ImageFileHeader;
    public ImageOptionalHeader32 OptHeader32;
    public ImageOptionalHeader64 OptHeader64;
    public ImageSectionHeader[] Sections;
}
