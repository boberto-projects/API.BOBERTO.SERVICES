using api_authentication_boberto.Models.Cache;

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
