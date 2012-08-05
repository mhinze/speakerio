namespace SpeakerIO.Web.Application.Email
{
    public interface IEmailService
    {
        void Send(EmailMessage message);
    }
}