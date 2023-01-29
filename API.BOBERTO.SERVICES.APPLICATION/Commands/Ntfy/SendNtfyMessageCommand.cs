using API.BOBERTO.SERVICES.APPLICATION.MESSAGES.Models.Integration.Ntfy;
using API.BOBERTO.SERVICES.APPLICATION.MESSAGES.Models.Integration.Ntfy.Models;
using System.Collections.Generic;

namespace API.BOBERTO.SERVICES.APPLICATION.Commands.Ntfy
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
                Topic = Topic,
                Message = Message,
                Title = Title,
                Tags = Tags,
                Priority = Priority,
                Attach = Attach,
                Filename = Filename,
                Click = Click,
                Actions = Actions
            };

        }
        public override void Validator()
        {

        }
    }
}
