using Docker.DotNet;
using Docker.DotNet.Models;

namespace api_boberto_services.Models
{
    public class CreateImageRequest
    {
        public ImagesCreateParameters ImageParams { get; set; }
        public AuthConfig? AuthParams { get; set; }

    }
}
