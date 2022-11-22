using api_authentication_boberto.Integrations.DiscordApiClient;
using api_boberto_services;
using api_boberto_services.ApiConfig;
using api_boberto_services.Integracao.Discord;
using ConfigurationSubstitution;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RestEase.HttpClientFactory;
using System;
using System.Linq;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var config = new ConfigurationBuilder()
.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
.AddJsonFile($"appsettings.json", optional: true, reloadOnChange: true)
.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true, reloadOnChange: true)
.AddEnvironmentVariables()
.EnableSubstitutions("%", "%")
.Build();

builder.Services.Configure<DiscordApiConfig>(options => config.GetSection("DiscordAPIConfig").Bind(options));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

DiscordApiBuilder.BuildDiscordAPI(builder.Services, config);

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
    dynamic bClass = Activator.CreateInstance(cmd, app.Services);

    bClass.CreateRoute(app, commandRoute);
}


app.Run();
