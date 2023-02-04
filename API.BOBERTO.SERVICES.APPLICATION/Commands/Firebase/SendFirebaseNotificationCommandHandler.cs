using API.BOBERTO.SERVICES.INTEGRATIONS.Firebase;
using API.BOBERTO.SERVICES.INTEGRATIONS.Firebase.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.BOBERTO.SERVICES.APPLICATION.Commands.Firebase
{
    public class SendFirebaseNotificationCommandHandler : CommandAbstractHandler<SendFirebaseNotificationCommand>
    {
        private IFirebaseApi firebaseApi { get; set; }
        public override void Handle(SendFirebaseNotificationCommand command)
        {
            var request = new FirebaseNotificationRequest()
            {
                Body = command.Message,
                Title = command.Title,
                To = command.TokenFirebase
            };
            firebaseApi.SendNotification(request);
        }
    }
}
