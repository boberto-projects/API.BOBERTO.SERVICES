using api_boberto_services.ApiConfig;
using api_boberto_services.Integracao.Discord;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

namespace api_boberto_services.Commands
{
    public class ExemploCommandHandler : ICommandHandler<ExemploCommand>
    {
        private IDiscord _discordApiClient { get; set; }
        private IOptions<DiscordApiConfig> _discordApiConfig { get; set; }
        public override void Handle(ExemploCommand command)
        {

            var discordConfig = _discordApiConfig.Value;
            var discordGithubGroupRequest = new api_authentication_boberto.Integrations.DiscordApiClient.DiscordWebHookRequest()
            {
                Content = command.Mensagem
            };
            var webHookId = discordConfig.WebHookId;
            var webHookToken = discordConfig.WebHookToken;
            _discordApiClient.EnviarMensagem(webHookId, webHookToken, discordGithubGroupRequest);
        }
    }
}
