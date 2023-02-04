using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.BOBERTO.SERVICES.APPLICATION.MESSAGES.Config
{
    public class ApiConfig
    {
        public bool Swagger { get; set; }
        public AuthorizationApiKey Authorization { get; set; }
        public class AuthorizationApiKey
        {
            public bool Activate { get; set; }
            public string ApiHeader { get; set; }
            public string ApiKey { get; set; }
        }
    }
}
