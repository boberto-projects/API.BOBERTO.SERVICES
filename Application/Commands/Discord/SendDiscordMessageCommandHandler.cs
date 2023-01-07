using api_boberto_services.Application.Message;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace api_boberto_services.Application.Commands
{
    public class SendDiscordMessageCommandHandler : ICommandHandler<SendDiscordMessageCommand>
    {
        private IOptions<DiscordApiConfig> _discordApiConfig { get; set; }
        private IHttpClientFactory _httpClient { get; set; }
        public override async void Handle(SendDiscordMessageCommand command)
        {
            var discordApiConfig = _discordApiConfig.Value;
            var httpClient = _httpClient.CreateClient();

            var channels = discordApiConfig.WebHooks.Where(x => command.Channels.Contains(x.Channel));

            foreach (var item in channels)
            {
                var values = new Dictionary<string, string>
                  {
                      { "content", command.Content },
                  };
                var content = new FormUrlEncodedContent(values);
                await httpClient.PostAsync(item.Url, content);
            }
        }
    }
}
