// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Nexus.Tests;

[TestClass]
public class IntegratedUnitTestOfNexusClient
{
    private NexusClient _client;
    
    public IntegratedUnitTestOfNexusClient()
    {
        var host = Environment.GetEnvironmentVariable("NEXUS_HOST");
        if (string.IsNullOrEmpty(host)) Assert.Inconclusive("NEXUS_HOST environment variable is not set.");
        
        _client = NexusClient.Create(host);
    }
    
    [TestMethod]
    public async Task TestListRepositoriesAsync()
    {
        var repositories = await _client.ListRepositoriesAsync();
        
        Assert.IsNotNull(repositories);
        Assert.IsTrue(repositories.Count > 0);
    }
}
