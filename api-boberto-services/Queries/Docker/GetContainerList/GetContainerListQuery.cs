using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Threading.Tasks;

namespace api_boberto_services.Queries.Docker.GetContainerList
{
    [BindRequired]
    public class GetContainerListQuery : IQueryModel<GetContainerListQuery>
    {
        public string ContainerName { get; set; }

        public static  ValueTask<GetContainerListQuery> BindAsync(HttpContext context)
        {
            return ValueTask.FromResult<GetContainerListQuery?>(
                new GetContainerListQuery()
                {
                    ContainerName = context.Request.Query["ContainerName"]
                });
        }     

        public override void Validator()
        {
            if (string.IsNullOrEmpty(ContainerName))
            {
                throw new Exception("SEM ContainerName");
            }
        }
    }
}
