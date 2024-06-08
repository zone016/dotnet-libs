// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

// ReSharper disable InconsistentNaming
namespace Zone016.Native.Dynamite.Enums;

public enum NTStatus : uint
{
    /// <summary>The operation completed successfully.</summary>
    Success = 0x00000000,

    /// <summary>Wait state 0.</summary>
    Wait0 = 0x00000000,

    /// <summary>Wait state 1.</summary>
    Wait1 = 0x00000001,

    /// <summary>Wait state 2.</summary>
    Wait2 = 0x00000002,

    /// <summary>Wait state 3.</summary>
    Wait3 = 0x00000003,

    /// <summary>Wait state 63.</summary>
    Wait63 = 0x0000003f,

    /// <summary>An abandoned wait state.</summary>
    Abandoned = 0x00000080,

    /// <summary>An abandoned wait state 0.</summary>
    AbandonedWait0 = 0x00000080,

    /// <summary>An abandoned wait state 1.</summary>
    AbandonedWait1 = 0x00000081,

    /// <summary>An abandoned wait state 2.</summary>
    AbandonedWait2 = 0x00000082,

    /// <summary>An abandoned wait state 3.</summary>
    AbandonedWait3 = 0x00000083,

    /// <summary>An abandoned wait state 63.</summary>
    AbandonedWait63 = 0x000000bf,

    /// <summary>A user APC is pending.</summary>
    UserApc = 0x000000c0,

    /// <summary>A kernel APC is pending.</summary>
    KernelApc = 0x00000100,

    /// <summary>A thread is alerted.</summary>
    Alerted = 0x00000101,

    /// <summary>The specified time-out period has expired.</summary>
    Timeout = 0x00000102,

    /// <summary>The operation is pending.</summary>
    Pending = 0x00000103,

    /// <summary>The operation requires reparse.</summary>
    Reparse = 0x00000104,

    /// <summary>There are more entries to be processed.</summary>
    MoreEntries = 0x00000105,

    /// <summary>Not all assigned resources were used.</summary>
    NotAllAssigned = 0x00000106,

    /// <summary>Some resources were not mapped.</summary>
    SomeNotMapped = 0x00000107,

    /// <summary>An oplock break is in progress.</summary>
    OpLockBreakInProgress = 0x00000108,

    /// <summary>A volume has been mounted.</summary>
    VolumeMounted = 0x00000109,

    /// <summary>An RXACT committed.</summary>
    RxActCommitted = 0x0000010a,

    /// <summary>Notify cleanup is in progress.</summary>
    NotifyCleanup = 0x0000010b,

    /// <summary>Notify enumeration directory.</summary>
    NotifyEnumDir = 0x0000010c,

    /// <summary>No quotas for the specified account.</summary>
    NoQuotasForAccount = 0x0000010d,

    /// <summary>The primary transport connect failed.</summary>
    PrimaryTransportConnectFailed = 0x0000010e,

    /// <summary>Page fault transition.</summary>
    PageFaultTransition = 0x00000110,

    /// <summary>Page fault demand zero.</summary>
    PageFaultDemandZero = 0x00000111,

    /// <summary>Page fault copy on write.</summary>
    PageFaultCopyOnWrite = 0x00000112,

    /// <summary>Page fault guard page.</summary>
    PageFaultGuardPage = 0x00000113,

    /// <summary>Page fault paging file.</summary>
    PageFaultPagingFile = 0x00000114,

    /// <summary>Crash dump is in progress.</summary>
    CrashDump = 0x00000116,

    /// <summary>Reparse object.</summary>
    ReparseObject = 0x00000118,

    /// <summary>Nothing to terminate.</summary>
    NothingToTerminate = 0x00000122,

    /// <summary>The process is not in a job.</summary>
    ProcessNotInJob = 0x00000123,

    /// <summary>The process is in a job.</summary>
    ProcessInJob = 0x00000124,

    /// <summary>The process was cloned.</summary>
    ProcessCloned = 0x00000129,

    /// <summary>The file is locked with only readers.</summary>
    FileLockedWithOnlyReaders = 0x0000012a,

    /// <summary>The file is locked with writers.</summary>
    FileLockedWithWriters = 0x0000012b,

    // Informational
    /// <summary>Informational status.</summary>
    Informational = 0x40000000,

