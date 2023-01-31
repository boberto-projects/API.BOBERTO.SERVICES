using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections;
using System.Net.Http;
using System.Reflection;
using System.Text.Json.Serialization;

namespace API.BOBERTO.SERVICES.APPLICATION
{
    public interface ICommandBase
    {
    }
    public abstract class CommandAbstract<T>
    {
        public abstract void Validator();
    }
    public abstract class CommandAbstractHandler<T> : ICommandBase
    {
        public abstract void Handle(T command);

        public void CreateRoute(WebApplication app, string route, IServiceProvider serviceProvider)
        {
            this.DI(serviceProvider);
            app.MapPost("commands/" + route, ([FromBody] T request) =>
            {
                if (request is CommandAbstract<T> commandModel)
                {
                    commandModel.Validator();
                }
                Handle(request);
                return Results.Ok();
            }).WithTags(typeof(T).Name)
            .RequireAuthorization("ApiKey");
        }
    }
}
