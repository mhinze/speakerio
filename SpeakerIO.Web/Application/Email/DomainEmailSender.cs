using SpeakerIO.Web.Data.Model;

namespace SpeakerIO.Web.Application.Email
{
    public class DomainEmailSender : IDomainEmailSender
    {
        readonly IEmailService _emailService;

        public DomainEmailSender(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public void SubmissionRejection(Submission submission)
        {
            var msg = new EmailMessage
            {
                To = new[] { submission.Submitter.Email },
                Subject = "Your submission to " + submission.CallForSpeakers.EventName,
                Cc = new[] { submission.CallForSpeakers.Organizer.Email },
                Text = string.Format("Your submission \"{0}\" has been rejected by the organizer: {1}", submission.Title, submission.RejectionReason)
            };

            _emailService.Send(msg);
        }

        public void SubmissionAcceptance(Submission submission)
        {
            var msg = new EmailMessage
            {
                To = new[] { submission.Submitter.Email },
                Subject = "Your submission to " + submission.CallForSpeakers.EventName,
                Cc = new[] { submission.CallForSpeakers.Organizer.Email },
                Text = string.Format("Congratulations! Your submission \"{0}\" has been accepted!", submission.Title)
            };

            _emailService.Send(msg);
        }
    }
}