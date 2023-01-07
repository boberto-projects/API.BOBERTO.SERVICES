using System.Collections.Generic;

namespace api_boberto_services.WebHooks
{
    public class NtfyWebHookRequest
    {
        public string Topic { get; set; }
        public string Message { get; set; }
        public string Title { get; set; }
        public List<string> Tags { get; set; }
        public int Priority { get; set; }
        public string Attach { get; set; }
        public string Filename { get; set; }
        public string Click { get; set; }
        public List<ActionModel> Actions { get; set; }
    }
    public class ActionModel
    {
        public string Action { get; set; }
        public string Label { get; set; }
        public string Url { get; set; }
    }
}
