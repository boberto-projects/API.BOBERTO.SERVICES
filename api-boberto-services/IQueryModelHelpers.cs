using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace api_boberto_services
{
    public class IQueryModelHelpers<T>
    {
        public static ValueTask<T> BindAsync<T>(HttpContext context) => throw new System.Exception("BLAB");
    }
}