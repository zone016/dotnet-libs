// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

using Zone016.Native.Shared.Enums;

namespace Zone016.Octopus.Tests;

[TestClass]
public class UnitTestOfHotKeyManager
{
    [TestMethod]
    public void TestInstanceCreation()
    {
        using var manager = new HotKeyManager();
        Assert.IsNotNull(manager);
    }

    [TestMethod]
    public void TestRegistration()
    {
        using var manager = new HotKeyManager();
        using var registration = manager.Register(Modifiers.Alt, VirtualKeyCode.KeyZ);

        Assert.IsNotNull(registration);
        Assert.IsTrue(registration.IsSuccessful);
    }
}
