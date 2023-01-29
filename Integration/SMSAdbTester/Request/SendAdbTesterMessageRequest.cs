using Newtonsoft.Json;

namespace API.BOBERTO.SERVICES.INTEGRATION.SMSAdbTester.Request
{
    public class SendAdbTesterMessageRequest
    {
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
