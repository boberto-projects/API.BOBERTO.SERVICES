using Microsoft.AspNetCore.Http;

namespace api_boberto_services.Commands.EnviarNotificacaoPush
{
    public class EnviarNotificacaoHandler : ICommandHandler<EnviarNotificacaoPushCommand>
    {
        public override IResult Handle(EnviarNotificacaoPushCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}
