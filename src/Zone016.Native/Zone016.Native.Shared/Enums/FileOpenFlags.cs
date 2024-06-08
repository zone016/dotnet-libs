namespace Zone016.Native.Shared.Enums;

[Flags]
public enum FileOpenFlags : uint
{
    FileDirectoryFile = 0x1,
    FileWriteThrough = 0x2,
    FileSequentialOnly = 0x4,
    FileNoIntermediateBuffering = 0x8,
    FileSynchronousIoAlert = 0x10,
    FileSynchronousIoNonAlert = 0x20,
    FileNonDirectoryFile = 0x40,
    FileCreateTreeConnection = 0x80,
    FileCompleteIfOpLocked = 0x100,
    FileNoEaKnowledge = 0x200,
    FileOpenForRecovery = 0x400,
    FileRandomAccess = 0x800,
    FileDeleteOnClose = 0x1000,
    FileOpenByFileId = 0x2000,
    FileOpenForBackupIntent = 0x4000,
    FileNoCompression = 0x8000
}