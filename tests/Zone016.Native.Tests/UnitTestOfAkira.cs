// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Native.Tests;

[TestClass]
public class UnitTestOfAkira
{
    [TestMethod]
    public void TestProcessModulesEnumeration()
    {
        // var currentProcess = Process.GetCurrentProcess();
        // var handle = current.Process.Handle;
        // var akira = new Akira(handle);
        // var modules = akira.GetProcessModules();
        // Assert.IsNotNull(modules);
    }
    
    [TestMethod]
    public void TestOfVirtualMemoryWriteOfInt()
    {
        var currentProcess = Process.GetCurrentProcess();
        var handle = currentProcess.Handle;
        var akira = new Akira(handle);

        const int Pattern = int.MaxValue;
        var allocatedMemory = akira.AllocateVirtualMemory(sizeof(int));
        Assert.AreNotEqual(allocatedMemory, IntPtr.Zero);
        
        akira.WriteVirtualMemory(allocatedMemory, Pattern);
        var readValue = akira.ReadVirtualMemory<int>(allocatedMemory);
        Assert.AreEqual(readValue, Pattern);
    }
}
