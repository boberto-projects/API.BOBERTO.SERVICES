using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.BOBERTO.SERVICES.INTEGRATIONS.Firebase.Models.Request
{
    public class FirebaseNotificationRequest
    {
        public string To { get; set; }
        public string Title { get; set; }
        public string? Body { get; set; }
        public string? Icon { get; set; }
        public string? Sound { get; set; }
        public string Color { get; set; }
        [JsonProperty("click_action")]
        public string ClickAction { get; set; }

    }
}
