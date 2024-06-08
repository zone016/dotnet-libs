// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Native.Shared.Enums;

[Flags]
public enum FileAccessFlags : uint
{
    Delete = 0x10000,
    FileReadData = 0x1,
    FileReadAttributes = 0x80,
    FileReadEa = 0x8,
    ReadControl = 0x20000,
    FileWriteData = 0x2,
    FileWriteAttributes = 0x100,
    FileWriteEa = 0x10,
    FileAppendData = 0x4,
    WriteDac = 0x40000,
    WriteOwner = 0x80000,
    Synchronize = 0x100000,
    FileExecute = 0x20
}
