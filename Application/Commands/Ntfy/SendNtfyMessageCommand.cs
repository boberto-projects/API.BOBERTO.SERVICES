using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.Collections.Generic;

namespace api_boberto_services.Application.Commands
{
    public class SendNtfyMessageCommand : ICommandModel<SendNtfyMessageCommand>
    {
        public string Topic { get; set; }
        public string Payload { get; set; }
        public override void Validator()
        {

        }
    }
}
