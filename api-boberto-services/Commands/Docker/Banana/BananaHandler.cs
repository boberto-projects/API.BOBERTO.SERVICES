using Microsoft.AspNetCore.Http;

namespace api_boberto_services.Commands.Docker.Banana
{
    public class BananaHandler : ICommandHandler<BananaCommand>
    {
   
        public override IResult Handle(BananaCommand command)
        {
            throw new System.NotImplementedException();
        }

        public override void Validator()
        {
            throw new System.NotImplementedException();
        }
    }
}