    /// <summary>The object name already exists.</summary>
    ObjectNameExists = 0x40000000,

    /// <summary>The thread was suspended.</summary>
    ThreadWasSuspended = 0x40000001,

    /// <summary>The working set limit is in range.</summary>
    WorkingSetLimitRange = 0x40000002,

    /// <summary>The image is not at base.</summary>
    ImageNotAtBase = 0x40000003,

    /// <summary>The registry was recovered.</summary>
    RegistryRecovered = 0x40000009,

    // Warning
    /// <summary>Warning status.</summary>
    Warning = 0x80000000,

    /// <summary>A guard page violation occurred.</summary>
    GuardPageViolation = 0x80000001,

    /// <summary>Data type misalignment occurred.</summary>
    DatatypeMisalignment = 0x80000002,

    /// <summary>A breakpoint was encountered.</summary>
    Breakpoint = 0x80000003,

    /// <summary>A single step was executed.</summary>
    SingleStep = 0x80000004,

    /// <summary>A buffer overflow occurred.</summary>
    BufferOverflow = 0x80000005,

    /// <summary>No more files were found.</summary>
    NoMoreFiles = 0x80000006,

    /// <summary>Handles were closed.</summary>
    HandlesClosed = 0x8000000a,

    /// <summary>A partial copy was made.</summary>
    PartialCopy = 0x8000000d,

    /// <summary>The device is busy.</summary>
    DeviceBusy = 0x80000011,

    /// <summary>An invalid EA name was encountered.</summary>
    InvalidEaName = 0x80000013,

    /// <summary>The EA list is inconsistent.</summary>
    EaListInconsistent = 0x80000014,

    /// <summary>No more entries were found.</summary>
    NoMoreEntries = 0x8000001a,

    /// <summary>A long jump was executed.</summary>
    LongJump = 0x80000026,

    /// <summary>The DLL might be insecure.</summary>
    DllMightBeInsecure = 0x8000002b,

    // Error
    /// <summary>Error status.</summary>
    Error = 0xc0000000,

    /// <summary>The operation was unsuccessful.</summary>
    Unsuccessful = 0xc0000001,

    /// <summary>The request is not implemented.</summary>
    NotImplemented = 0xc0000002,

    /// <summary>The specified information class is invalid.</summary>
    InvalidInfoClass = 0xc0000003,

    /// <summary>The specified information record length does not match the length required for the specified information class.</summary>
    InfoLengthMismatch = 0xc0000004,

    /// <summary>The instruction at 0x%p referenced memory at 0x%p. The memory could not be %s.</summary>
    AccessViolation = 0xc0000005,

    /// <summary>The page file quota was exceeded.</summary>
    PagefileQuota = 0xc0000007,

    /// <summary>The handle is invalid.</summary>
    InvalidHandle = 0xc0000008,

    /// <summary>The specified parameter is invalid.</summary>
    InvalidParameter = 0xc000000d,

    /// <summary>No such device exists.</summary>
    NoSuchDevice = 0xc000000e,

    /// <summary>No such file exists.</summary>
    NoSuchFile = 0xc000000f,

    /// <summary>The specified request is not a valid operation for the target device.</summary>
    InvalidDeviceRequest = 0xc0000010,

    /// <summary>The end of the file has been reached.</summary>
    EndOfFile = 0xc0000011,

    /// <summary>The wrong volume is in the drive.</summary>
    WrongVolume = 0xc0000012,

    /// <summary>No media in the device.</summary>
    NoMediaInDevice = 0xc0000013,

    /// <summary>Not enough memory resources are available to complete this operation.</summary>
    NoMemory = 0xc0000017,

    /// <summary>Conflicting addresses were detected.</summary>
    ConflictingAddresses = 0xc0000018,

    /// <summary>The specified address range is invalid.</summary>
    NotMappedView = 0xc0000019,

    /// <summary>The specified address range could not be freed.</summary>
    UnableToFreeVm = 0xc000001a,

    /// <summary>The specified section could not be deleted.</summary>
    UnableToDeleteSection = 0xc000001b,

    /// <summary>An illegal instruction was encountered.</summary>
    IllegalInstruction = 0xc000001d,

    /// <summary>The specified address is already committed.</summary>
    AlreadyCommitted = 0xc0000021,

