using System.ComponentModel.DataAnnotations;

namespace SpeakerIO.Web.Data.Model
{
    public class Submission : DataEntity
    {
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