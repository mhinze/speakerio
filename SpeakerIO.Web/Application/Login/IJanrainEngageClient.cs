using System.Net;
using RestSharp;

namespace SpeakerIO.Web.Application.Login
{
    public interface IJanrainEngageClient
    {
        AuthInfo GetAuthInfo(string token);
    }

    public class JanrainEngageClient : IJanrainEngageClient
    {
        readonly IApplicationSettings _settings;

        public JanrainEngageClient(IApplicationSettings settings)
        {
            _settings = settings;
        }

        public AuthInfo GetAuthInfo(string token)
        {
            var client = new RestClient("https://rpxnow.com/");
            var request = new RestRequest("api/v2/auth_info");
            request.AddParameter("token", token);
            request.AddParameter("apiKey", _settings.JanrainApiKey());
            if (_settings.ShouldProxyOutboundHttpRequests())
            {
                client.Proxy = new WebProxy(_settings.OutboundHttpProxy(), true, null,
                                            CredentialCache.DefaultNetworkCredentials);
            }
            var response = client.Execute<AuthInfo>(request);
            return response != null ? response.Data : null;
        }
    }
}