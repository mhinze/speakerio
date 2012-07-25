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
    }
}