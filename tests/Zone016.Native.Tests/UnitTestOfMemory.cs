namespace Zone016.Native.Tests;

[TestClass]
public class UnitTestOfMemory
{
   private readonly Memory _memory;
    private readonly Process _currentProcess;

    public UnitTestOfMemory()
    {
        _currentProcess = Process.GetCurrentProcess();
        _memory = new Memory(_currentProcess.Id);
    }

    [TestMethod]
    public void TestVirtualMemoryManipulation()
    {
        var processModule = _currentProcess.MainModule;
        Assert.IsTrue(processModule != null);

        var baseAddress = processModule.BaseAddress;
        Assert.AreNotEqual(baseAddress, IntPtr.Zero);

        var allocAddress = _memory.AllocateVirtualMemory(sizeof(int), MemoryProtection.ReadWrite);
        Assert.AreNotEqual(allocAddress, IntPtr.Zero);

        const int Number = int.MaxValue;
        _memory.WriteVirtualMemory(allocAddress, Number);

        var readNumber = _memory.ReadVirtualMemory<int>(allocAddress);
        Assert.AreEqual(readNumber, Number);

        var memoryProtection =
            _memory.ChangeVirtualMemoryProtection(allocAddress, sizeof(int), MemoryProtection.ReadOnly);
        Assert.AreEqual(memoryProtection, MemoryProtection.ReadWrite);

        var regionSize = IntPtr.Add(allocAddress, sizeof(int));
        var allocMemoryInformation = 
            _memory.GetMemoryRegions(allocAddress, regionSize).ToArray();
        Assert.IsTrue(allocMemoryInformation.Length == 1);

        _memory.FreeAllocatedVirtualMemory(allocAddress);

        var memoryInformation = _memory.GetMemoryRegion();
        Assert.IsTrue(memoryInformation.BaseAddress != IntPtr.Zero);
    }

    [TestMethod]
    public void TestBinaryPatternSearch()
    {
        var processModule = _currentProcess.MainModule;
        Assert.IsTrue(processModule != null);

        var baseAddress = processModule.BaseAddress;
        Assert.AreNotEqual(baseAddress, IntPtr.Zero);

        var something = new byte[] {0x83, 0xC5, 0x40, 0xF3, 0x0F, 0x10, 0xCA, 0x83, 0xED, 0x40};
        
        var pattern = new byte[]   {0x83, 0xC5, 0x00, 0x00, 0x00, 0x10, 0xCA, 0x00, 0xED, 0x40};
        const string Pattern2 = "83 C5 ?? ?? ?? 10 CA ?? ED 40";
        const string Pattern3 = "83c5??????10ca??ed40";
        const string Pattern4 = "83c5xxxxxx10caxxed40";
        
        var allocAddress = _memory.AllocateVirtualMemory(something.Length);
        _memory.WriteVirtualMemory(allocAddress, something);

        var lastAddress = IntPtr.Add(allocAddress, something.Length);
        var matches = _memory.BinaryPatternSearch(pattern, allocAddress, lastAddress).ToArray();
        
        Assert.IsTrue(matches.Length == 1);
        Assert.AreEqual(matches.First(), allocAddress);
        
        matches = _memory.BinaryPatternSearch(Pattern2, allocAddress, lastAddress).ToArray();
        Assert.IsTrue(matches.Length == 1);
        Assert.AreEqual(matches.First(), allocAddress);
        
        matches = _memory.BinaryPatternSearch(Pattern3, allocAddress, lastAddress).ToArray();
        Assert.IsTrue(matches.Length == 1);
        Assert.AreEqual(matches.First(), allocAddress);
        
        matches = _memory.BinaryPatternSearch(Pattern4, allocAddress, lastAddress).ToArray();
        Assert.IsTrue(matches.Length == 1);
        Assert.AreEqual(matches.First(), allocAddress);

        _memory.FreeAllocatedVirtualMemory(allocAddress);
    }
}
