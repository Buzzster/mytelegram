namespace MyTelegram.SmsSender;

public class PrivateSmsOptions
{
    public bool Enabled { get; set; }
    public string Uri { get; set; } = null!;
    public string AuthKey { get; set; } = null!;
}