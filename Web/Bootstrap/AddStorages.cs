using API.BOBERTO.SERVICES.APPLICATION.Services.Redis;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace API.BOBERTO.SERVICES.WEB.Bootstrap
{
    public static partial class Bootstrap
    {
        public static void AddStorages(this WebApplicationBuilder builder)
        {
            builder.Services.AddRedisStorage();
        }
        private static void AddRedisStorage(this IServiceCollection serviceCollection)
        {
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var config = serviceProvider.GetRequiredService<IConfigurationRoot>();
            var redisContext = config.GetConnectionString("RedisConnectionContext");
            serviceCollection.AddStackExchangeRedisCache(options => options.Configuration = GetRedisContext(redisContext));
            serviceCollection.AddSingleton<IRedisService, RedisService>();
        }
        private static string GetRedisContext(string redisContextUrl)
        {
            Uri redisUrl;
            bool isRedisUrl = Uri.TryCreate(redisContextUrl, UriKind.Absolute, out redisUrl);
            if (isRedisUrl)
            {
                redisContextUrl = string.Format("{0}:{1},password={2}", redisUrl.Host, redisUrl.Port, redisUrl.UserInfo.Split(':')[1]);
            }
            return redisContextUrl;
        }
    }
    
    
}
