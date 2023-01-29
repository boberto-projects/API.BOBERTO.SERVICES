
using API.BOBERTO.SERVICES.APPLICATION.MESSAGES.Models.Integration.Zenvio.Request;
using API.BOBERTO.SERVICES.APPLICATION.MESSAGES.Models.Integration.Zenvio.Response;
using RestEase;

namespace API.BOBERTO.SERVICES.INTEGRATION.Zenvia
{
    public interface IZenviaApi
    {
        [Header("X-API-TOKEN")]
        string ApiKey { get; set; }

        [Post("channels/sms/messages")]
        Task<SendSMSResponse> SendSMS([Body] SendSMSRequest request);
    }
}
