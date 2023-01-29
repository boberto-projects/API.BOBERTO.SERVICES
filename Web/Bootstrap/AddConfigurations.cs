using API.BOBERTO.SERVICES.APPLICATION.MESSAGES.Config;
using ConfigurationSubstitution;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace API.BOBERTO.SERVICES.WEB.Bootstrap
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
            builder.Services.Configure<ZenvioSecurityConfig>(options => config.GetSection("ZenvioSecurityConfig").Bind(options));
            builder.Services.Configure<ZenviaApiConfig>(options => config.GetSection("ZenviaApiConfig").Bind(options));
            builder.Services.Configure<NtfyApiConfig>(options => config.GetSection("NtfyApiConfig").Bind(options));
            builder.Services.Configure<SmtpConfig>(options => config.GetSection("SmtpConfig").Bind(options));
        }
    }
}
