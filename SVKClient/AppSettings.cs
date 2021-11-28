namespace SVKClient;

public class AppSettings
{
    public string BIC { get; set; }
    public string Home { get; set; }
    public string Backup { get; set; }
    public int SegmentSize { get; set; }
    public Channel Channel { get; set; }
    public TelnetAuth TelnetAuth { get; set; }
    public SVKServer SVKServer { get; set; }
    public UploadWorker UploadWorker { get; set; }
    public DownloadWorker DownloadWorker { get; set; }
}

public class Channel
{
    public string ConnectionName { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public TimeSpan Timeout { get; set; }
}

public class TelnetAuth
{
    public string Host { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
}

public class SVKServer
{
    public string Host { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
}

public class UploadWorker
{
    public string Out { get; set; }
    public string Expl { get; set; }
    public string Lic { get; set; }
    public string Otzi { get; set; }
    public string Sopr { get; set; }
    public string Ubn { get; set; }
    public string Upsir { get; set; }
    public string AddrTo { get; set; }
    public TimeSpan Timeout { get; set; }
}

public class DownloadWorker
{
    public string In { get; set; }
    public string Rep { get; set; }
    public TimeSpan Timeout { get; set; }
    public TimeSpan Confirm { get; set; }
}
