// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Nexus.Tests;

[TestClass]
public class UnitTestOfNexusClient
{
    [TestMethod]
    public void TestFluentBuilder()
    {
        var client = NexusClient.Create("http://localhost:8081");

        Assert.IsNotNull(client);
        Assert.IsInstanceOfType(client, typeof(NexusClient));
    }
}
