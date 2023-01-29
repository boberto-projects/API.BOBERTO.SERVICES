using API.BOBERTO.SERVICES.APPLICATION.MESSAGES.Config;
using API.BOBERTO.SERVICES.INTEGRATION.Ntfy;
using API.BOBERTO.SERVICES.INTEGRATION.SMSAdbTester;
using API.BOBERTO.SERVICES.INTEGRATION.Zenvia;
using api_authentication_boberto.Services.Email;
using api_authentication_boberto.Services.Zenvio;
using api_boberto_services.Application.Message;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using RestEase.HttpClientFactory;
using System;

namespace api_boberto_services.Bootstrap
{
    public static partial class Bootstrap
    {
        public static void AddIntegrations(this WebApplicationBuilder builder)
        {
            builder.Services.AddNtfyIntegration();
            builder.Services.AddSMSAdbTesterApi();
            builder.Services.AddZenviaApi();
        }

        private static void AddNtfyIntegration(this IServiceCollection serviceCollection)
        {
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var ntfyApiConfig = serviceProvider.GetRequiredService<IOptions<NtfyApiConfig>>().Value;
            serviceCollection.AddRestEaseClient<INtfyApi>(ntfyApiConfig.Url);
        }
        private static void AddSMSAdbTesterApi(this IServiceCollection serviceCollection)
        {
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var ntfyApiConfig = serviceProvider.GetRequiredService<IOptions<SmsAdbTesterApiConfig>>().Value;
            serviceCollection.AddRestEaseClient<ISmsAdbTesterApi>(ntfyApiConfig.Url);
        }
        private static void AddZenviaApi(this IServiceCollection serviceCollection)
        {
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var ntfyApiConfig = serviceProvider.GetRequiredService<IOptions<ZenviaApiConfig>>().Value;
            serviceCollection.AddRestEaseClient<IZenviaApi>(ntfyApiConfig.Url);
        }
    }
}
