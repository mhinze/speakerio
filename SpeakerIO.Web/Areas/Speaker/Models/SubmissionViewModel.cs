using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using SpeakerIO.Web.Data.Model;

namespace SpeakerIO.Web.Areas.Speaker.Models
{
    public class SubmissionViewModel
    {
        public SubmissionViewModel() {}

        public SubmissionViewModel(CallForSpeakers callForSpeakers)
        {
            CallForSpeakers = callForSpeakers;
            CallForSpeakersId = callForSpeakers.Id;
        }

        [HiddenInput(DisplayValue = false)]
        public long CallForSpeakersId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Abstract { get; set; }

        public CallForSpeakers CallForSpeakers { get; private set; }
    }
}