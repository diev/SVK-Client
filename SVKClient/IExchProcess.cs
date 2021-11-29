namespace SVKClient;

public interface IExchProcess
{
    Task ConnectAsync();
    Task TelnetAuthenticateAsync();
    Task UploadAsync(string filename, string dept);
    Task DownloadAsync(string filename);
    Task DisconnectAsync();
}
