using api_authentication_boberto.Integrations.DiscordApiClient;
using RestEase;
using System.Threading.Tasks;

namespace api_boberto_services.Integracao.Discord
{
    public interface IDiscord
    {
        [Post("webhooks/{WebHookId}/{WebHookToken}")]
        Task EnviarMensagem([Path] string WebHookId, [Path] string WebHookToken, [Body] DiscordWebHookRequest request);
    }
}
