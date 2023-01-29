using api_boberto_services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace API.BOBERTO.SERVICES.WEB.Bootstrap
{
    public static partial class Bootstrap
    {
        public static void AddAuthentications(this WebApplicationBuilder builder)
        {
            builder.Services.AddAuthentication("api_key")
                .AddScheme<AuthenticationSchemeOptions, ApiKeyAuthenticationHandler>
                ("api_key", null);

            builder.Services.AddAuthorization(options =>
                  options.AddPolicy("ApiKey",
                  policy => policy.RequireClaim("api_key_authentication")));
        }
    }
}
