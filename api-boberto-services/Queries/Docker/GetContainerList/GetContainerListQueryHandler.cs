using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace api_boberto_services.Queries.Docker.GetContainerList
{
    public class GetContainerListQueryHandler : IQueryHandler<GetContainerListQuery>
    {
        public override IResult Handle(GetContainerListQuery query)
        {
            return Results.Ok(query.ContainerName);
        }
    }
}
