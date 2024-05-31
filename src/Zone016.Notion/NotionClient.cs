// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Notion;

public class NotionClient
{
    private readonly Uri _baseUri = new("https://api.notion.com/v1/");

    private readonly HttpClient _httpClient;
    private readonly HttpClientHandler _httpClientHandler;

    private CancellationToken _cancellationToken = CancellationToken.None;

    public static NotionClient Create(string token) => new(token);

    public NotionClient WithSuppressedCertificateValidation()
    {
        _httpClientHandler.ServerCertificateCustomValidationCallback = (_, _, _, _) => true;
        return this;
    }

    public NotionClient WithCancellationToken(CancellationToken cancellationToken)
    {
        _cancellationToken = cancellationToken;
        return this;
    }

    public NotionClient WithTimeout(TimeSpan timeout)
    {
        _httpClient.Timeout = timeout;
        return this;
    }

    public async Task<NotionEntity> GetDatabaseAsync(string databaseId)
    {
        var response = await _httpClient.GetAsync($"databases/{databaseId}", _cancellationToken);
        response.EnsureSuccessStatusCode();

        var database = await response.Content.ReadFromJsonAsync<NotionEntity>(_cancellationToken);
        return database!;
    }

    public async Task<NotionQueryResult> QueryDatabaseAsync(string databaseId)
    {
        var response = await _httpClient.PostAsync(
            $"databases/{databaseId}/query",
            new StringContent("{}"),
            _cancellationToken);

        response.EnsureSuccessStatusCode();

        var result = await response.Content.ReadFromJsonAsync<NotionQueryResult>(_cancellationToken);
        return result!;
    }

    private NotionClient(string token)
    {

        _httpClientHandler = new HttpClientHandler
        {
            AllowAutoRedirect = false,
            UseCookies = false
        };

        var version = Assembly.GetExecutingAssembly().GetName().Version!;
        _httpClient = new HttpClient(_httpClientHandler)
        {
            BaseAddress = _baseUri,
            DefaultRequestHeaders =
            {
                Accept = { new MediaTypeWithQualityHeaderValue("application/json") },
                UserAgent = { new ProductInfoHeaderValue(nameof(NotionClient), version.ToString(3)) },
                Authorization = new AuthenticationHeaderValue("Bearer", token)
            }
        };

        _httpClient.DefaultRequestHeaders.Add("Notion-Version", "2022-06-28");
    }
}
