using API.BOBERTO.SERVICES.APPLICATION.MESSAGES.Models.Integration.Ntfy;
using RestEase;
using System.Threading.Tasks;

namespace API.BOBERTO.SERVICES.INTEGRATIONS.Ntfy
{
    public interface INtfyApi
    {
        [Post]
        Task SendMessage([Body] NtfyRequest body);
    }
}
