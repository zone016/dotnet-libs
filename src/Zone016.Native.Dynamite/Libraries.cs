// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Native.Dynamite;

internal static class Libraries
{
    public static readonly IntPtr Kernel32 = Native.LoadLibrary("kernel32.dll");
}