    /// <summary>Access is denied.</summary>
    AccessDenied = 0xc0000022,

    /// <summary>The buffer is too small.</summary>
    BufferTooSmall = 0xc0000023,

    /// <summary>The specified object type does not match the type required for the operation.</summary>
    ObjectTypeMismatch = 0xc0000024,

    /// <summary>A non-continuable exception was encountered.</summary>
    NonContinuableException = 0xc0000025,

    /// <summary>The stack is bad.</summary>
    BadStack = 0xc0000028,

    /// <summary>The specified address range is not locked.</summary>
    NotLocked = 0xc000002a,

    /// <summary>The specified address range is not committed.</summary>
    NotCommitted = 0xc000002d,

    /// <summary>Invalid parameter mix.</summary>
    InvalidParameterMix = 0xc0000030,

    /// <summary>The object name is invalid.</summary>
    ObjectNameInvalid = 0xc0000033,

    /// <summary>The object name was not found.</summary>
    ObjectNameNotFound = 0xc0000034,

    /// <summary>The object name already exists.</summary>
    ObjectNameCollision = 0xc0000035,

    /// <summary>The object path is invalid.</summary>
    ObjectPathInvalid = 0xc0000039,

    /// <summary>The object path was not found.</summary>
    ObjectPathNotFound = 0xc000003a,

    /// <summary>The object path syntax is bad.</summary>
    ObjectPathSyntaxBad = 0xc000003b,

    /// <summary>Data overrun error.</summary>
    DataOverrun = 0xc000003c,

    /// <summary>Data late error.</summary>
    DataLate = 0xc000003d,

    /// <summary>Data error.</summary>
    DataError = 0xc000003e,

    /// <summary>CRC error.</summary>
    CrcError = 0xc000003f,

    /// <summary>The section is too big.</summary>
    SectionTooBig = 0xc0000040,

    /// <summary>The port connection was refused.</summary>
    PortConnectionRefused = 0xc0000041,

    /// <summary>The specified port handle is invalid.</summary>
    InvalidPortHandle = 0xc0000042,

    /// <summary>A sharing violation occurred.</summary>
    SharingViolation = 0xc0000043,

    /// <summary>The quota was exceeded.</summary>
    QuotaExceeded = 0xc0000044,

    /// <summary>The specified page protection is invalid.</summary>
    InvalidPageProtection = 0xc0000045,

    /// <summary>The mutant object is not owned by the calling thread.</summary>
    MutantNotOwned = 0xc0000046,

    /// <summary>The semaphore limit was exceeded.</summary>
    SemaphoreLimitExceeded = 0xc0000047,

    /// <summary>The port is already set.</summary>
    PortAlreadySet = 0xc0000048,

    /// <summary>The section is not an image.</summary>
    SectionNotImage = 0xc0000049,

    /// <summary>The suspend count was exceeded.</summary>
    SuspendCountExceeded = 0xc000004a,

    /// <summary>The thread is terminating.</summary>
    ThreadIsTerminating = 0xc000004b,

    /// <summary>The working set limit is bad.</summary>
    BadWorkingSetLimit = 0xc000004c,

    /// <summary>The file map is incompatible.</summary>
    IncompatibleFileMap = 0xc000004d,

    /// <summary>The section protection is invalid.</summary>
    SectionProtection = 0xc000004e,

    /// <summary>Extended attributes are not supported.</summary>
    EasNotSupported = 0xc000004f,

    /// <summary>The extended attribute is too large.</summary>
    EaTooLarge = 0xc0000050,

    /// <summary>The specified extended attribute entry does not exist.</summary>
    NonExistentEaEntry = 0xc0000051,

    /// <summary>There are no extended attributes on the file.</summary>
    NoEasOnFile = 0xc0000052,

    /// <summary>The extended attribute list is corrupt.</summary>
    EaCorruptError = 0xc0000053,

    /// <summary>A file lock conflict occurred.</summary>
    FileLockConflict = 0xc0000054,

    /// <summary>The lock was not granted.</summary>
    LockNotGranted = 0xc0000055,

    /// <summary>The file is pending deletion.</summary>
    DeletePending = 0xc0000056,

    /// <summary>Control file operation is not supported.</summary>
    CtlFileNotSupported = 0xc0000057,

    /// <summary>The specified revision is unknown.</summary>
    UnknownRevision = 0xc0000058,

