using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace MyTelegram.SmsSender
{
    public class PrivateSmsSender : ISmsSender
    {
        private readonly IOptionsSnapshot<PrivateSmsOptions> _optionsSnapshot;
        private readonly ILogger<PrivateSmsSender> _logger;
        private readonly HttpClient _httpClient;

        public PrivateSmsSender(IOptionsSnapshot<PrivateSmsOptions> optionsSnapshot, ILogger<PrivateSmsSender> logger, HttpClient httpClient)
        {
            _optionsSnapshot = optionsSnapshot;
            _logger = logger;
            _httpClient = httpClient;
        }

        public bool Enabled => _optionsSnapshot.Value.Enabled;

        public async Task SendAsync(SmsMessage smsMessage)
        {
            var phoneNumber = smsMessage.PhoneNumber;
            if (phoneNumber.StartsWith("+"))
            {
                phoneNumber = phoneNumber.Replace("+", "");
            }
            
            if (!phoneNumber.StartsWith("888") || !phoneNumber.StartsWith("+888"))
            {
                return;
            }
            else {
                var authKey = _optionsSnapshot.Value.AuthKey
                var content = new StringContent(JsonSerializer.Serialize(new
                {
                    number = phoneNumber,
                    message = smsMessage.Text
                }), Encoding.UTF8, "application/json");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authKey);

                using var response = await _httpClient.PostAsync(_optionsSnapshot.Value.Uri+"/api/send", content);
                var responseContent = await response.Content.ReadAsStringAsync();

                _logger.LogDebug("Send SMS result:{@Response}", responseContent);
            }
        }
    }
}
