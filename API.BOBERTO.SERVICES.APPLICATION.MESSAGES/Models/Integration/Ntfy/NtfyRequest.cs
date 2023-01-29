using API.BOBERTO.SERVICES.APPLICATION.MESSAGES.Models.Integration.Ntfy.Models;
using System.Collections.Generic;

namespace API.BOBERTO.SERVICES.APPLICATION.MESSAGES.Models.Integration.Ntfy
{
    public class NtfyRequest
    {
        public string Topic { get; set; }
        public string Message { get; set; }
        public string Title { get; set; }
        public IEnumerable<string> Tags { get; set; }
        public int Priority { get; set; }
        public string Attach { get; set; }
        public string Filename { get; set; }
        public string Click { get; set; }
        public IEnumerable<NtfyActionModel> Actions { get; set; }
    }

}
