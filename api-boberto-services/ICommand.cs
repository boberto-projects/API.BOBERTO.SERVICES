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
    public abstract class CommandBase : ICommandBase
    {
        protected IServiceProvider _services;
        protected CommandBase(IServiceProvider services)
        {
            _services = services;
        }
    }
    public abstract class ICommandHandler<T> : CommandBase
    {
        protected ICommandHandler(IServiceProvider services) : base(services)
        {
        }

        public abstract IResult Handle(T command);

        public void CreateRoute(WebApplication app, string route)
        {
            app.MapPost(route, ([FromBody] T request) =>
            {
                if (request is ICommandModel<T> commandModel)
                {
                    commandModel.Validator();
                }
                return Handle(request);
            }).WithTags(typeof(T).Name);
        }
    }
}
