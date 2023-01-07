using api_boberto_services.Application.Message;
using Microsoft.Extensions.Options;
using System;
using System.Linq;

namespace api_boberto_services.Application.Commands
{
    public class SendDiscordMessageCommandHandler : ICommandHandler<SendDiscordMessageCommand>
    {
        private IOptions<DiscordApiConfig> _discordApiConfig { get; set; }
        public override void Handle(SendDiscordMessageCommand command)
        {
            var discordApiConfig = _discordApiConfig.Value;
            var channels = discordApiConfig.WebHooks.Where(x => command.Channels.Contains(x.Channel));
            foreach (var item in channels)
            {

            }
        }
    }
}
