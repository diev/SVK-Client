using Microsoft.Extensions.Options;

namespace SVKClient
{
    public class DownloadWorker : BackgroundService
    {
        private readonly AppSettings _config;
        private readonly ILogger<UploadWorker> _logger;
        private readonly IExchProcess _exchProcess;

        public DownloadWorker(IOptions<AppSettings> config, ILogger<UploadWorker> logger, IExchProcess exchProcess)
        {
            _config = config.Value;
            _logger = logger;
            _exchProcess = exchProcess;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            string home = _config.Home;

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("DownloadWorker running at {time:u}", DateTime.Now);

                if (_config.Channel.Enabled)
                {
                    await _exchProcess.ConnectAsync();
                }

                if (_config.TelnetAuth.Enabled)
                {
                    await _exchProcess.TelnetAuthenticateAsync();
                }

                await _exchProcess.DownloadAsync("list.xml");
                if (true) //TODO
                {
                    var direction = "in";
                    Directory.CreateDirectory(Path.Combine(home, direction));
                    foreach (var filename in new string[] { }) //TODO
                    {
                        await _exchProcess.DownloadAsync(filename);
                        await MoveToBackupAsync(filename, direction);
                    }
                    direction = "rep";
                    Directory.CreateDirectory(Path.Combine(home, direction));
                    foreach (var filename in new string[] { }) //TODO
                    {
                        await _exchProcess.DownloadAsync(filename);
                        await MoveToBackupAsync(filename, direction);
                    }
                }

                if (_config.Channel.Enabled)
                {
                    await _exchProcess.DisconnectAsync();
                }

                await Task.Delay(_config.Download.Timeout, stoppingToken);
            }
        }

        async Task MoveToBackupAsync(string filename, string direction)
        {
            var fi = new FileInfo(filename);
            string backupDir = Path.Combine(_config.Home, "backup", direction, DateTime.Now.ToString("yyyyMMdd"));
            Directory.CreateDirectory(backupDir);
            string backupFile = Path.Combine(backupDir, fi.Name);
            if (File.Exists(backupFile))
            {
                await Task.Delay(1000);
                backupFile = Path.ChangeExtension(backupFile, DateTime.Now.ToString("HHmmss") + fi.Extension);
            }
            fi.MoveTo(backupFile);
        }
    }
}
