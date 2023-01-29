using API.BOBERTO.SERVICES.APPLICATION.MESSAGES.Config;
using API.BOBERTO.SERVICES.APPLICATION.MESSAGES.Exceptions;
using API.BOBERTO.SERVICES.APPLICATION.MESSAGES.Exceptions.Models;
using API.BOBERTO.SERVICES.APPLICATION.MESSAGES.Models.Integration.Zenvio.Request;
using API.BOBERTO.SERVICES.APPLICATION.MESSAGES.Models.Integration.Zenvio.Response;
using API.BOBERTO.SERVICES.APPLICATION.Services.ZenvioSecurity;
using API.BOBERTO.SERVICES.INTEGRATIONS.Zenvia;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.BOBERTO.SERVICES.APPLICATION.Services.Zenvio
{
    public class ZenvioService : IZenvioService
    {
        private IOptions<ZenviaApiConfig> zenviaApiConfig;
        private IZenvioSecurityService gerenciadorZenvio;
        private IZenviaApi zenviaApiClient;

        public ZenvioService(IOptions<ZenviaApiConfig> zenviaApiConfig, IZenvioSecurityService gerenciadorZenvio, IZenviaApi zenviaApiClient)
        {
            this.zenviaApiConfig = zenviaApiConfig;
            this.gerenciadorZenvio = gerenciadorZenvio;
            this.zenviaApiClient = zenviaApiClient;
        }

        public async Task<SendSMSResponse> SendSMS(string phoneNumber, string texto)
        {
            if (zenviaApiConfig.Value.Enabled == false)
            {
                throw new CustomException(StatusCodeEnum.INTERN, "Disabled resource");
            }

            gerenciadorZenvio.IncrementAttemp();

            if (gerenciadorZenvio.ReachedMaximumLimitOfAttempts())
            {
                throw new CustomException(StatusCodeEnum.INTERN, "Max SMS LIMIT reachead");
            }

            var messageContent = new List<SendSMSRequest.Content>() { new()
            {
                Type = "text",
                Text = texto
            }};

            return await zenviaApiClient.SendSMS(new()
            {
                To = phoneNumber,
                From = zenviaApiConfig.Value.Alias,
                Contents = messageContent
            });
        }

        public async Task SendSMSCode(string phoneNumber, string code)
        {
            var messageContent = $"ApiAuthBoberto: Your code is {code}";

            await SendSMS(phoneNumber, messageContent);
        }
    }
}
