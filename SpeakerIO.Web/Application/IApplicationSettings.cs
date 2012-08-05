namespace SpeakerIO.Web.Application
{
    public interface IApplicationSettings
    {
        string JanrainApiKey();
        string JanrainAppName();
        bool ShouldProxyOutboundHttpRequests();
        string OutboundHttpProxy();
        string MailgunDomain();
        string MailgunApiKey();
    }
}