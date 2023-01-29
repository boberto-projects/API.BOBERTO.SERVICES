using API.BOBERTO.SERVICES.APPLICATION;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace API.BOBERTO.SERVICES.APPLICATION.Queries.Exemplo.Exemplo
{
    public class ExemploQueryHandler : IQueryHandler<ExemploQuery>
    {
        public override IResult Handle(ExemploQuery query)
        {
            return Results.Ok(query.ContainerName);
        }
    }
}
