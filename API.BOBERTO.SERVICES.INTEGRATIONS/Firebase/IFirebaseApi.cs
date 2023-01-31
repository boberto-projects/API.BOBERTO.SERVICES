using API.BOBERTO.SERVICES.APPLICATION.MESSAGES.Models.Integration.Ntfy;
using API.BOBERTO.SERVICES.INTEGRATIONS.Firebase.Models.Request;
using RestEase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.BOBERTO.SERVICES.INTEGRATIONS.Firebase
{
    public interface IFirebaseApi
    {
        [Header("Authorization", "Bearer")]
        string Authorization { get; set; }
        [Post]
        Task SendNotification([Body] FirebaseNotificationRequest body);
    }
}
