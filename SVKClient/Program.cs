using SVKClient;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services
            .Configure<AppSettings>(context.Configuration.GetSection(nameof(AppSettings)))
            .AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
