// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Octopus.Tests;

[TestClass]
public class UnitTestOfOctopus
{
    [TestMethod]
    public void TestInstanceCreation()
    {
        using var octopus = Octopus.Instance;
        Assert.IsNotNull(octopus);
    }

    [TestMethod]
    public void TestRegistration()
    {
        using var octopus = Octopus.Instance;
        using var registration = octopus.Register(Modifiers.Alt, VirtualKeyCode.KeyZ);

        Assert.IsNotNull(registration);
        Assert.IsTrue(registration.IsSuccessful);
    }
}
