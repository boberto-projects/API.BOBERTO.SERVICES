using api_boberto_services.ApiConfig;
using api_boberto_services.Integracao.Discord;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestEase;

namespace api_authentication_boberto.Integrations.DiscordApiClient
{
    public static class DiscordApiBuilder
    {
        public static void BuildDiscordAPI(this IServiceCollection services, IConfigurationRoot config)
        {
            var configOptions = config.GetSection("DiscordAPIConfig").Get<DiscordApiConfig>();

            IDiscord api = RestClient.For<IDiscord>(configOptions.Url);

            services.AddSingleton(api);
        }
    }
}
