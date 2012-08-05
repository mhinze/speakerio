using System.ComponentModel;
using NUnit.Framework;
using SpeakerIO.Web.Application;
using SpeakerIO.Web.Application.Email;

namespace SpeakerIO.UnitTests.IntegrationTests.Email
{
    [TestFixture]
    public class Sending_an_email
    {
        [Test, Explicit]
        public void Test_email()
        {
            var email = new EmailMessage()
            {
                To = new[] { "test34@mailinator.com" },
                From = "test@speakerio-test.mailgun.com",
                Text = "this is a test",
                Subject = "test subject",
                Cc = new[]{"cctest@example.com"},
                Bcc = new[]{"test34-bcc@mailinator.com"},
                Html = "<b>HTML!</b>"
            };

            var emailService = new EmailService(new ApplicationSettings());
            emailService.Send(email);

            // http://www.mailinator.com/maildir.jsp?email=test34
            // http://www.mailinator.com/maildir.jsp?email=test34-bcc
        }    
    }
}