using System.Collections;
using System.Collections.Generic;

namespace api_boberto_services.Application.Message
{
    public class DiscordApiConfig
    {
        public bool Enabled { get; set; }
        public IEnumerable<DiscordWebHook> WebHooks { get; set; }
    }

    public class DiscordWebHook
    {
        public string Channel { get; set; }
        public string Url { get; set; }
    }
}
