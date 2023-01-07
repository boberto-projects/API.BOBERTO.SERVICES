using api_boberto_services;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
namespace api_boberto_services.Application
{
    public static class CQRS
    {
        public static void Startup(WebApplication app)
        {

            var commandHandlerType = typeof(ICommandBase);
            var queryBaseHandlerType = typeof(IQueryBase);

            ///we need to refactor this after somepointçç
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => commandHandlerType.IsAssignableFrom(p) && p.Namespace.StartsWith("api_boberto_services.Application.Commands") || queryBaseHandlerType.IsAssignableFrom(p) && p.Namespace.StartsWith("api_boberto_services.Application.Queries"));

            foreach (var cmd in types)
            {
                var commandRoute = cmd.Name.Replace("Handler", "");
                dynamic bClass = Activator.CreateInstance(cmd);
                bClass.CreateRoute(app, commandRoute, app.Services);
            }

        }
    }
}