    /// <summary>The specified revision is mismatched.</summary>
    RevisionMismatch = 0xc0000059,

    /// <summary>The specified owner is invalid.</summary>
    InvalidOwner = 0xc000005a,

    /// <summary>The specified primary group is invalid.</summary>
    InvalidPrimaryGroup = 0xc000005b,

    /// <summary>No impersonation token is available.</summary>
    NoImpersonationToken = 0xc000005c,

    /// <summary>Mandatory access control cannot be disabled.</summary>
    CantDisableMandatory = 0xc000005d,

    /// <summary>No logon servers are available.</summary>
    NoLogonServers = 0xc000005e,

    /// <summary>No such logon session exists.</summary>
    NoSuchLogonSession = 0xc000005f,

    /// <summary>No such privilege exists.</summary>
    NoSuchPrivilege = 0xc0000060,

    /// <summary>The privilege is not held by the client.</summary>
    PrivilegeNotHeld = 0xc0000061,

    /// <summary>The specified account name is invalid.</summary>
    InvalidAccountName = 0xc0000062,

    /// <summary>The specified user already exists.</summary>
    UserExists = 0xc0000063,

    /// <summary>No such user exists.</summary>
    NoSuchUser = 0xc0000064,

    /// <summary>The specified group already exists.</summary>
    GroupExists = 0xc0000065,

    /// <summary>No such group exists.</summary>
    NoSuchGroup = 0xc0000066,

    /// <summary>The specified member is already in the group.</summary>
    MemberInGroup = 0xc0000067,

    /// <summary>The specified member is not in the group.</summary>
    MemberNotInGroup = 0xc0000068,

    /// <summary>The specified account is the last administrator account.</summary>
    LastAdmin = 0xc0000069,

    /// <summary>The specified password is incorrect.</summary>
    WrongPassword = 0xc000006a,

    /// <summary>The specified password is ill-formed.</summary>
    IllFormedPassword = 0xc000006b,

    /// <summary>There are password restrictions on the specified account.</summary>
    PasswordRestriction = 0xc000006c,

    /// <summary>Logon failure occurred.</summary>
    LogonFailure = 0xc000006d,

    /// <summary>The specified account is restricted.</summary>
    AccountRestriction = 0xc000006e,

    /// <summary>The specified logon hours are invalid.</summary>
    InvalidLogonHours = 0xc000006f,

    /// <summary>The specified workstation is invalid.</summary>
    InvalidWorkstation = 0xc0000070,

    /// <summary>The specified password has expired.</summary>
    PasswordExpired = 0xc0000071,

    /// <summary>The specified account is disabled.</summary>
    AccountDisabled = 0xc0000072,

    /// <summary>No mapping between account names and security IDs was done.</summary>
    NoneMapped = 0xc0000073,

    /// <summary>Too many local user identifiers were requested.</summary>
    TooManyLuidsRequested = 0xc0000074,

    /// <summary>Local user identifiers have been exhausted.</summary>
    LuidsExhausted = 0xc0000075,

    /// <summary>The specified sub-authority is invalid.</summary>
    InvalidSubAuthority = 0xc0000076,

    /// <summary>The specified ACL is invalid.</summary>
    InvalidAcl = 0xc0000077,

    /// <summary>The specified SID is invalid.</summary>
    InvalidSid = 0xc0000078,

    /// <summary>The specified security descriptor is invalid.</summary>
    InvalidSecurityDescr = 0xc0000079,

    /// <summary>The procedure entry point could not be found.</summary>
    ProcedureNotFound = 0xc000007a,

    /// <summary>The specified image format is invalid.</summary>
    InvalidImageFormat = 0xc000007b,

    /// <summary>No token is available.</summary>
    NoToken = 0xc000007c,

    /// <summary>The specified inheritance ACL is bad.</summary>
    BadInheritanceAcl = 0xc000007d,

    /// <summary>The specified address range is not locked.</summary>
    RangeNotLocked = 0xc000007e,

    /// <summary>The disk is full.</summary>
    DiskFull = 0xc000007f,

    /// <summary>The server is disabled.</summary>
    ServerDisabled = 0xc0000080,

    /// <summary>The server is not disabled.</summary>
    ServerNotDisabled = 0xc0000081,

