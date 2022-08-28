using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace api_boberto_services.Queries.Docker.GetContainerList
{
    public class GetContainerListQueryHandler : IQueryHandler<GetContainerListQuery>
    {
        public override IResult Handle(GetContainerListQuery query)
        {
            var listFake = new List<string>() { "teste", "teste1", "teste2", query.CPFCNPJ };
            return Results.Ok(listFake);
        }
    }
}
