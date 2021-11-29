using SVKClient;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services
            .Configure<AppSettings>(context.Configuration)
            .AddSingleton<IExchProcess, ExchProcess>()
            .AddHostedService<UploadWorker>()
            .AddHostedService<DownloadWorker>();
    })
    .Build();

await host.RunAsync();
