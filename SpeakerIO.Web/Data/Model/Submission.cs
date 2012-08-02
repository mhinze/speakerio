using System.ComponentModel.DataAnnotations;
using SpeakerIO.Web.Areas.Speaker.Models;

namespace SpeakerIO.Web.Data.Model
{
    public class Submission : DataEntity
    {
        const string Submitted = "Submitted";
        const string Rejected = "Rejected";
        const string Accepted = "Accepted";

        public Submission(User speaker, SubmissionViewModel input, CallForSpeakers callForSpeakers)
        {
            Speaker = speaker;
            CallForSpeakers = callForSpeakers;
            Title = input.Title;
            Abstract = input.Abstract;
            Status = Submitted;
        }

        protected Submission() {}

        [Required]
        public User Speaker { get; set; }

        [Required]
        public CallForSpeakers CallForSpeakers { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Abstract { get; set; }

        [Required]
        public string Status { get; protected set; }

        public string RejectionReason { get; set; }

        public void Reject(string reason)
        {
            Status = Rejected;
            RejectionReason = reason;
        }

        public bool CanAccept()
        {
            return Status == Submitted;
        }

        public bool CanReject()
        {
            return Status == Submitted;
        }

        public void Accept()
        {
            Status = Accepted;
        }
    }
}