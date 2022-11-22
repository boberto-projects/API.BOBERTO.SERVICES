namespace api_boberto_services.Commands
{
    public class ExemploCommand : ICommandModel<ExemploCommand>
    {
        public string Mensagem { get; set; }
        public override void Validator()
        {

        }
    }
}
