using Newtonsoft.Json;

namespace api_authentication_boberto.Integrations.DiscordApiClient
{
    public class DiscordWebHookRequest
    {
        [JsonProperty("content")]
        public string Content { get; set; }
    }
}
