using SVKClient;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services
            .Configure<AppSettings>(context.Configuration)
            .AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
