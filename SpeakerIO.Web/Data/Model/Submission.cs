using System.ComponentModel.DataAnnotations;
using SpeakerIO.Web.Areas.Speaker.Models;

namespace SpeakerIO.Web.Data.Model
{
    public class Submission : DataEntity
    {
        public Submission(User speaker, SubmissionViewModel input, CallForSpeakers callForSpeakers)
        {
            Speaker = speaker;
            CallForSpeakers = callForSpeakers;
            Title = input.Title;
            Abstract = input.Abstract;
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
    }
}