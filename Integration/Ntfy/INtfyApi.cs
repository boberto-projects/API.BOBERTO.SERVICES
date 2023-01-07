using Application.Message.Models.Integration.Ntfy;
using RestEase;
using System.Threading.Tasks;

namespace api_boberto_services.Integracao.Ntfy
{
    public interface INtfyApi
    {
        [Post]
        Task SendMessage([Body] NtfyRequest body);
    }
}
