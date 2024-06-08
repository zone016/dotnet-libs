// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Native.Structs;

[StructLayout(LayoutKind.Sequential)]
public struct MemoryBasicInformation(
    IntPtr baseAddress,
    IntPtr allocationBase,
    uint allocationProtect,
    ushort partitionId,
    IntPtr regionSize,
    uint state,
    MemoryProtection protect,
    uint type)
{
    public readonly IntPtr BaseAddress = baseAddress;
    public readonly IntPtr AllocationBase = allocationBase;
    public readonly uint AllocationProtect = allocationProtect;
    public readonly ushort PartitionId = partitionId;
    public readonly IntPtr RegionSize = regionSize;
    public readonly uint State = state;
    public readonly MemoryProtection Protect = protect;
    public readonly uint Type = type;
}