    /// <summary>Too many GUIDs were requested.</summary>
    TooManyGuidsRequested = 0xc0000082,

    /// <summary>GUIDs have been exhausted.</summary>
    GuidsExhausted = 0xc0000083,

    /// <summary>The specified identifier authority is invalid.</summary>
    InvalidIdAuthority = 0xc0000084,

    /// <summary>The specified agents are exhausted.</summary>
    AgentsExhausted = 0xc0000085,

    /// <summary>The specified volume label is invalid.</summary>
    InvalidVolumeLabel = 0xc0000086,

    /// <summary>The section is not extended.</summary>
    SectionNotExtended = 0xc0000087,

    /// <summary>The specified data is not mapped.</summary>
    NotMappedData = 0xc0000088,

    /// <summary>The resource data was not found.</summary>
    ResourceDataNotFound = 0xc0000089,

    /// <summary>The resource type was not found.</summary>
    ResourceTypeNotFound = 0xc000008a,

    /// <summary>The resource name was not found.</summary>
    ResourceNameNotFound = 0xc000008b,

    /// <summary>The specified array bounds were exceeded.</summary>
    ArrayBoundsExceeded = 0xc000008c,

    /// <summary>A denormalized floating-point operand was encountered.</summary>
    FloatDenormalOperand = 0xc000008d,

    /// <summary>A floating-point divide by zero occurred.</summary>
    FloatDivideByZero = 0xc000008e,

    /// <summary>A floating-point inexact result occurred.</summary>
    FloatInexactResult = 0xc000008f,

    /// <summary>A floating-point invalid operation occurred.</summary>
    FloatInvalidOperation = 0xc0000090,

    /// <summary>A floating-point overflow occurred.</summary>
    FloatOverflow = 0xc0000091,

    /// <summary>A floating-point stack check failed.</summary>
    FloatStackCheck = 0xc0000092,

    /// <summary>A floating-point underflow occurred.</summary>
    FloatUnderflow = 0xc0000093,

    /// <summary>An integer divide by zero occurred.</summary>
    IntegerDivideByZero = 0xc0000094,

    /// <summary>An integer overflow occurred.</summary>
    IntegerOverflow = 0xc0000095,

    /// <summary>A privileged instruction was executed.</summary>
    PrivilegedInstruction = 0xc0000096,

    /// <summary>Too many paging files were specified.</summary>
    TooManyPagingFiles = 0xc0000097,

    /// <summary>The specified file is invalid.</summary>
    FileInvalid = 0xc0000098,

    /// <summary>Insufficient resources are available to complete this operation.</summary>
    InsufficientResources = 0xc000009a,

    /// <summary>The instance is not available.</summary>
    InstanceNotAvailable = 0xc00000ab,

    /// <summary>The pipe is not available.</summary>
    PipeNotAvailable = 0xc00000ac,

    /// <summary>The pipe state is invalid.</summary>
    InvalidPipeState = 0xc00000ad,

    /// <summary>The pipe is busy.</summary>
    PipeBusy = 0xc00000ae,

    /// <summary>The function is illegal.</summary>
    IllegalFunction = 0xc00000af,

    /// <summary>The pipe is disconnected.</summary>
    PipeDisconnected = 0xc00000b0,

    /// <summary>The pipe is closing.</summary>
    PipeClosing = 0xc00000b1,

    /// <summary>The pipe is connected.</summary>
    PipeConnected = 0xc00000b2,

    /// <summary>The pipe is listening.</summary>
    PipeListening = 0xc00000b3,

    /// <summary>The read mode is invalid.</summary>
    InvalidReadMode = 0xc00000b4,

    /// <summary>The I/O operation timed out.</summary>
    IoTimeout = 0xc00000b5,

    /// <summary>The file was forcibly closed.</summary>
    FileForcedClosed = 0xc00000b6,

    /// <summary>Profiling has not started.</summary>
    ProfilingNotStarted = 0xc00000b7,

    /// <summary>Profiling has not stopped.</summary>
    ProfilingNotStopped = 0xc00000b8,

    /// <summary>The specified device is not the same device.</summary>
    NotSameDevice = 0xc00000d4,

    /// <summary>The file was renamed.</summary>
    FileRenamed = 0xc00000d5,

    /// <summary>Cannot wait for the operation.</summary>
    CantWait = 0xc00000d8,

