// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Boxer;

public sealed class Boxer
{
    private readonly Uri _baseUri = new("https://labs.hackthebox.com/api/v4/");

    private readonly HttpClient _httpClient;
    private readonly HttpClientHandler _httpClientHandler;

    private CancellationToken _cancellationToken = CancellationToken.None;
    private TimeSpan _delay = TimeSpan.FromMilliseconds(500);

    public static Boxer Create(string token) => new(token);

    public Boxer WithSuppressedCertificateValidation()
    {
        _httpClientHandler.ServerCertificateCustomValidationCallback = (_, _, _, _) => true;
        return this;
    }

    public Boxer WithCancellationToken(CancellationToken cancellationToken)
    {
        _cancellationToken = cancellationToken;
        return this;
    }

    public Boxer WithTimeout(TimeSpan timeout)
    {
        _httpClient.Timeout = timeout;
        return this;
    }

    public Boxer WithDelay(TimeSpan delay)
    {
        _delay = delay;
        return this;
    }

    public async Task<List<Challenge>> ListChallengesAsync(int? limit = default)
    {
        if (limit < 15)
        {
            throw new ArgumentOutOfRangeException(nameof(limit), "Limit must be greater than 14.");
        }

        var response = await _httpClient.GetAsync("challenges", _cancellationToken);
        response.EnsureSuccessStatusCode();

        var paginatedResponse = await response.Content
            .ReadFromJsonAsync<ListChallengeResponse>(cancellationToken: _cancellationToken);
        if (paginatedResponse is null)
        {
            return [];
        }

        var challenges = new List<Challenge>();
        challenges.AddRange(paginatedResponse.Challenges);

        var currentPage = 1;
        for (var i = 0; i < paginatedResponse.Metadata.LastPage; i++)
        {
            if (currentPage >= paginatedResponse.Metadata.LastPage)
            {
                continue;
            }

            await Task.Delay(_delay, _cancellationToken);
            response = await _httpClient.GetAsync($"challenges?page={++currentPage}", _cancellationToken);
            response.EnsureSuccessStatusCode();

            paginatedResponse = await response.Content
                .ReadFromJsonAsync<ListChallengeResponse>(cancellationToken: _cancellationToken);

            if (paginatedResponse is null || challenges.Count >= limit)
            {
                break;
            }

            challenges.AddRange(paginatedResponse.Challenges);
        }

        return challenges;
    }

    private Boxer(string token)
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
                UserAgent = { new ProductInfoHeaderValue(nameof(Boxer), version.ToString(3)) },
                Authorization = new AuthenticationHeaderValue("Bearer", token)
            }
        };
    }
}
