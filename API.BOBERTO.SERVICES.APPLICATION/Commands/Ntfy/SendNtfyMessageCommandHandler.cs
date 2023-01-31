using API.BOBERTO.SERVICES.APPLICATION;
using API.BOBERTO.SERVICES.INTEGRATIONS.Ntfy;
using System.Text.Json;

namespace API.BOBERTO.SERVICES.APPLICATION.Commands.Ntfy
{
    public class SendNtfyMessageCommandHandler : CommandAbstractHandler<SendNtfyMessageCommand>
    {
        private INtfyApi _ntfyApi { get; set; }

        public override async void Handle(SendNtfyMessageCommand command)
        {
            await _ntfyApi.SendMessage(command.ToNtfyRequest());
        }
    }
}
