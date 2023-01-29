namespace API.BOBERTO.SERVICES.APPLICATION.Services.Email
{
    public interface IEmailService
    {
        void Send(string to, string subject, string html);
    }
}
