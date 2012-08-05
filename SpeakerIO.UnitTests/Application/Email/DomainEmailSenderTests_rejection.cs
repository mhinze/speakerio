using System;
using System.Linq;
using NUnit.Framework;
using Rhino.Mocks;
using SpeakerIO.Web.Application.Email;
using SpeakerIO.Web.Areas.Speaker.Models;
using SpeakerIO.Web.Data.Model;
using Should;

namespace SpeakerIO.UnitTests.Application.Email
{
    [TestFixture]
    public class DomainEmailSenderTests_rejection : TestBase
    {
        EmailMessage emailMessage;

        [TestFixtureSetUp]
        public void When_sending_a_rejection_email()
        {
            var email = S<IEmailService>();

            var organizer = new User("organizer")
            {
                Email = "organizer@example.com"
            };

            var callForSpeakers = new CallForSpeakers
            {
                User = organizer,
                EventName = "event"
            };

            var speaker = new User("foo")
            {
                Email = "speaker@example.com"
            };

            var submission = new Submission(speaker, new SubmissionViewModel {Title = "title"}, callForSpeakers)
            {
                RejectionReason = "rejection reason"
            };

            var sender = new DomainEmailSender(email);
            sender.SubmissionRejection(submission);

            emailMessage = (EmailMessage) email.GetArgumentsForCallsMadeOn(x => x.Send(null))[0][0];
        }

        [Test]
        public void Should_send_to_speaker()
        {
            emailMessage.To.Single().ShouldEqual("speaker@example.com");
        }

        [Test]
        public void Should_cc_organizer()
        {
            emailMessage.Cc.Single().ShouldEqual("organizer@example.com");
        }

        [Test]
        public void Should_leave_from_null()
        {
            emailMessage.From.ShouldBeNull();
        }

        [Test]
        public void Should_set_subject()
        {
            emailMessage.Subject.ShouldEqual("Your submission to event");   
        }

        [Test]
        public void Should_set_text()
        {
            emailMessage.Text.ShouldEqual("Your submission \"title\" has been rejected by the organizer: rejection reason");
        }
    }
}