    /// <summary>The pipe is empty.</summary>
    PipeEmpty = 0xc00000d9,

    /// <summary>Cannot terminate the current process.</summary>
    CantTerminateSelf = 0xc00000db,

    /// <summary>An internal error occurred.</summary>
    InternalError = 0xc00000e5,

    /// <summary>Invalid parameter 1.</summary>
    InvalidParameter1 = 0xc00000ef,

    /// <summary>Invalid parameter 2.</summary>
    InvalidParameter2 = 0xc00000f0,

    /// <summary>Invalid parameter 3.</summary>
    InvalidParameter3 = 0xc00000f1,

    /// <summary>Invalid parameter 4.</summary>
    InvalidParameter4 = 0xc00000f2,

    /// <summary>Invalid parameter 5.</summary>
    InvalidParameter5 = 0xc00000f3,

    /// <summary>Invalid parameter 6.</summary>
    InvalidParameter6 = 0xc00000f4,

    /// <summary>Invalid parameter 7.</summary>
    InvalidParameter7 = 0xc00000f5,

    /// <summary>Invalid parameter 8.</summary>
    InvalidParameter8 = 0xc00000f6,

    /// <summary>Invalid parameter 9.</summary>
    InvalidParameter9 = 0xc00000f7,

    /// <summary>Invalid parameter 10.</summary>
    InvalidParameter10 = 0xc00000f8,

    /// <summary>Invalid parameter 11.</summary>
    InvalidParameter11 = 0xc00000f9,

    /// <summary>Invalid parameter 12.</summary>
    InvalidParameter12 = 0xc00000fa,

    /// <summary>The process is terminating.</summary>
    ProcessIsTerminating = 0xc000010a,

    /// <summary>The mapped file size is zero.</summary>
    MappedFileSizeZero = 0xc000011e,

    /// <summary>Too many opened files.</summary>
    TooManyOpenedFiles = 0xc000011f,

    /// <summary>The operation was canceled.</summary>
    Cancelled = 0xc0000120,

    /// <summary>Cannot delete the object.</summary>
    CannotDelete = 0xc0000121,

    /// <summary>The specified computer name is invalid.</summary>
    InvalidComputerName = 0xc0000122,

    /// <summary>The file was deleted.</summary>
    FileDeleted = 0xc0000123,

    /// <summary>The specified account is a special account.</summary>
    SpecialAccount = 0xc0000124,

    /// <summary>The specified group is a special group.</summary>
    SpecialGroup = 0xc0000125,

    /// <summary>The specified user is a special user.</summary>
    SpecialUser = 0xc0000126,

    /// <summary>The members primary group is invalid.</summary>
    MembersPrimaryGroup = 0xc0000127,

    /// <summary>The file was closed.</summary>
    FileClosed = 0xc0000128,

    /// <summary>Too many threads were created.</summary>
    TooManyThreads = 0xc0000129,

    /// <summary>The thread is not in the process.</summary>
    ThreadNotInProcess = 0xc000012a,

    /// <summary>The token is already in use.</summary>
    TokenAlreadyInUse = 0xc000012b,

    /// <summary>The pagefile quota was exceeded.</summary>
    PagefileQuotaExceeded = 0xc000012c,

    /// <summary>The commitment limit was exceeded.</summary>
    CommitmentLimit = 0xc000012d,

    /// <summary>The specified image is in LE format.</summary>
    InvalidImageLeFormat = 0xc000012e,

    /// <summary>The specified image is not in MZ format.</summary>
    InvalidImageNotMz = 0xc000012f,

    /// <summary>The specified image is protected.</summary>
    InvalidImageProtect = 0xc0000130,

    /// <summary>The specified image is a Win16 image.</summary>
    InvalidImageWin16 = 0xc0000131,

    /// <summary>The logon server is unavailable.</summary>
    LogonServer = 0xc0000132,

    /// <summary>A difference was detected at the domain controller.</summary>
    DifferenceAtDc = 0xc0000133,

    /// <summary>Synchronization is required.</summary>
    SynchronizationRequired = 0xc0000134,

    /// <summary>The specified DLL was not found.</summary>
    DllNotFound = 0xc0000135,

    /// <summary>The I/O privilege operation failed.</summary>
    IoPrivilegeFailed = 0xc0000137,

