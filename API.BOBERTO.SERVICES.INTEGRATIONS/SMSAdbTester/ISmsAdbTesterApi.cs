﻿using API.BOBERTO.SERVICES.INTEGRATIONS.SMSAdbTester.Request;
using RestEase;

namespace API.BOBERTO.SERVICES.INTEGRATIONS.SMSAdbTester
{
    public interface ISmsAdbTesterApi
    {
        [Post("sendsms")]
        Task SendSMS([Body] SendAdbTesterMessageRequest request);
    }
}
