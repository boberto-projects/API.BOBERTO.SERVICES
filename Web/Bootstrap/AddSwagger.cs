using api_authentication_boberto.Integrations.SMSAdbTester;
using api_boberto_services.Integracao.Ntfy;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace api_boberto_services.Bootstrap
{
    public partial class Bootstrap
    {
        public static void AddSwagger(this WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
        }
    }
}
