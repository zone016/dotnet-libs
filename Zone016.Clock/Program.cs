const string NotionSecretKey = "NOTION_SECRET";
const string NotionDatabaseIdKey = "NOTION_DATABASE_ID";

const string HackTheBoxTokenKey = "HTB_TOKEN";

var hackTheBoxToken = Environment.GetEnvironmentVariable(HackTheBoxTokenKey);
var notionSecret = Environment.GetEnvironmentVariable(NotionSecretKey);
var notionDatabaseId = Environment.GetEnvironmentVariable(NotionDatabaseIdKey);

var workingDirectory = Path.Combine(
    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
    ".clock");

var challengesFile = Path.Combine(workingDirectory, "challenges.json");

if (string.IsNullOrWhiteSpace(hackTheBoxToken))
{
    PrintError($"{hackTheBoxToken} environment variable is not set.");  
    Environment.Exit(1);
}

if (string.IsNullOrWhiteSpace(notionSecret))
{
    PrintError($"{NotionSecretKey} environment variable is not set.");  
    Environment.Exit(1);
}

if (string.IsNullOrWhiteSpace(notionDatabaseId))
{
    PrintError($"{NotionDatabaseIdKey} environment variable is not set.");  
    Environment.Exit(1);
}

if (!Directory.Exists(workingDirectory)) Directory.CreateDirectory(workingDirectory);

PrintInformational($"Working directory is {workingDirectory}.");
PrintInformational("Fetching challenges from HTB...");

var challenges = new List<Challenge>();
if (File.Exists(challengesFile))
{
    var currentTime = DateTime.Now;
    var writeTime = File.GetCreationTime(challengesFile);
    if (currentTime - writeTime > TimeSpan.FromDays(1))
    {
        PrintWarning("Challenges file cache is outdated. Refreshing...");
        File.Delete(challengesFile);
        return;
    }

    var json = await File.ReadAllTextAsync(challengesFile);
    challenges = JsonSerializer.Deserialize<List<Challenge>>(json)!;
    PrintInformational($"Loaded #{challenges.Count} challenges from cache.");
}

var boxerClient = Boxer
    .Create(hackTheBoxToken)
    .WithDelay(TimeSpan.FromSeconds(5));

if (challenges.Count == 0)
{
    challenges = await boxerClient.ListChallengesAsync();
    var json = JsonSerializer.Serialize(challenges);
    await File.WriteAllTextAsync(challengesFile, json);
}

PrintSuccess("Challenges loaded successfully.");
PrintInformational($"Fetching database {notionDatabaseId} from Notion...");

var notionClient = NotionClient.Create(notionSecret);
var database = await notionClient.GetDatabaseAsync(notionDatabaseId);
PrintSuccess($"Object {database.Object} (#{database.Id}) fetched successfully!");
