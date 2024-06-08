// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Native.Dynamite.Enums;

/// <summary>
/// Specifies the type of process information to be retrieved or set.
/// </summary>
public enum ProcessInformationClass
{
    /// <summary>
    /// Basic information about a process.
    /// </summary>
    ProcessBasicInformation = 0,

    /// <summary>
    /// Information about quota limits.
    /// </summary>
    ProcessQuotaLimits,

    /// <summary>
    /// I/O counters.
    /// </summary>
    ProcessIoCounters,

    /// <summary>
    /// Virtual memory counters.
    /// </summary>
    ProcessVmCounters,

    /// <summary>
    /// Kernel and user mode times.
    /// </summary>
    ProcessTimes,

    /// <summary>
    /// Base priority.
    /// </summary>
    ProcessBasePriority,

    /// <summary>
    /// Priority boost.
    /// </summary>
    ProcessRaisePriority,

    /// <summary>
    /// Debug port.
    /// </summary>
    ProcessDebugPort,

    /// <summary>
    /// Exception port.
    /// </summary>
    ProcessExceptionPort,

    /// <summary>
    /// Access token.
    /// </summary>
    ProcessAccessToken,

    /// <summary>
    /// LDT information.
    /// </summary>
    ProcessLdtInformation,

    /// <summary>
    /// LDT size.
    /// </summary>
    ProcessLdtSize,

    /// <summary>
    /// Default hard error mode.
    /// </summary>
    ProcessDefaultHardErrorMode,

    /// <summary>
    /// I/O port handlers (kernel-mode only).
    /// </summary>
    ProcessIoPortHandlers,

    /// <summary>
    /// Pooled usage and limits.
    /// </summary>
    ProcessPooledUsageAndLimits,

    /// <summary>
    /// Working set watch.
    /// </summary>
    ProcessWorkingSetWatch,

    /// <summary>
    /// User-mode IOPL.
    /// </summary>
    ProcessUserModeIOPL,

    /// <summary>
    /// Alignment fault fixup.
    /// </summary>
    ProcessEnableAlignmentFaultFixup,

    /// <summary>
    /// Priority class.
    /// </summary>
    ProcessPriorityClass,

    /// <summary>
    /// Wx86 information.
    /// </summary>
    ProcessWx86Information,

    /// <summary>
    /// Handle count.
    /// </summary>
    ProcessHandleCount,

    /// <summary>
    /// Affinity mask.
    /// </summary>
    ProcessAffinityMask,

    /// <summary>
    /// Priority boost.
    /// </summary>
    ProcessPriorityBoost,

    /// <summary>
    /// Device map.
    /// </summary>
    ProcessDeviceMap,

    /// <summary>
    /// Session information.
    /// </summary>
    ProcessSessionInformation,

    /// <summary>
    /// Foreground information.
    /// </summary>
    ProcessForegroundInformation,

    /// <summary>
    /// WoW64 information.
    /// </summary>
    ProcessWow64Information,

    /// <summary>
    /// Image file name.
    /// </summary>
    ProcessImageFileName,

    /// <summary>
    /// LUID device maps enabled.
    /// </summary>
    ProcessLUIDDeviceMapsEnabled,

    /// <summary>
    /// Break on termination.
    /// </summary>
    ProcessBreakOnTermination,

    /// <summary>
    /// Debug object handle.
    /// </summary>
    ProcessDebugObjectHandle,

    /// <summary>
    /// Debug flags.
    /// </summary>
    ProcessDebugFlags,

    /// <summary>
    /// Handle tracing.
    /// </summary>
    ProcessHandleTracing,

    /// <summary>
    /// I/O priority.
    /// </summary>
    ProcessIoPriority,

    /// <summary>
    /// Execute flags.
    /// </summary>
    ProcessExecuteFlags,

    /// <summary>
    /// Resource management.
    /// </summary>
    ProcessResourceManagement,

    /// <summary>
    /// Cookie.
    /// </summary>
    ProcessCookie,

    /// <summary>
    /// Image information.
    /// </summary>
    ProcessImageInformation,

    /// <summary>
    /// Cycle time.
    /// </summary>
    ProcessCycleTime,

    /// <summary>
    /// Page priority.
    /// </summary>
    ProcessPagePriority,

    /// <summary>
    /// Instrumentation callback.
    /// </summary>
    ProcessInstrumentationCallback,

    /// <summary>
    /// Thread stack allocation.
    /// </summary>
    ProcessThreadStackAllocation,

    /// <summary>
    /// Working set watch extended.
    /// </summary>
    ProcessWorkingSetWatchEx,

    /// <summary>
    /// Image file name (Win32).
    /// </summary>
    ProcessImageFileNameWin32,

    /// <summary>
    /// Image file mapping.
    /// </summary>
    ProcessImageFileMapping,

    /// <summary>
    /// Affinity update mode.
    /// </summary>
    ProcessAffinityUpdateMode,

    /// <summary>
    /// Memory allocation mode.
    /// </summary>
    ProcessMemoryAllocationMode,

    /// <summary>
    /// Group information.
    /// </summary>
    ProcessGroupInformation,

    /// <summary>
    /// Token virtualization enabled.
    /// </summary>
    ProcessTokenVirtualizationEnabled,

    /// <summary>
    /// Console host process.
    /// </summary>
    ProcessConsoleHostProcess,

    /// <summary>
    /// Window information.
    /// </summary>
    ProcessWindowInformation,

    /// <summary>
    /// Handle information.
    /// </summary>
    ProcessHandleInformation,

    /// <summary>
    /// Mitigation policy.
    /// </summary>
    ProcessMitigationPolicy,

    /// <summary>
    /// Dynamic function table information.
    /// </summary>
    ProcessDynamicFunctionTableInformation,

    /// <summary>
    /// Handle checking mode.
    /// </summary>
    ProcessHandleCheckingMode,

    /// <summary>
    /// Keep-alive count.
    /// </summary>
    ProcessKeepAliveCount,

    /// <summary>
    /// Revoke file handles.
    /// </summary>
    ProcessRevokeFileHandles,

    /// <summary>
    /// Maximum process information class.
    /// </summary>
    MaxProcessInfoClass
}
