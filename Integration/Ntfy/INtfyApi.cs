using api_boberto_services.WebHooks;
using RestEase;
using System.Threading.Tasks;

namespace api_boberto_services.Integracao.Ntfy
{
    public interface INtfyApi
    {
        [Post]
        Task SendMessage([Body] NtfyWebHookRequest request);
    }
}
