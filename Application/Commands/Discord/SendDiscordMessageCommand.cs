using System.Collections;
using System.Collections.Generic;

namespace api_boberto_services.Application.Commands
{
    public class SendDiscordMessageCommand : ICommandModel<SendDiscordMessageCommand>
    {
        public IEnumerable<string> Channels { get; set; }
        public string Content { get; set; }
        public override void Validator()
        {

        }
    }
}
