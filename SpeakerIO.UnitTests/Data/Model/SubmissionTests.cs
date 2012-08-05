using NUnit.Framework;
using Rhino.Mocks;
using Should;
using SpeakerIO.Web.Application.Email;
using SpeakerIO.Web.Areas.Speaker.Models;
using SpeakerIO.Web.Data.Model;

namespace SpeakerIO.UnitTests.Data.Model
{
    [TestFixture]
    public class SubmissionTests : TestBase
    {
        [Test]
        public void When_accepting_a_submission()
        {
            var sub = new Submission(new User("foo"), new SubmissionViewModel(), new CallForSpeakers());
            var domainEmailSender = S<IDomainEmailSender>();
            sub.Status.ShouldEqual(Submission.Submitted);

            sub.Accept(domainEmailSender);

            sub.Status.ShouldEqual(Submission.Accepted);
            domainEmailSender.AssertWasCalled(x => x.SubmissionAcceptance(sub));
        }

        [Test]
        public void When_rejecting_a_submission()
        {
            var sub = new Submission(new User("foo"), new SubmissionViewModel(), new CallForSpeakers());
            var domainEmailSender = S<IDomainEmailSender>();
            sub.Status.ShouldEqual(Submission.Submitted);

            sub.Reject("reason", domainEmailSender);

            sub.RejectionReason.ShouldEqual("reason");
            sub.Status.ShouldEqual(Submission.Rejected);
            domainEmailSender.AssertWasCalled(x => x.SubmissionRejection(sub));
        }
    }
}