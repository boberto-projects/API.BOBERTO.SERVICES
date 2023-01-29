﻿using Microsoft.Extensions.Caching.Distributed;
using System;

namespace API.BOBERTO.SERVICES.APPLICATION.Services.Redis
{
    public interface IRedisService
    {
        T Get<T>(string chave);
        T Set<T>(string chave, T valor, TimeSpan expiracao);
        T Set<T>(string chave, T valor, DistributedCacheEntryOptions cacheOptions);
        T Set<T>(string chave, T valor);
        bool Clear(string chave);
        bool Exists(string chave);
    }
}
