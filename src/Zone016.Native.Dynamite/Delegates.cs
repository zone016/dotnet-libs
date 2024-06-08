// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Native.Dynamite;

internal static class Delegates
{
    internal delegate bool ReadProcessMemoryDelegate(
        IntPtr handle,
        IntPtr baseAddress,
        IntPtr buffer,
        long size,
        out IntPtr bytesRead
    );

    internal delegate bool WriteProcessMemoryDelegate(
        IntPtr handle,
        IntPtr baseAddress,
        IntPtr buffer,
        int size,
        out IntPtr bytesWritten
    );
}
