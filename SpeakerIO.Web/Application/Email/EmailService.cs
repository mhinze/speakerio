using System.Configuration;
using RestSharp;

namespace SpeakerIO.Web.Application.Email
{
    public class EmailService : IEmailService
    {
        public void Send(EmailMessage message)
        {
            var restClient = new RestClient("https://api.mailgun.net/v2")
            {
                Authenticator = new HttpBasicAuthenticator("api", ConfigurationManager.AppSettings["MAILGUN_API_KEY"])
            };

            var request = new RestRequest
            {
                Method = Method.POST,
                Resource = "{domain}/messages"
            };

            request.AddParameter("domain", "speakerio-test.mailgun.org", ParameterType.UrlSegment);
            request.AddParameter("from", "no-reply@speakerio-test.mailgun.org");
            foreach (var to in message.To)
            {
                request.AddParameter("to", to);
            }
            request.AddParameter("subject", message.Subject);
            request.AddParameter("text", message.Text);

            var response = restClient.Execute(request);
        }
    }
}