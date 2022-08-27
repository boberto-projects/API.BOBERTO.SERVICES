using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection;
using System.Text.Json.Serialization;

namespace api_boberto_services
{
    public interface ICommandBase
    {

    }
    public abstract class ICommandModel<T>
    {
        public abstract void Validator();
    }

    public abstract class ICommandHandler<T>: ICommandBase
    {
        public abstract IResult Handle(T command);

        public void CreateRoute(WebApplication app, string route)
        {
            app.MapPost(route, ([FromBody] T request) =>
            {
                return Handle(request);
            }).WithTags(typeof(T).Name);
        }
    }
}
