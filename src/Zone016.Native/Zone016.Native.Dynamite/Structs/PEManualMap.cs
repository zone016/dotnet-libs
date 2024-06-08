// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Native.Dynamite.Structs;

// ReSharper disable once InconsistentNaming
[StructLayout(LayoutKind.Sequential)]
public struct PEManualMap
{
    public string DecoyModule;
    public IntPtr ModuleBase;
    public PEMetaData PeInformation;
}
