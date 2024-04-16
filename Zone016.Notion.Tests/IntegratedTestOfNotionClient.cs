// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Notion.Tests;

[TestClass]
public class IntegratedTestOfNotionClient
{
    private const string DatabaseId = "7517d98dcf3d437da177fd51af6da213";
    private readonly NotionClient _notionClient;

    public IntegratedTestOfNotionClient()
    {
        var token = Environment.GetEnvironmentVariable("NOTION_SECRET");
        if (string.IsNullOrWhiteSpace(token))
        {
            Assert.Inconclusive("NOTION_SECRET environment variable is not set.");
        }

        _notionClient = NotionClient.Create(token);
    }

    [TestMethod]
    public async Task TestGetDatabaseAsync()
    {
        var database = await _notionClient.GetDatabaseAsync(DatabaseId);

        Assert.IsNotNull(database);
        Assert.AreEqual(database.Id, DatabaseId);
    }

    [TestMethod]
    public async Task TestQueryDatabaseAsync()
    {
        var result = await _notionClient.QueryDatabaseAsync(DatabaseId);

        Assert.IsNotNull(result);
    }
}
