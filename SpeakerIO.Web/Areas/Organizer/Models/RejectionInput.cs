using System.ComponentModel.DataAnnotations;

namespace SpeakerIO.Web.Areas.Organizer.Models
{
    public class RejectionInput : DecisionInput
    {
        [Required]
        public string Reason { get; set; }
    }
}