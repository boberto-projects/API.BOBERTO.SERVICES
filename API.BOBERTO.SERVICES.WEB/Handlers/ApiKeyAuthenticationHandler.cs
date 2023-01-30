using API.BOBERTO.SERVICES.APPLICATION.MESSAGES.Config;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RestEase.Implementation;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace API.BOBERTO.SERVICES.WEB.Handlers
{
    public class ApiKeyAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private ApiConfig apiConfig { get; set; }
        public ApiKeyAuthenticationHandler(IOptions<ApiConfig> _apiConfig, IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
            apiConfig = _apiConfig.Value;
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            ///TODO: this is a base to use before identity class.
            var claims = new[] { new Claim("api_key_authentication", "can_call_routes") };
            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            if (apiConfig.Authorization.Activate == false)
            {
                return Task.FromResult(AuthenticateResult.Success(ticket));
            }

            if (Request.Headers.TryGetValue(apiConfig.Authorization.ApiHeader, out
                   var extractedApiKey) == false)
            {
                return Task.FromResult(AuthenticateResult.Fail("Api key não informada"));
            }

            if (apiConfig.Authorization.ApiKey.Equals(extractedApiKey) == false)
            {
                return Task.FromResult(AuthenticateResult.Fail("Não autorizado"));
            }

            return Task.FromResult(AuthenticateResult.Success(ticket));
        }
    }
}
