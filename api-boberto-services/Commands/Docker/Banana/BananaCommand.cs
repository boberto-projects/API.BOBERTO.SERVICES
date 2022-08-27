namespace api_boberto_services.Commands.Docker.Banana
{
    public class BananaCommand : ICommandModel<BananaCommand>
    {
        public string NomeBanana { get; set; }

        public override void Validator()
        {
            throw new System.NotImplementedException();
        }
    }
}
