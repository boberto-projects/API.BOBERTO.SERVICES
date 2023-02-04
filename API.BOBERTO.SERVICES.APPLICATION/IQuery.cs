using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Reflection;

namespace API.BOBERTO.SERVICES.APPLICATION
{
    public interface IQueryBase { }
    public abstract class QueryModel<T>
    {
        public abstract void Validator();
    }
    public abstract class QueryHandler<T> : IQueryBase
    {
        public abstract IResult Handle(T query);

        public void CreateRoute(WebApplication app, string route, IServiceProvider serviceProvider)
        {
            this.DI(serviceProvider);
            app.MapGet("queries/" + route, ([AsParameters] T query) =>
            {
                if (query is QueryModel<T> queryModel)
                {
                    queryModel.Validator();
                }
                return Handle(query);
            }).WithTags(typeof(T).Name)
             .RequireAuthorization("ApiKey");

        }
    }
}
