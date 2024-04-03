// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Nexus.Tests;

[TestClass]
public class IntegratedUnitTestOfNexusClient
{
    private readonly NexusClient _client;

    public IntegratedUnitTestOfNexusClient()
    {
        var host = Environment.GetEnvironmentVariable("NEXUS_HOST");
        if (string.IsNullOrEmpty(host))
        {
            Assert.Inconclusive("NEXUS_HOST environment variable is not set.");
        }

        _client = NexusClient.Create(host);
    }

    [TestMethod]
    public async Task TestListRepositoriesAsync()
    {
        var repositories = await _client.ListRepositoriesAsync();

        Assert.IsNotNull(repositories);
        Assert.IsTrue(repositories.Count > 0);
    }

    [TestMethod]
    public async Task TestGetRepositoryAsync()
    {
        var repositories = await _client.ListRepositoriesAsync();
        var repository = repositories.FirstOrDefault();
        Assert.IsNotNull(repository);

        var repositoryName = repository.Name;
        repository = await _client.GetRepositoryAsync(repositoryName);

        Assert.IsNotNull(repository);
        Assert.AreEqual(repositoryName, repository.Name);
    }
    
    [TestMethod]
    public async Task TesGetRepositoryAssetsAsync()
    {
        var repositories = await _client.ListRepositoriesAsync();
        var repository = repositories.FirstOrDefault(repository => repository.Name == "nuget.org-proxy");
        if (repository is null) Assert.Inconclusive("This test requires a repository named nuget.org-proxy.");

        var assets = await _client.GetRepositoryAssetsAsync(repository.Name);
        Assert.IsNotNull(assets);
        Assert.IsTrue(assets.Count >= 0);
    }
}
