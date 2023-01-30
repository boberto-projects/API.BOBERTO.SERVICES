
using API.BOBERTO.SERVICES.APPLICATION.Services.Email;
using API.BOBERTO.SERVICES.APPLICATION.Services.Redis;
using API.BOBERTO.SERVICES.APPLICATION.Services.Zenvio;
using API.BOBERTO.SERVICES.APPLICATION.Services.ZenvioSecurity;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace API.BOBERTO.SERVICES.WEB.Bootstrap
{
    public static partial class Bootstrap
    {
        public static void AddServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddHttpClient();
            builder.Services.AddSingleton<IEmailService, EmailService>();
            builder.Services.AddSingleton<IZenvioService, ZenvioService>();
            builder.Services.AddSingleton<IZenvioSecurityService, ZenvioSecurityService>();
        }
    }
}