    /// <summary>The specified ordinal was not found.</summary>
    OrdinalNotFound = 0xc0000138,

    /// <summary>The specified entry point was not found.</summary>
    EntryPointNotFound = 0xc0000139,

    /// <summary>The operation was exited via Control-C.</summary>
    ControlCExit = 0xc000013a,

    /// <summary>The specified address is invalid.</summary>
    InvalidAddress = 0xc0000141,

    /// <summary>The port is not set.</summary>
    PortNotSet = 0xc0000353,

    /// <summary>The debugger is inactive.</summary>
    DebuggerInactive = 0xc0000354,

    /// <summary>The callback was bypassed.</summary>
    CallbackBypass = 0xc0000503,

    /// <summary>The port is closed.</summary>
    PortClosed = 0xc0000700,

    /// <summary>The message was lost.</summary>
    MessageLost = 0xc0000701,

    /// <summary>The specified message is invalid.</summary>
    InvalidMessage = 0xc0000702,

    /// <summary>The request was canceled.</summary>
    RequestCanceled = 0xc0000703,

    /// <summary>Recursive dispatch is not allowed.</summary>
    RecursiveDispatch = 0xc0000704,

    /// <summary>An LPC receive buffer is expected.</summary>
    LpcReceiveBufferExpected = 0xc0000705,

    /// <summary>Invalid LPC connection usage.</summary>
    LpcInvalidConnectionUsage = 0xc0000706,

    /// <summary>LPC requests are not allowed.</summary>
    LpcRequestsNotAllowed = 0xc0000707,

    /// <summary>The resource is in use.</summary>
    ResourceInUse = 0xc0000708,

    /// <summary>The process is protected.</summary>
    ProcessIsProtected = 0xc0000712,

    /// <summary>The volume is dirty.</summary>
    VolumeDirty = 0xc0000806,

    /// <summary>The file is checked out.</summary>
    FileCheckedOut = 0xc0000901,

    /// <summary>Check out is required.</summary>
    CheckOutRequired = 0xc0000902,

    /// <summary>The specified file type is bad.</summary>
    BadFileType = 0xc0000903,

    /// <summary>The file is too large.</summary>
    FileTooLarge = 0xc0000904,

    /// <summary>Forms authentication is required.</summary>
    FormsAuthRequired = 0xc0000905,

    /// <summary>The file is virus infected.</summary>
    VirusInfected = 0xc0000906,

    /// <summary>The virus infected file was deleted.</summary>
    VirusDeleted = 0xc0000907,

    /// <summary>A transactional conflict occurred.</summary>
    TransactionalConflict = 0xc0190001,

    /// <summary>The specified transaction is invalid.</summary>
    InvalidTransaction = 0xc0190002,

    /// <summary>The transaction is not active.</summary>
    TransactionNotActive = 0xc0190003,

    /// <summary>The TM initialization failed.</summary>
    TmInitializationFailed = 0xc0190004,

    /// <summary>The RM is not active.</summary>
    RmNotActive = 0xc0190005,

    /// <summary>The RM metadata is corrupt.</summary>
    RmMetadataCorrupt = 0xc0190006,

    /// <summary>The transaction is not joined.</summary>
    TransactionNotJoined = 0xc0190007,

    /// <summary>The directory is not an RM.</summary>
    DirectoryNotRm = 0xc0190008,

    /// <summary>The log could not be resized.</summary>
    CouldNotResizeLog = 0xc0190009,

    /// <summary>Transactions are unsupported on the remote system.</summary>
    TransactionsUnsupportedRemote = 0xc019000a,

    /// <summary>The log resize size is invalid.</summary>
    LogResizeInvalidSize = 0xc019000b,

    /// <summary>The remote file version is mismatched.</summary>
    RemoteFileVersionMismatch = 0xc019000c,

    /// <summary>The CRM protocol already exists.</summary>
    CrmProtocolAlreadyExists = 0xc019000f,

    /// <summary>The transaction propagation failed.</summary>
    TransactionPropagationFailed = 0xc0190010,

    /// <summary>The CRM protocol was not found.</summary>
    CrmProtocolNotFound = 0xc0190011,

    /// <summary>A superior transaction exists.</summary>
    TransactionSuperiorExists = 0xc0190012,

