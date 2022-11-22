using Microsoft.AspNetCore.Mvc;
using System;

namespace api_boberto_services.Queries
{
    [BindProperties]
    public class ExemploQuery : IQueryModel<ExemploQuery>
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
