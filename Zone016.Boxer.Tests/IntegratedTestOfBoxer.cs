// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Boxer.Tests;

[TestClass]
public class IntegratedTestOfBoxer
{
    private readonly Boxer _boxer;

    public IntegratedTestOfBoxer()
    {
        var token = Environment.GetEnvironmentVariable("HTB_TOKEN");
        if (string.IsNullOrWhiteSpace(token))
        {
            Assert.Inconclusive("HTB_TOKEN environment variable is not set.");
        }

        _boxer = Boxer.Create(token);
    }

    [TestMethod]
    public async Task TestMethodListChallengesAsync()
    {
        var challenges = await _boxer.ListChallengesAsync(40);

        Assert.IsNotNull(challenges);
        Assert.IsTrue(challenges.Count >= 40);

        var challenge = challenges.First();
        Assert.IsNotNull(challenge);
        Assert.IsNotNull(challenge.Id);
        Assert.IsNotNull(challenge.Name);
    }
}
