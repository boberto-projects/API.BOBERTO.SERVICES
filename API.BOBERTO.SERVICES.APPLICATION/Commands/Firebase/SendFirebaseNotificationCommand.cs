using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.BOBERTO.SERVICES.APPLICATION.Commands.Firebase
{
    public class SendFirebaseNotificationCommand : CommandAbstract<SendFirebaseNotificationCommand>
    {
        public string TokenFirebase { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public override void Validator()
        {
            if (string.IsNullOrEmpty(TokenFirebase))
            {
                throw new Exception("Token firebase not provided.");
            }
        }
    }
}
