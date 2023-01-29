using API.BOBERTO.SERVICES.APPLICATION.MESSAGES.Models.Integration.Zenvio.Response;
using System.Threading.Tasks;

namespace API.BOBERTO.SERVICES.APPLICATION.Services.Zenvio
{
    public interface IZenvioService
    {
        Task<SendSMSResponse> SendSMS(string phoneNumber, string text);
    }
}
