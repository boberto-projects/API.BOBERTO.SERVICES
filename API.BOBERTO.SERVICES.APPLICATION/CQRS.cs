using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
namespace API.BOBERTO.SERVICES.APPLICATION
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
                .Where(p => commandHandlerType.IsAssignableFrom(p) && p.Namespace.StartsWith("API.BOBERTO.SERVICES.APPLICATION.Commands") || queryBaseHandlerType.IsAssignableFrom(p) && p.Namespace.StartsWith("API.BOBERTO.SERVICES.APPLICATION.Queries"));

            foreach (var cmd in types)
            {
                var commandRoute = cmd.Name.Replace("Handler", "");
                dynamic bClass = Activator.CreateInstance(cmd);
                bClass.CreateRoute(app, commandRoute, app.Services);
            }

        }
    }
}
