// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

// Original author: Ryan Cobb (@cobbr_io)
// Project: SharpSploit (https://github.com/cobbr/SharpSploit)

namespace Zone016.Native.Dynamite;

/// <summary>
/// Contains function prototypes and wrapper functions for dynamically invoking NT API Calls.
/// </summary>
public static class Native
{
    private const string LibraryName = "ntdll.dll";

    public static NTStatus NtCreateThreadEx(ref IntPtr threadHandle,
        AccessMask desiredAccess, IntPtr objectAttributes, IntPtr processHandle, IntPtr startAddress,
        IntPtr parameter, bool createSuspended, int stackZeroBits, int sizeOfStack, int maximumStackSize,
        IntPtr attributeList)
    {
        object[] parameters =
        [
            threadHandle,
            desiredAccess,
            objectAttributes,
            processHandle,
            startAddress,
            parameter,
            createSuspended,
            stackZeroBits,
            sizeOfStack,
            maximumStackSize,
            attributeList
        ];

        var status = Generic.DynamicApiInvoke<NTStatus>(
            LibraryName,
            "NtCreateThreadEx",
            typeof(NtCreateThreadExDelegate),
            ref parameters);

        threadHandle = (IntPtr)parameters[0];
        return status;
    }

    public static NTStatus NtCreateSection(ref IntPtr sectionHandle, uint desiredAccess,
        IntPtr objectAttributes, ref ulong maximumSize, uint sectionPageProtection, uint allocationAttributes,
        IntPtr fileHandle)
    {
        object[] parameters =
        [
            sectionHandle,
            desiredAccess,
            objectAttributes,
            maximumSize,
            sectionPageProtection,
            allocationAttributes,
            fileHandle
        ];

        var status = Generic.DynamicApiInvoke<NTStatus>(
            LibraryName,
            "NtCreateSection",
            typeof(NtCreateSectionDelegate),
            ref parameters);

        sectionHandle = (IntPtr)parameters[0];
        maximumSize = (ulong)parameters[3];

        return status;
    }

    public static NTStatus NtUnmapViewOfSection(IntPtr hProc, IntPtr baseAddr)
    {
        object[] parameters = [hProc, baseAddr];

        return Generic.DynamicApiInvoke<NTStatus>(
            LibraryName,
            "NtUnmapViewOfSection",
            typeof(NtUnmapViewOfSectionDelegate),
            ref parameters);
    }

    public static NTStatus NtMapViewOfSection(IntPtr sectionHandle, IntPtr processHandle,
        ref IntPtr baseAddress, IntPtr zeroBits, IntPtr commitSize, IntPtr sectionOffset, ref ulong viewSize,
        uint inheritDisposition, uint allocationType, uint win32Protect)
    {
        object[] parameters =
        [
            sectionHandle,
            processHandle,
            baseAddress,
            zeroBits,
            commitSize,
            sectionOffset,
            viewSize,
            inheritDisposition,
            allocationType,
            win32Protect
        ];

        var status = Generic.DynamicApiInvoke<NTStatus>(
            "ntdll.dll",
            "NtMapViewOfSection",
            typeof(NtMapViewOfSectionDelegate),
            ref parameters);

        baseAddress = (IntPtr)parameters[2];
        viewSize = (ulong)parameters[6];

        return status;
    }

    public static void RtlInitUnicodeString(ref UnicodeString destinationString,
        [MarshalAs(UnmanagedType.LPWStr)] string sourceString)
    {
        object[] parameters = [destinationString, sourceString];

        Generic.DynamicApiInvoke<object>(
            LibraryName,
            "RtlInitUnicodeString",
            typeof(RtlInitUnicodeStringDelegate),
            ref parameters);

        destinationString = (UnicodeString)parameters[0];
    }

    public static NTStatus LdrLoadDll(IntPtr pathToFile, uint dwFlags,
        ref UnicodeString moduleFileName, ref IntPtr moduleHandle)
    {
        object[] parameters =
        [
            pathToFile,
            dwFlags,
            moduleFileName,
            moduleHandle
        ];

        var status = Generic.DynamicApiInvoke<NTStatus>(
            LibraryName,
            "LdrLoadDll",
            typeof(LdrLoadDllDelegate),
            ref parameters);

        moduleHandle = (IntPtr)parameters[3];
        return status;
    }

    public static void RtlZeroMemory(IntPtr destination, int length)
    {
        object[] parameters = [destination, length];

        _ = Generic.DynamicApiInvoke<object>(
            LibraryName,
            "RtlZeroMemory",
            typeof(RtlZeroMemoryDelegate),
            ref parameters);
    }

