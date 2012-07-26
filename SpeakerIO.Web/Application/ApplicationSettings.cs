using System.Configuration;

namespace SpeakerIO.Web.Application
{
    public class ApplicationSettings : IApplicationSettings
    {
        public string JanrainApiKey()
        {
            return ConfigurationManager.AppSettings["janrainApiKey"];
        }

        public string JanrainAppName()
        {
            return ConfigurationManager.AppSettings["janrainName"];
        }

        public bool ShouldProxyOutboundHttpRequests()
        {
            return string.IsNullOrWhiteSpace(OutboundHttpProxy());
        }

        public string OutboundHttpProxy()
        {
            return ConfigurationManager.AppSettings["outboundHttpProxy"];
        }
    }
}