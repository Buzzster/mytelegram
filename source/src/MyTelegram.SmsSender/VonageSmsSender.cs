using Microsoft.Extensions.Options;
using Vonage;
using Vonage.Messaging;
using Vonage.Request;

namespace MyTelegram.SmsSender;

public class VonageSmsSender : ISmsSender
{
    private readonly IOptionsSnapshot<VonageSmsOptions> _optionsSnapshot;
    private readonly ILogger<VonageSmsSender> _logger;
    public VonageSmsSender(IOptionsSnapshot<VonageSmsOptions> optionsSnapshot, ILogger<VonageSmsSender> logger)
    {
        _optionsSnapshot = optionsSnapshot;
        _logger = logger;
    }

    public bool Enabled => _optionsSnapshot.Value.Enabled;

    public async Task SendAsync(SmsMessage smsMessage)
    {
        if (!_optionsSnapshot.Value.Enabled)
        {
            _logger.LogWarning("Vonage sms sender disabled,the code will not be sent.PhoneNumber:{To} Text:{Text}", smsMessage.PhoneNumber, smsMessage.Text);

            return;
        }

        // E.164 format
        var phoneNumber = smsMessage.PhoneNumber;
        if (!phoneNumber.StartsWith("+"))
        {
            phoneNumber = phoneNumber[1..];
        }

        var credentials =
        Credentials.FromApiKeyAndSecret(_optionsSnapshot.Value.ApiKey, _optionsSnapshot.Value.ApiSecret);
        var client = new VonageClient(credentials);
        var response = await client.SmsClient.SendAnSmsAsync(new SendSmsRequest
        {
            To = phoneNumber,
            From = _optionsSnapshot.Value.BrandName,
            Text = smsMessage.Text,
        });

        _logger.LogDebug("Send SMS result:{@Response}", response);

        var message = response.Messages.ElementAtOrDefault(0);
        _logger.LogInformation("Send SMS completed,To={To},StatusCode={StatusCode},Status={Status},MessageId={MessageId},ErrorText={ErrorText}", message?.To, message?.Status, message?.StatusCode, message?.MessageId, message?.ErrorText);
    }
}