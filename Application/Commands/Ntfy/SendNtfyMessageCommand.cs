using Application.Message.Models.Integration.Ntfy;
using Application.Message.Models.Integration.Ntfy.Models;
using System.Collections.Generic;

namespace api_boberto_services.Application.Commands
{
    public class SendNtfyMessageCommand : ICommandModel<SendNtfyMessageCommand>
    {
        public string Topic { get; set; }
        public string Message { get; set; }
        public string Title { get; set; }
        public List<string> Tags { get; set; }
        public int Priority { get; set; }
        public string Attach { get; set; }
        public string Filename { get; set; }
        public string Click { get; set; }
        public IEnumerable<NtfyActionModel> Actions { get; set; }

        public class ActionModel
        {
            public string Action { get; set; }
            public string Label { get; set; }
            public string Url { get; set; }
        }
        public NtfyRequest ToNtfyRequest()
        {
            return new NtfyRequest()
            {
                Topic = this.Topic,
                Message = this.Message,
                Title = this.Title,
                Tags = this.Tags,
                Priority = this.Priority,
                Attach = this.Attach,
                Filename = this.Filename,
                Click = this.Click,
                Actions = this.Actions
            };

        }
        public override void Validator()
        {

        }
    }
}
