using API.BOBERTO.SERVICES.INTEGRATION.SMSAdbTester.Request;
using RestEase;

namespace API.BOBERTO.SERVICES.INTEGRATION.SMSAdbTester
{
    public interface ISmsAdbTesterApi
    {
        [Post("sendsms")]
        Task SendSMS([Body] SendAdbTesterMessageRequest request);
    }
}
