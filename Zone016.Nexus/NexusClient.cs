// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Nexus;

public class NexusClient : IDisposable
{
    private readonly HttpClient _httpClient;
    private readonly HttpClientHandler _clientHandler = new();
    private CancellationToken _cancellationToken;

    private NexusClient(string host, CancellationToken cancellationToken = default)
    {
        _cancellationToken = cancellationToken;
        if (host.EndsWith('/')) host = host[..^1];

        var uri = new Uri($"{host}/service/rest/v1/");
        var version = Assembly.GetExecutingAssembly().GetName().Version!;
        _httpClient = new HttpClient(_clientHandler)
        {
            BaseAddress = uri,
            DefaultRequestHeaders =
            {
                Accept = { new MediaTypeWithQualityHeaderValue("application/json") },
                UserAgent = { new ProductInfoHeaderValue(nameof(NexusClient), version.ToString(3)) }
            }
        };
    }

    public static NexusClient Create(string host, CancellationToken cancellationToken = default) =>
        new NexusClient(host, cancellationToken);

    public NexusClient WithAuthentication(string scheme, string parameter)
    {
        var authenticationHeader = new AuthenticationHeaderValue(scheme, parameter);
        _httpClient.DefaultRequestHeaders.Authorization = authenticationHeader;
        
        return this;
    }

    public NexusClient WithCancellationToken(CancellationToken cancellationToken)
    {
        _cancellationToken = cancellationToken;
        return this;
    }

    public NexusClient WithTimeout(TimeSpan timeout)
    {
        _httpClient.Timeout = timeout;
        return this;
    }

    public NexusClient IgnoreCertificate()
    {
        _clientHandler.ServerCertificateCustomValidationCallback = (_, _, _, _) => true;
        return this;
    }

    public async Task<List<Repository>> ListRepositoriesAsync() =>
        await GetAsync<List<Repository>>("repositories") ?? [];

    private async Task<T?> GetAsync<T>(string path)
    {
        var response = await _httpClient.GetAsync(path, _cancellationToken);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<T>(_cancellationToken);
    }

    public void Dispose()
    {
        _httpClient.Dispose();
    }
}
