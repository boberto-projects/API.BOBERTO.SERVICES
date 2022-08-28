using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Threading.Tasks;

namespace api_boberto_services.Queries.Docker.GetContainerList
{
    [BindRequired]
    public class GetContainerListQuery : IQueryModel<GetContainerListQuery>
    {
        public string CPFCNPJ { get; set; }

        //public static override ValueTask<GetContainerListQuery> BindAsync(HttpContext context)
        //{
        //    return ValueTask.FromResult<GetContainerListQuery?>(
        //        new GetContainerListQuery()
        //        {
        //            CPFCNPJ = context.Request.Query["CPFCNPJ"]
        //        });
        //}

        //public static ValueTask<GetContainerListQuery> BindAsync(HttpContext context)
        //{
        //    return ValueTask.FromResult<GetContainerListQuery?>(
        //        new GetContainerListQuery()
        //        {
        //            CPFCNPJ = context.Request.Query["CPFCNPJ"]
        //       }); 
        //}

        public override void Validator()
        {
            if (string.IsNullOrEmpty(CPFCNPJ))
            {
                throw new Exception("SEM CPFCNPJ");
            }
        }
    }
}
