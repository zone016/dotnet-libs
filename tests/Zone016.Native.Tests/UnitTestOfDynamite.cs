// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Native.Tests;

[TestClass]
public class UnitTestOfDynamite
{
    [TestMethod]
    public void TestGetLibraryAddressByName()
    {
        var validLibraryAddress = Generic.GetLibraryAddress(
            "kernel32.dll",
            "GetModuleHandleW"
        );

        Assert.AreNotEqual(validLibraryAddress, IntPtr.Zero);
    }

    [TestMethod]
    public void TestGetPebAddress()
    {
        var handle = Generic.GetPebAddress();
        Assert.AreNotEqual(handle, IntPtr.Zero);
    }

    [TestMethod]
    public void TestGetPebModuleEntry()
    {
        var handle = Generic.GetPebLdrModuleEntry("kernel32.dll");
        Assert.AreNotEqual(handle, IntPtr.Zero);
    }

    [TestMethod]
    public void TestGetNativeExportAddress()
    {
        var moduleHandle = Generic.GetLoadedModuleAddress("kernel32.dll");
        Assert.AreNotEqual(moduleHandle, IntPtr.Zero);

        var handleOpenProcess = Generic.GetNativeExportAddress(
            moduleHandle,
            "OpenProcess"
        );
        Assert.AreNotEqual(handleOpenProcess, IntPtr.Zero);
    }
}