    public static NTStatus NtQueryInformationProcess(IntPtr hProcess,
        ProcessInformationClass processInfoClass, out IntPtr pProcInfo)
    {
        int processInformationLength;
        uint retLen = 0;

        switch (processInfoClass)
        {
            case ProcessInformationClass.ProcessWow64Information:
                pProcInfo = Marshal.AllocHGlobal(IntPtr.Size);
                RtlZeroMemory(pProcInfo, IntPtr.Size);
                processInformationLength = IntPtr.Size;
                break;

            case ProcessInformationClass.ProcessBasicInformation:
                var pbi = new ProcessBasicInformation();
                pProcInfo = Marshal.AllocHGlobal(Marshal.SizeOf(pbi));
                RtlZeroMemory(pProcInfo, Marshal.SizeOf(pbi));
                Marshal.StructureToPtr(pbi, pProcInfo, true);
                processInformationLength = Marshal.SizeOf(pbi);
                break;

            default:
                throw new InvalidOperationException($"Invalid ProcessInfoClass: {processInfoClass}");
        }

        object[] parameters =
        [
            hProcess,
            processInfoClass,
            pProcInfo,
            processInformationLength,
            retLen
        ];

        var status = Generic.DynamicApiInvoke<NTStatus>(
            LibraryName,
            "NtQueryInformationProcess",
            typeof(NtQueryInformationProcessDelegate),
            ref parameters);

        pProcInfo = (IntPtr)parameters[2];
        return status;
    }

    public static bool NtQueryInformationProcessWow64Information(IntPtr hProcess)
    {
        _ = NtQueryInformationProcess(
            hProcess,
            ProcessInformationClass.ProcessWow64Information,
            out var pProcInfo);

        return Marshal.ReadIntPtr(pProcInfo) != IntPtr.Zero;
    }

    public static ProcessBasicInformation NtQueryInformationProcessBasicInformation(IntPtr hProcess)
    {
        _ = NtQueryInformationProcess(
            hProcess,
            ProcessInformationClass.ProcessBasicInformation,
            out var pProcInfo);

        return Marshal.PtrToStructure<ProcessBasicInformation>(pProcInfo);
    }

    public static IntPtr NtAllocateVirtualMemory(IntPtr processHandle, ref IntPtr baseAddress, IntPtr zeroBits,
        ref IntPtr regionSize, uint allocationType, uint protect)
    {
        object[] parameters =
        [
            processHandle,
            baseAddress,
            zeroBits,
            regionSize,
            allocationType,
            protect
        ];

        _ = Generic.DynamicApiInvoke<NTStatus>(
            LibraryName,
            "NtAllocateVirtualMemory",
            typeof(NtAllocateVirtualMemoryDelegate),
            ref parameters);

        baseAddress = (IntPtr)parameters[1];
        return baseAddress;
    }

    public static void NtFreeVirtualMemory(IntPtr processHandle, ref IntPtr baseAddress, ref IntPtr regionSize,
        uint freeType)
    {
        object[] parameters = [processHandle, baseAddress, regionSize, freeType];

        _ = Generic.DynamicApiInvoke<NTStatus>(
            LibraryName,
            "NtFreeVirtualMemory",
            typeof(NtFreeVirtualMemoryDelegate),
            ref parameters);
    }

    public static uint NtProtectVirtualMemory(IntPtr processHandle, ref IntPtr baseAddress, ref IntPtr regionSize,
        uint newProtect)
    {
        object[] parameters = [processHandle, baseAddress, regionSize, newProtect, (uint)0];

        _ = Generic.DynamicApiInvoke<NTStatus>(
            LibraryName,
            "NtProtectVirtualMemory",
            typeof(NtProtectVirtualMemoryDelegate),
            ref parameters);

        return (uint)parameters[4];
    }

    public static uint NtWriteVirtualMemory(IntPtr processHandle, IntPtr baseAddress, IntPtr buffer, uint bufferLength)
    {
        object[] parameters = [processHandle, baseAddress, buffer, bufferLength, (uint)0];

        _ = Generic.DynamicApiInvoke<NTStatus>(
            LibraryName,
            "NtWriteVirtualMemory",
            typeof(NtWriteVirtualMemoryDelegate),
            ref parameters);

        return (uint)parameters[4];
    }

    public static IntPtr LdrGetProcedureAddress(IntPtr hModule, IntPtr functionName, IntPtr ordinal,
        ref IntPtr functionAddress)
    {
        object[] parameters = [hModule, functionName, ordinal, functionAddress];

        _ = Generic.DynamicApiInvoke<NTStatus>(
            LibraryName,
            "LdrGetProcedureAddress",
            typeof(LdrGetProcedureAddressDelegate),
            ref parameters);

        functionAddress = (IntPtr)parameters[3];
        return functionAddress;
    }

