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
            app.CreateCommandRoute();
            app.CreateQueryRoute();
        }

        private static void CreateCommandRoute(this WebApplication app)
        {
            var commandHandlerType = typeof(ICommandBase);
            var types = AppDomain.CurrentDomain.GetAssemblies()
              .SelectMany(s => s.GetTypes())
              .Where(p => commandHandlerType.IsAssignableFrom(p) && p.Namespace.StartsWith("API.BOBERTO.SERVICES.APPLICATION.Commands"));

            foreach (var cmd in types)
            {
                var commandRoute = cmd.Name.Replace("CommandHandler", "");
                dynamic bClass = Activator.CreateInstance(cmd);
                bClass.CreateRoute(app, commandRoute, app.Services);
            }
        }

        private static void CreateQueryRoute(this WebApplication app)
        {
            var queryBaseHandlerType = typeof(IQueryBase);
            var types = AppDomain.CurrentDomain.GetAssemblies()
              .SelectMany(s => s.GetTypes())
                .Where(p =>  queryBaseHandlerType.IsAssignableFrom(p) && p.Namespace.StartsWith("API.BOBERTO.SERVICES.APPLICATION.Queries"));
 
            foreach (var cmd in types)
            {
                var commandRoute = cmd.Name.Replace("QueryHandler", "");
                dynamic bClass = Activator.CreateInstance(cmd);
                bClass.CreateRoute(app, commandRoute, app.Services);
            }
        }
    }
}
