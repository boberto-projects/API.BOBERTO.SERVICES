using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace api_boberto_services.Queries
{
    public class ExemploQueryHandler : IQueryHandler<ExemploQuery>
    {
        public override IResult Handle(ExemploQuery query)
        {
            return Results.Ok(query.ContainerName);
        }
    }
}
