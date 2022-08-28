using Microsoft.AspNetCore.Http;

namespace api_boberto_services.Commands.Docker.CreateContainer
{
    public class CreateContainerHandler : ICommandHandler<CreateContainerCommand>
    {
        public override IResult Handle(CreateContainerCommand command)
        {
            return Results.Ok("Testandooo " + command.ContainerName);
        } 
    }
}
