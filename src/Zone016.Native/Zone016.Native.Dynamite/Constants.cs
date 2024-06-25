// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Native.Dynamite;

public static class Constants
{
    public const uint DllProcessDetach = 0;
    public const uint DllProcessAttach = 1;
    public const uint DllThreadAttach = 2;
    public const uint DllThreadDetach = 3;

    public const uint MemoryCommit = 0x1000;
    public const uint MemoryReserve = 0x2000;
    public const uint MemoryRelease = 0x8000;

    public const uint PageReadonly = 0x02;
    public const uint PageReadwrite = 0x04;
    public const uint PageExecute = 0x10;
    public const uint PageExecuteRead = 0x20;
    public const uint PageExecuteReadWrite = 0x40;

    public const uint SecImage = 0x1000000;

    public const int ProcessBasicInformation = 0;
    public const int ProcessModuleInformation = 2;
}
