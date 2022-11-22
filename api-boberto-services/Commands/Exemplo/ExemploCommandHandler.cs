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
        public ExemploCommandHandler(IServiceProvider services) : base(services)
        {
            _discordApiClient = services.GetService<IDiscord>();
            _discordApiConfig = services.GetService<IOptions<DiscordApiConfig>>().Value;
        }


        public override IResult Handle(ExemploCommand command)
        {
            _discordApiClient.EnviarMensagem(_discordApiConfig.WebHookId, _discordApiConfig.WebHookToken, new api_authentication_boberto.Integrations.DiscordApiClient.DiscordWebHookRequest()
            {
                Content = "teste de notificação - boberto api service"
            });

            return Results.Ok();
        }
    }
}
