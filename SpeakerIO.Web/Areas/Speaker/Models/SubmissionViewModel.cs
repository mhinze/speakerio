using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using SpeakerIO.Web.Data.Model;

namespace SpeakerIO.Web.Areas.Speaker.Models
{
    public class SubmissionViewModel
    {
        public SubmissionViewModel() {}

        public SubmissionViewModel(User speaker, CallForSpeakers callForSpeakers)
        {
            CallForSpeakers = callForSpeakers;
            CallForSpeakersId = callForSpeakers.Id;

            SpeakerName = speaker.Name;
            SpeakerEmail = speaker.Email;
            SpeakerTwitter = speaker.Twitter;
            SpeakerImageUrl = speaker.ImageUrl;
        }

        [HiddenInput(DisplayValue = false)]
        public long CallForSpeakersId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Abstract { get; set; }

        [Required]
        [Display(Name = "Speaker Name")]
        public string SpeakerName { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Speaker Bio")]
        public string SpeakerBio { get; set; }

        [Display(Name = "Speaker Email")]
        public string SpeakerEmail { get; set; }

        [Display(Name = "Speaker Twitter")]
        public string SpeakerTwitter { get; set; }

        [Display(Name = "Speaker Phone")]
        public string SpeakerPhone { get; set; }

        [Display(Name = "Speaker Image Url")]
        public string SpeakerImageUrl { get; set; }

        public CallForSpeakers CallForSpeakers { get; private set; }
    }
}