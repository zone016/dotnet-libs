// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Native.Dynamite;

public class Delegates
{
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate bool DllMain(IntPtr hinstDll, uint fdwReason, IntPtr lpvReserved);
}
