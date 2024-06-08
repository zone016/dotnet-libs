// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Native.Dynamite;

public class Referrer(IntPtr handle)
{
    private readonly IntPtr _readProcessMemoryAddress = Native.GetProcAddress(Libraries.Kernel32, "ReadProcessMemory");
    private readonly IntPtr _writeProcessMemoryAddress = Native.GetProcAddress(Libraries.Kernel32, "WriteProcessMemory");

    public TStruct ReadVirtualMemory<TStruct>(IntPtr baseAddress, out int bytesRead)
        where TStruct : struct
    {
        var size = Marshal.SizeOf<TStruct>();
        var buffer = Marshal.AllocHGlobal(size);

        var readProcessMemory = Marshal.GetDelegateForFunctionPointer<Delegates.ReadProcessMemoryDelegate>(_readProcessMemoryAddress);
        readProcessMemory(handle, baseAddress, buffer, size, out var bytesReadPointer);
        bytesRead = bytesReadPointer.ToInt32();
        
        try
        {
            var entity = Marshal.PtrToStructure<TStruct>(buffer);
            return entity;
        }
        finally
        {
            Marshal.FreeHGlobal(buffer);
        }
    }

    public bool WriteVirtualMemory<TStruct>(IntPtr baseAddress, TStruct structToWrite, out int bytesWritten)
        where TStruct : struct
    {
        var size = Marshal.SizeOf<TStruct>();
        var bufferHandle = GCHandle.Alloc(structToWrite, GCHandleType.Pinned);
        var buffer = bufferHandle.AddrOfPinnedObject();

        var writeProcessMemory = Marshal.GetDelegateForFunctionPointer<Delegates.WriteProcessMemoryDelegate>(_writeProcessMemoryAddress);
        var result = writeProcessMemory(handle, baseAddress, buffer, size, out var bytesWrittenPointer);
        bytesWritten = bytesWrittenPointer.ToInt32();
        
        Marshal.FreeHGlobal(buffer);
        return result;
    }
}
