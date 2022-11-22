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
        private DiscordApiConfig _discordApiConfig { get; set; }

        public ExemploCommandHandler(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _discordApiClient = serviceProvider.GetService<IDiscord>();
            _discordApiConfig = serviceProvider.GetService<IOptions<DiscordApiConfig>>().Value;
        }
        public override void Handle(ExemploCommand command)
        {
            var discordGithubGroupRequest = new api_authentication_boberto.Integrations.DiscordApiClient.DiscordWebHookRequest()
            {
                Content = command.Mensagem
            };
            var webHookId = _discordApiConfig.WebHookId;
            var webHookToken = _discordApiConfig.WebHookToken;
            _discordApiClient.EnviarMensagem(webHookId, webHookToken, discordGithubGroupRequest);
        }
    }
}
