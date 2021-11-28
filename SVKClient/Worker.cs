using Microsoft.Extensions.Options;

namespace SVKClient
{
    public class Worker : BackgroundService
    {
        private readonly AppSettings _config;
        private readonly ILogger<Worker> _logger;

        public Worker(IOptions<AppSettings> config, ILogger<Worker> logger)
        {
            _config = config.Value;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var value = _config.UploadWorker.AddrTo; // TEST of Options
            _logger.LogInformation("Worker running with AddrTo: {value}", value);

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time:u}", DateTime.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
