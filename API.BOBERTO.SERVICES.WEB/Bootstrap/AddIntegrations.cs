using API.BOBERTO.SERVICES.APPLICATION.MESSAGES.Config;
using API.BOBERTO.SERVICES.INTEGRATIONS.Firebase;
using API.BOBERTO.SERVICES.INTEGRATIONS.Ntfy;
using API.BOBERTO.SERVICES.INTEGRATIONS.SMSAdbTester;
using API.BOBERTO.SERVICES.INTEGRATIONS.Zenvia;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using RestEase.HttpClientFactory;

namespace API.BOBERTO.SERVICES.WEB.Bootstrap
{
    public static partial class Bootstrap
    {
        public static void AddIntegrations(this WebApplicationBuilder builder)
        {
            builder.Services.AddNtfyIntegration();
            builder.Services.AddSMSAdbTesterApi();
            builder.Services.AddZenviaApi();
            builder.Services.AddFirebaseApi();
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
            serviceCollection.AddRestEaseClient<IZenviaApi>(ntfyApiConfig.Url, new()
            {
                InstanceConfigurer = instance => instance.ApiKey = ntfyApiConfig.ApiKey,
            });
        }
        private static void AddFirebaseApi(this IServiceCollection serviceCollection)
        {
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var firebaseApiConfig = serviceProvider.GetRequiredService<IOptions<FirebaseApiConfig>>().Value;
            serviceCollection.AddRestEaseClient<IFirebaseApi>(firebaseApiConfig.Url, new()
            {
                InstanceConfigurer = instance => instance.Authorization = firebaseApiConfig.ApiKey,
            });
        }
    }
}
