using System;

namespace api_boberto_services.Commands.Docker.CreateContainer
{
    public class CreateContainerCommand : ICommandModel<CreateContainerCommand>
    {
        public string ContainerName { get; set; }

        public override void Validator()
        {
            if (string.IsNullOrEmpty(ContainerName))
            {
                throw new Exception("É hora de testar o comportamento do validator");
            }
            throw new Exception("JHGEWYGRYUEWRGYUEWRGYUEWGEYWUGYUEWGU");
        }

    }
}
