namespace Zone016.Native.Shared.Enums;

[Flags]
public enum FileShareFlags : uint
{
    FileShareNone = 0x0,
    FileShareRead = 0x1,
    FileShareWrite = 0x2,
    FileShareDelete = 0x4
}