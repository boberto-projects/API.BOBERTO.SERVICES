using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace api_boberto_services
{
    public interface IQueryBase { }
    public abstract class IQueryModel<T>
    {
        public abstract void Validator();
        public static ValueTask<T> BindAsync(HttpContext context)
        {
            return ValueTask.FromResult<T>(null);
        }
    }
    public abstract class IQueryHandler<T> : IQueryBase
    {
        public abstract IResult Handle(T query);

        public void CreateRoute(WebApplication app, string route)
        {
            app.MapGet(route, (T query) =>
            {
                
                if (query is IQueryModel<T> queryModel)
                {
                    queryModel.Validator();
                }
                return Handle(query);
            }).WithTags(typeof(T).Name);
        }
    }
}
