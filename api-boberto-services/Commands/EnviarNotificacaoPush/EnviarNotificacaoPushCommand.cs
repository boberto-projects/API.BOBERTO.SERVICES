namespace api_boberto_services.Commands.EnviarNotificacaoPush
{
    public class EnviarNotificacaoPushCommand : ICommandModel<EnviarNotificacaoPushCommand>
    {
        public string Mensagem { get; set; }
        public override void Validator()
        {
            throw new System.NotImplementedException();
        }
    }
}
