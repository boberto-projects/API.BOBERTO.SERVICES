using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;

namespace api_boberto_services
{
    public interface IQueryBase { }
    public abstract class IQueryModel<T>
    {
        public abstract void Validator();
    }
    public abstract class IQueryHandler<T> : IQueryBase
    {
        private IServiceProvider _serviceProvider;

        public IQueryHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public abstract IResult Handle(T query);

        public void CreateRoute(WebApplication app, string route)
        {
            app.MapGet(route, ([AsParameters] T query) =>
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
