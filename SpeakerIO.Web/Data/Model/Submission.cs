using System.ComponentModel.DataAnnotations;
using SpeakerIO.Web.Application.Email;
using SpeakerIO.Web.Areas.Speaker.Models;

namespace SpeakerIO.Web.Data.Model
{
    public class Submission : DataEntity
    {
        public const string Submitted = "Submitted";
        public const string Rejected = "Rejected";
        public const string Accepted = "Accepted";

        public Submission(User submitter, SubmissionViewModel input, CallForSpeakers callForSpeakers)
        {
            Submitter = submitter;
            CallForSpeakers = callForSpeakers;
            Title = input.Title;
            Abstract = input.Abstract;
            Status = Submitted;

            SpeakerName = input.SpeakerName;
            SpeakerBio = input.SpeakerBio;
            SpeakerEmail = input.SpeakerEmail;
            SpeakerPhone = input.SpeakerPhone;
            SpeakerTwitter = input.SpeakerTwitter;
            SpeakerImageUrl = input.SpeakerImageUrl;
        }

        protected Submission() { }

        [Required]
        public User Submitter { get; set; }

        [Required]
        public CallForSpeakers CallForSpeakers { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Abstract { get; set; }

        [Required]
        public string Status { get; protected set; }

        public string RejectionReason { get; set; }

        public string SpeakerName { get; set; }

        public string SpeakerBio { get; set; }

        public string SpeakerTwitter { get; set; }

        public string SpeakerEmail { get; set; }

        public string SpeakerPhone { get; set; }

        public string SpeakerImageUrl { get; set; }

        public void Reject(string reason, IDomainEmailSender email)
        {
            Status = Rejected;
            RejectionReason = reason;
            email.SubmissionRejection(this);
        }

        public bool CanAccept()
        {
            return Status == Submitted;
        }

        public bool CanReject()
        {
            return Status == Submitted;
        }

        public void Accept(IDomainEmailSender email)
        {
            Status = Accepted;
            email.SubmissionAcceptance(this);
        }
    }
}