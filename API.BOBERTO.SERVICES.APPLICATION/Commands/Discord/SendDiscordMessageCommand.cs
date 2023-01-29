using API.BOBERTO.SERVICES.APPLICATION;
using System.Collections;
using System.Collections.Generic;

namespace API.BOBERTO.SERVICES.APPLICATION.Commands.Discord
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
