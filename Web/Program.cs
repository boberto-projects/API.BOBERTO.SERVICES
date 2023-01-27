
using api_boberto_services;
using api_boberto_services.Application;
using api_boberto_services.Application.Message;
using api_boberto_services.Integracao.Ntfy;
using Application.Message.ApiConfig;
using ConfigurationSubstitution;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RestEase.HttpClientFactory;
using System;

var builder = WebApplication.CreateBuilder(args);
var config = new ConfigurationBuilder()
.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
.AddJsonFile($"appsettings.json", optional: true, reloadOnChange: true)
.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true, reloadOnChange: true)
.AddEnvironmentVariables()
.EnableSubstitutions("%", "%")
.Build();

builder.Services.AddAuthentication("api_key")
    .AddScheme<AuthenticationSchemeOptions, ApiKeyAuthenticationHandler>
    ("api_key", null);

builder.Services.AddAuthorization(options =>
      options.AddPolicy("ApiKey",
      policy => policy.RequireClaim("api_key_authentication")));

builder.Services.Configure<ApiConfig>(options => config.GetSection("ApiConfig").Bind(options));
builder.Services.Configure<DiscordApiConfig>(options => config.GetSection("DiscordAPIConfig").Bind(options));
builder.Services.AddRestEaseClient<INtfyApi>("https://ntfy.sh");
builder.Services.AddHttpClient();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapGet("", () => "OK");
CQRS.Startup(app);

app.Run();
