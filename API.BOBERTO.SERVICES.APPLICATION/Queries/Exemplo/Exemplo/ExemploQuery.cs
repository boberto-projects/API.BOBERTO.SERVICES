using Microsoft.AspNetCore.Mvc;
using System;

namespace API.BOBERTO.SERVICES.APPLICATION.Queries.Exemplo.Exemplo
{
    [BindProperties]
    public class ExemploQuery : QueryModel<ExemploQuery>
    {
        public string ContainerName { get; set; }
        public string DockerName { get; set; }

        public override void Validator()
        {
            if (string.IsNullOrEmpty(ContainerName))
            {
                throw new Exception("SEM ContainerName");
            }
        }
    }
}
