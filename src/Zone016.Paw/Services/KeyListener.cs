// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Paw.Services;

internal class KeyListener(ILogger<KeyListener> logger, IHotKeyManager hotKeyManager)
    : BackgroundService
{
    private readonly Settings _settings = Settings.Load();

protected override async Task ExecuteAsync(CancellationToken stoppingToken)
{
    while (!stoppingToken.IsCancellationRequested)
    {
        if (logger.IsEnabled(LogLevel.Information))
        {
            logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

            var literal = JsonSerializer.Serialize(_settings, new SettingsContext().Settings);
            logger.LogInformation("Current settings: {literal}", literal);
        }

        await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
    }
}
}
