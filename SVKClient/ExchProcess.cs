using Microsoft.Extensions.Options;

namespace SVKClient;

public class ExchProcess : IExchProcess
{
    private readonly AppSettings _config;
    private readonly ILogger _logger;

    public TimeSpan Timer { get; set; }

    public ExchProcess(IOptions<AppSettings> config, ILogger<ExchProcess> logger)
    {
        _config = config.Value;
        _logger = logger;
    }

    public async Task ConnectAsync()
    {
        _logger.LogInformation("Connect to {name}", _config.Channel.ConnectionName);
        await Task.Delay(_config.Channel.Timeout);
    }

    public async Task TelnetAuthenticateAsync()
    {
        _logger.LogInformation("Telnet Authenticate");
        await Task.Delay(_config.Channel.Timeout);
    }

    public async Task UploadAsync(string filename, string dept)
    {
        _logger.LogInformation("Upload {filename}", filename);
        await Task.Delay(_config.Channel.Timeout);
    }

    public async Task DownloadAsync(string filename)
    {
        _logger.LogInformation("Download {filename}", filename);
        await Task.Delay(_config.Channel.Timeout);
    }

    public async Task DisconnectAsync()
    {
        _logger.LogInformation("Disconnect");
        await Task.Delay(_config.Channel.Timeout);
    }
}
