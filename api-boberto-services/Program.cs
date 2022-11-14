using api_boberto_services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var commandHandlerType = typeof(ICommandBase);
var queryBaseHandlerType = typeof(IQueryBase);

var types = AppDomain.CurrentDomain.GetAssemblies()
    .SelectMany(s => s.GetTypes())
    .Where(p => commandHandlerType.IsAssignableFrom(p) && p.Namespace.StartsWith("api_boberto_services.Commands") || queryBaseHandlerType.IsAssignableFrom(p) && p.Namespace.StartsWith("api_boberto_services.Queries"));

foreach (var cmd in types)
{
    var commandRoute = cmd.Name.Replace("Handler", "");
    dynamic bClass = Activator.CreateInstance(cmd);
    bClass.CreateRoute(app, commandRoute);
}

app.Run();
