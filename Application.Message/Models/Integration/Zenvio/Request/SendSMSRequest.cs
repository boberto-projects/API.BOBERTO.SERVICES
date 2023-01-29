﻿using Newtonsoft.Json;

namespace API.BOBERTO.SERVICES.APPLICATION.MESSAGES.Models.Integration.Zenvio.Request
{
    public class SendSMSRequest
    {

        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("to")]
        public string To { get; set; }

        [JsonProperty("contents")]
        public IEnumerable<Content> Contents { get; set; }

        public class Content
        {
            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("text")]
            public string Text { get; set; }
        }
    }
}
