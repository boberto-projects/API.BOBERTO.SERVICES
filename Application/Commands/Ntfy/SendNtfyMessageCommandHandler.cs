using api_boberto_services.Integracao.Ntfy;

namespace api_boberto_services.Application.Commands
{
    public class SendNtfyMessageCommandHandler : ICommandHandler<SendNtfyMessageCommand>
    {
        private INtfyApi _ntfyApi { get; set; }

        public override async void Handle(SendNtfyMessageCommand command)
        {
            // await _ntfyApi.SendMessage()
        }
    }
}
