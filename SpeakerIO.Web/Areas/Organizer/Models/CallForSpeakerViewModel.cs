using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SpeakerIO.Web.Areas.Organizer.Models
{
    public class CallForSpeakerViewModel
    {
        [Required]
        [DisplayName("Event Name")]
        public string EventName { get; set; }
        
        [Required]
        [DisplayName("Event Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public IEnumerable<DateTime> DaysOfEvent { get; set; }

        [DisplayName("Last Day To Submit")]
        public DateTime? LastDayToSubmit { get; set; }
        
        [DisplayName("Event Logo URL")]
        [DataType(DataType.Url)]
        public string LogoUrl { get; set; }
    }
}