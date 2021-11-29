namespace SVKClient;

public class AppSettings
{
    public Channel Channel { get; set; }
    public TelnetAuth TelnetAuth { get; set; }
    public SVKServer SVKServer { get; set; }
    public string Home { get; set; }
    public Upload Upload { get; set; }
    public Download Download { get; set; }
    public int SegmentSize { get; set; }
}

public class Channel
{
    public string ConnectionName { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public TimeSpan Timeout { get; set; }
    public bool Enabled { get; set; }
}

public class TelnetAuth
{
    public string Host { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public bool Enabled { get; set; }
}

public class SVKServer
{
    public string Host { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
}

public class Upload
{
    public string[] Departments { get; set; }
    public TimeSpan Timeout { get; set; }
    public TimeSpan Confirm { get; set; }
}

public class Download
{
    public TimeSpan Timeout { get; set; }
}
