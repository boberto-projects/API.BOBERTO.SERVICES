
using API.BOBERTO.SERVICES.APPLICATION.Services.Email;
using API.BOBERTO.SERVICES.APPLICATION.Services.Zenvio;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace api_boberto_services.Bootstrap
{
    public static partial class Bootstrap
    {
        public static void AddServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddHttpClient();
            builder.Services.AddSingleton<IEmailService, EmailService>();
            builder.Services.AddSingleton<ZenvioService>();
        }
    }
}