    public static void RtlGetVersion(ref OSVersionInformationEx versionInformation)
    {
        object[] parameters = [versionInformation];

        _ = Generic.DynamicApiInvoke<NTStatus>(
            LibraryName,
            "RtlGetVersion",
            typeof(RtlGetVersionDelegate),
            ref parameters);

        versionInformation = (OSVersionInformationEx)parameters[0];
    }

    public static IntPtr NtOpenFile(ref IntPtr fileHandle, FileAccessFlags desiredAccess,
        ref ObjectAttributes objectAttributes, ref IOStatusBlock ioStatusBlock,
        FileShareFlags shareAccess, FileOpenFlags openOptions)
    {
        object[] parameters =
        [
            fileHandle,
            desiredAccess,
            objectAttributes,
            ioStatusBlock,
            shareAccess,
            openOptions
        ];

        _ = Generic.DynamicApiInvoke<NTStatus>(
            @"ntdll.dll",
            @"NtOpenFile",
            typeof(NtOpenFileDelegate),
            ref parameters);

        fileHandle = (IntPtr)parameters[0];
        return fileHandle;
    }

    public static void NtClose(IntPtr handle)
    {
        object[] parameters = [handle];

        _ = Generic.DynamicApiInvoke<uint>(
            LibraryName,
            "NtClose",
            typeof(NtCloseDelegate),
            ref parameters);
    }

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    private delegate uint NtCreateThreadExDelegate(
        out IntPtr threadHandle,
        AccessMask desiredAccess,
        IntPtr objectAttributes,
        IntPtr processHandle,
        IntPtr startAddress,
        IntPtr parameter,
        bool createSuspended,
        int stackZeroBits,
        int sizeOfStack,
        int maximumStackSize,
        IntPtr attributeList);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    private delegate uint NtCreateSectionDelegate(
        ref IntPtr sectionHandle,
        uint desiredAccess,
        IntPtr objectAttributes,
        ref ulong maximumSize,
        uint sectionPageProtection,
        uint allocationAttributes,
        IntPtr fileHandle);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    private delegate uint NtUnmapViewOfSectionDelegate(
        IntPtr hProc,
        IntPtr baseAddr);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    private delegate uint NtMapViewOfSectionDelegate(
        IntPtr sectionHandle,
        IntPtr processHandle,
        out IntPtr baseAddress,
        IntPtr zeroBits,
        IntPtr commitSize,
        IntPtr sectionOffset,
        out ulong viewSize,
        uint inheritDisposition,
        uint allocationType,
        uint win32Protect);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    private delegate uint LdrLoadDllDelegate(
        IntPtr pathToFile,
        uint dwFlags,
        ref UnicodeString moduleFileName,
        ref IntPtr moduleHandle);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    private delegate void RtlInitUnicodeStringDelegate(
        ref UnicodeString destinationString,
        [MarshalAs(UnmanagedType.LPWStr)] string sourceString);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    private delegate void RtlZeroMemoryDelegate(
        IntPtr destination,
        int length);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    private delegate uint NtQueryInformationProcessDelegate(
        IntPtr processHandle,
        ProcessInformationClass processInformationClass,
        IntPtr processInformation,
        int processInformationLength,
        ref uint returnLength);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    private delegate uint NtAllocateVirtualMemoryDelegate(
        IntPtr processHandle,
        ref IntPtr baseAddress,
        IntPtr zeroBits,
        ref IntPtr regionSize,
        uint allocationType,
        uint protect);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    private delegate uint NtFreeVirtualMemoryDelegate(
        IntPtr processHandle,
        ref IntPtr baseAddress,
        ref IntPtr regionSize,
        uint freeType);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    private delegate uint NtProtectVirtualMemoryDelegate(
        IntPtr processHandle,
        ref IntPtr baseAddress,
        ref IntPtr regionSize,
        uint newProtect,
        ref uint oldProtect);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    private delegate uint NtWriteVirtualMemoryDelegate(
        IntPtr processHandle,
        IntPtr baseAddress,
        IntPtr buffer,
        uint bufferLength,
        ref uint bytesWritten);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    private delegate uint LdrGetProcedureAddressDelegate(
        IntPtr hModule,
        IntPtr functionName,
        IntPtr ordinal,
        ref IntPtr functionAddress);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    private delegate uint RtlGetVersionDelegate(
        ref OSVersionInformationEx versionInformation);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    private delegate uint NtOpenFileDelegate(
        ref IntPtr fileHandle,
        FileAccessFlags accessFlags,
        ref ObjectAttributes objectAttributes,
        IOStatusBlock ioStatusBlock,
        FileShareFlags shareAccess,
        FileOpenFlags openOptions);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    private delegate uint NtCloseDelegate(
        IntPtr handle);
}
