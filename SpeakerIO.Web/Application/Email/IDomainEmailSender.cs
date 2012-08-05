using SpeakerIO.Web.Data.Model;

namespace SpeakerIO.Web.Application.Email
{
    public interface IDomainEmailSender
    {
        void SubmissionRejection(Submission submission);
        void SubmissionAcceptance(Submission submission);
    }
}