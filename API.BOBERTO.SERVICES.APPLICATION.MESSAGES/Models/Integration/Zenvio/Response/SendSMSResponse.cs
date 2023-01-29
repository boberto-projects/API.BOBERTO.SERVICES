
using Newtonsoft.Json;

namespace API.BOBERTO.SERVICES.APPLICATION.MESSAGES.Models.Integration.Zenvio.Response
{
    public class SendSMSResponse
    {
        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("to")]
        public string To { get; set; }

        [JsonProperty("contents")]
        public IEnumerable<Content> Contents { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("direction")]
        public string Direction { get; set; }
    }
    public class Content
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }
}