    /// <summary>The transaction request is not valid.</summary>
    TransactionRequestNotValid = 0xc0190013,

    /// <summary>The transaction was not requested.</summary>
    TransactionNotRequested = 0xc0190014,

    /// <summary>The transaction was already aborted.</summary>
    TransactionAlreadyAborted = 0xc0190015,

    /// <summary>The transaction was already committed.</summary>
    TransactionAlreadyCommitted = 0xc0190016,

    /// <summary>The transaction marshal buffer is invalid.</summary>
    TransactionInvalidMarshallBuffer = 0xc0190017,

    /// <summary>The current transaction is not valid.</summary>
    CurrentTransactionNotValid = 0xc0190018,

    /// <summary>The log growth failed.</summary>
    LogGrowthFailed = 0xc0190019,

    /// <summary>The object no longer exists.</summary>
    ObjectNoLongerExists = 0xc0190021,

    /// <summary>The stream miniversion was not found.</summary>
    StreamMiniversionNotFound = 0xc0190022,

    /// <summary>The stream miniversion is not valid.</summary>
    StreamMiniversionNotValid = 0xc0190023,

    /// <summary>The miniversion is inaccessible from the specified transaction.</summary>
    MiniversionInaccessibleFromSpecifiedTransaction = 0xc0190024,

    /// <summary>Cannot open miniversion with modify intent.</summary>
    CantOpenMiniversionWithModifyIntent = 0xc0190025,

    /// <summary>Cannot create more stream miniversions.</summary>
    CantCreateMoreStreamMiniversions = 0xc0190026,

    /// <summary>The handle is no longer valid.</summary>
    HandleNoLongerValid = 0xc0190028,

    /// <summary>No TXF metadata is available.</summary>
    NoTxfMetadata = 0xc0190029,

    /// <summary>Log corruption was detected.</summary>
    LogCorruptionDetected = 0xc0190030,

    /// <summary>Cannot recover with handle open.</summary>
    CantRecoverWithHandleOpen = 0xc0190031,

    /// <summary>The RM is disconnected.</summary>
    RmDisconnected = 0xc0190032,

    /// <summary>The enlistment is not superior.</summary>
    EnlistmentNotSuperior = 0xc0190033,

    /// <summary>Recovery is not needed.</summary>
    RecoveryNotNeeded = 0xc0190034,

    /// <summary>The RM has already started.</summary>
    RmAlreadyStarted = 0xc0190035,

    /// <summary>The file identity is not persistent.</summary>
    FileIdentityNotPersistent = 0xc0190036,

    /// <summary>Cannot break transactional dependency.</summary>
    CantBreakTransactionalDependency = 0xc0190037,

    /// <summary>Cannot cross RM boundary.</summary>
    CantCrossRmBoundary = 0xc0190038,

    /// <summary>The TXF directory is not empty.</summary>
    TxfDirNotEmpty = 0xc0190039,

    /// <summary>In doubt transactions exist.</summary>
    IndoubtTransactionsExist = 0xc019003a,

    /// <summary>The TM is volatile.</summary>
    TmVolatile = 0xc019003b,

    /// <summary>The rollback timer expired.</summary>
    RollbackTimerExpired = 0xc019003c,

    /// <summary>The TXF attribute is corrupt.</summary>
    TxfAttributeCorrupt = 0xc019003d,

    /// <summary>EFS is not allowed in the transaction.</summary>
    EfsNotAllowedInTransaction = 0xc019003e,

    /// <summary>Transactional open is not allowed.</summary>
    TransactionalOpenNotAllowed = 0xc019003f,

    /// <summary>Transacted mapping is unsupported on the remote system.</summary>
    TransactedMappingUnsupportedRemote = 0xc0190040,

    /// <summary>TXF metadata is already present.</summary>
    TxfMetadataAlreadyPresent = 0xc0190041,

    /// <summary>Transaction scope callbacks are not set.</summary>
    TransactionScopeCallbacksNotSet = 0xc0190042,

    /// <summary>The transaction required promotion.</summary>
    TransactionRequiredPromotion = 0xc0190043,

    /// <summary>Cannot execute file in the transaction.</summary>
    CannotExecuteFileInTransaction = 0xc0190044,

    /// <summary>Transactions are not frozen.</summary>
    TransactionsNotFrozen = 0xc0190045
}
