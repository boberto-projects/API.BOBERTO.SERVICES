
using api_boberto_services.Application;
using api_boberto_services.Application.Message;
using api_boberto_services.Integracao.Ntfy;
using ConfigurationSubstitution;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RestEase.HttpClientFactory;
using System;
using System.Linq;

var builder = WebApplication.CreateBuilder(args);
var config = new ConfigurationBuilder()
.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
.AddJsonFile($"appsettings.json", optional: true, reloadOnChange: true)
.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true, reloadOnChange: true)
.AddEnvironmentVariables()
.EnableSubstitutions("%", "%")
.Build();

builder.Services.Configure<DiscordApiConfig>(options => config.GetSection("DiscordAPIConfig").Bind(options));
builder.Services.AddRestEaseClient<INtfyApi>("https://ntfy.sh");

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();



if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

CQRS.Startup(app);

app.Run();
