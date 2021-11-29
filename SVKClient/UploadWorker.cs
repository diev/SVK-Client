using Microsoft.Extensions.Options;

namespace SVKClient
{
    public class UploadWorker : BackgroundService
    {
        private readonly AppSettings _config;
        private readonly ILogger<UploadWorker> _logger;
        private readonly IExchProcess _exchProcess;

        public UploadWorker(IOptions<AppSettings> config, ILogger<UploadWorker> logger, IExchProcess exchProcess)
        {
            _config = config.Value;
            _logger = logger;
            _exchProcess = exchProcess;

            string path = Path.Combine(_config.Home, "out");
            foreach (var dept in _config.Upload.Departments)
            {
                Directory.CreateDirectory(Path.Combine(path, dept));
            }
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            string path = Path.Combine(_config.Home, "out");

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("UploadWorker running at {time:u}", DateTime.Now);

                foreach (var dept in _config.Upload.Departments)
                {
                    foreach (var fi in new DirectoryInfo(Path.Combine(path, dept)).EnumerateFiles())
                    {
                        await _exchProcess.UploadAsync(fi.FullName, dept);
                        await MoveToBackupAsync(fi, dept);
                        //TODO _config.Download.Timeout = _config.Upload.Confirm; 
                    }
                }

                await Task.Delay(_config.Upload.Timeout, stoppingToken);
            }
        }

        async Task MoveToBackupAsync(FileInfo fi, string direction)
        {
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
