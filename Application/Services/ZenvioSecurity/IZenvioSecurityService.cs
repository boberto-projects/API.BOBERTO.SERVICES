using API.BOBERTO.SERVICES.APPLICATION.MESSAGES.Cache;
using System;

namespace API.BOBERTO.SERVICES.APPLICATION.Services.ZenvioSecurity
{
    public interface IZenvioSecurityService
    {
        void CreateCache();
        bool ReachedMaximumLimitOfAttempts();
        void IncrementAttemp();
        TimeSpan GetBlockTime();
        TimeSpan GetBlockTimeRemaining();
        ZenvioCacheModel GetCahe();
    }
}
