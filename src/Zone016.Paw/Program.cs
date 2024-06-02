var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddSingleton<IHotKeyManager, HotKeyManager>();
builder.Services.AddHostedService<KeyListener>();
builder.Services.AddWindowsService();

var host = builder.Build();
host.Run();
