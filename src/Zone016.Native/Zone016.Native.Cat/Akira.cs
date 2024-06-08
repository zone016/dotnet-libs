using System.Text;

namespace Zone016.Native.Cat;

public class Akira(IntPtr processHandle)
{
    public TStruct ReadVirtualMemory<TStruct>(IntPtr baseAddress) where TStruct : struct
    {
        var size = Marshal.SizeOf<TStruct>();
        var buffer = Marshal.AllocHGlobal(size);

        var parameters = new object[] { processHandle, baseAddress, buffer, size, IntPtr.Zero };

        var status = Generic.DynamicApiInvoke<NTStatus>(
            "ntdll.dll",
            "NtReadVirtualMemory",
            typeof(Delegates.NtReadVirtualMemory),
            ref parameters
        );

        if (status != NTStatus.Success)
        {
            Marshal.FreeHGlobal(buffer);
            throw new Win32Exception($"Unable to read memory at 0x{baseAddress:X}, returned {status}.");
        }

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
    
    public byte[] ReadVirtualMemory(IntPtr baseAddress, long size)
    {
        var buffer = new byte[size];
        var parameters = new object[] { processHandle, baseAddress, buffer, size, IntPtr.Zero };

        var status = Generic.DynamicApiInvoke<NTStatus>(
            "ntdll.dll",
            "NtReadVirtualMemory",
            typeof(Delegates.NtReadVirtualMemory),
            ref parameters
        );

        if (status != NTStatus.Success)
        {
            throw new Win32Exception($"Unable to read memory at 0x{baseAddress:X}, returned {status}.");
        }

        return buffer;
    }
    
    public void WriteVirtualMemory(IntPtr baseAddress, string data)
        {
            var bytes = Encoding.UTF8.GetBytes(data);
            WriteVirtualMemory(baseAddress, bytes);
        }

        public void WriteVirtualMemory<TStruct>(IntPtr baseAddress, TStruct structToWrite) where TStruct : struct
        {
            var size = Marshal.SizeOf<TStruct>();
            var buffer = Marshal.AllocHGlobal(size);
            try
            {
                Marshal.StructureToPtr(structToWrite, buffer, false);
                WriteVirtualMemory(baseAddress, buffer, size);
            }
            finally
            {
                Marshal.FreeHGlobal(buffer);
            }
        }

        public void WriteVirtualMemory(IntPtr baseAddress, byte[] bytesToWrite)
        {
            var size = bytesToWrite.Length;
            var bufferHandle = GCHandle.Alloc(bytesToWrite, GCHandleType.Pinned);

            try
            {
                WriteVirtualMemory(baseAddress, bufferHandle.AddrOfPinnedObject(), size);
            }
            finally
            {
                bufferHandle.Free();
            }
        }

        private void WriteVirtualMemory(IntPtr baseAddress, IntPtr buffer, int size)
        {
            var parameters = new object[]
            {
                processHandle,
                baseAddress,
                buffer,
                size,
                IntPtr.Zero
            };

            var status = Generic.DynamicApiInvoke<NTStatus>(
                "ntdll.dll",
                "NtWriteVirtualMemory",
                typeof(Delegates.NtWriteVirtualMemory),
                ref parameters);

            if (status != NTStatus.Success)
            {
                throw new Win32Exception($"Unable to write memory at 0x{baseAddress:X}, returned {status}.");
            }

            var writtenBuffer = (IntPtr)parameters[4];
            if (writtenBuffer.ToInt32() != size)
            {
                throw new Win32Exception(
                    $"Written bytes differ from the API (struct size is {size}, but the return was {writtenBuffer.ToInt32()})"
                );
            }
        }
    
    public IntPtr AllocateVirtualMemory(int size, MemoryProtection protectionType = MemoryProtection.ExecuteReadWrite)
    {
        const AllocationType AllocationType = AllocationType.Commit | AllocationType.Reserve;
        var baseAddress = IntPtr.Zero;
        var regionSize = new IntPtr(size);

        var parameters = new object[]
        {
            processHandle,
            baseAddress,
            IntPtr.Zero,
            regionSize,
            AllocationType,
            protectionType
        };

        var ntStatus = Generic.DynamicApiInvoke<NTStatus>(
            "ntdll.dll",
            "NtAllocateVirtualMemory",
            typeof(Delegates.NtAllocateVirtualMemory),
            ref parameters);

        baseAddress = (IntPtr)parameters[1];

        if (ntStatus != NTStatus.Success)
        {
            throw new Win32Exception($"Unable to allocate memory, returned {ntStatus}.");
        }

        return baseAddress;
    }
}
