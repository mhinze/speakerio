using System.Configuration;
using RestSharp;

namespace SpeakerIO.Web.Application.Email
{
    public class EmailService : IEmailService
    {
        readonly IApplicationSettings _settings;

        public EmailService(IApplicationSettings settings)
        {
            _settings = settings;
        }

        public void Send(EmailMessage message)
        {
            // http://documentation.mailgun.net/api-sending.html

            var domain = _settings.MailgunDomain();
            var apiKey = _settings.MailgunApiKey();

            var restClient = new RestClient("https://api.mailgun.net/v2")
            {
                Authenticator = new HttpBasicAuthenticator("api", apiKey)
            };

            var request = new RestRequest
            {
                Method = Method.POST,
                Resource = "{domain}/messages"
            };

            request.AddParameter("domain", domain, ParameterType.UrlSegment);
            request.AddParameter("from", message.From ?? GetNoReply());
            foreach (var to in message.To)
            {
                request.AddParameter("to", to);
            }
            foreach (var cc in message.Cc)
            {
                request.AddParameter("cc", cc);
            }
            foreach (var bcc in message.Bcc)
            {
                request.AddParameter("bcc", bcc);
            }
            request.AddParameter("subject", message.Subject);
            request.AddParameter("text", message.Text);
            request.AddParameter("html", message.Html);

            var response = restClient.Execute(request);
        }

        string GetNoReply()
        {
            return "no-reply@" + _settings.MailgunDomain();
        }
    }
}