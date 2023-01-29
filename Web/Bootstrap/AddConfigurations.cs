using API.BOBERTO.SERVICES.APPLICATION.MESSAGES.Config;
using api_authentication_boberto.Integrations.SMSAdbTester;
using api_authentication_boberto.Services.Email;
using api_authentication_boberto.Services.Zenvio;
using api_boberto_services.Integracao.Ntfy;
using ConfigurationSubstitution;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace api_boberto_services.Bootstrap
{
    public  static partial class Bootstrap
    {
        public static void AddConfigurations(this WebApplicationBuilder builder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile($"appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .EnableSubstitutions("%", "%")
                .Build();
            builder.Services.Configure<ApiConfig>(options => config.GetSection("ApiConfig").Bind(options));
            builder.Services.Configure<DiscordApiConfig>(options => config.GetSection("DiscordAPIConfig").Bind(options));
            builder.Services.Configure<SmsAdbTesterApiConfig>(options => config.GetSection("SmsAdbTesterApiConfig").Bind(options));
            builder.Services.Configure<ZenviaApiConfig>(options => config.GetSection("ZenviaApiConfig").Bind(options));
            builder.Services.Configure<NtfyApiConfig>(options => config.GetSection("NtfyApiConfig").Bind(options));
        }
    }
}
