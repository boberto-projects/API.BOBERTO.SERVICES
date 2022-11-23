using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections;
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
    public abstract class ICommandHandler<T> : ICommandBase
    {
        public abstract void Handle(T command);


        public void CreateRoute(WebApplication app, string route, IServiceProvider serviceProvider)
        {
            this.DI(serviceProvider);
            app.MapPost(route, ([FromBody] T request) =>
            {
                if (request is ICommandModel<T> commandModel)
                {
                    commandModel.Validator();
                }
                Handle(request);
                return Results.Ok();
            }).WithTags(typeof(T).Name);
        }
    }
}
