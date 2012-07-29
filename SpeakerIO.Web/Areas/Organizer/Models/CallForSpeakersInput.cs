using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using SpeakerIO.Web.Data.Model;

namespace SpeakerIO.Web.Areas.Organizer.Models
{
    public class CallForSpeakersInput
    {
        public CallForSpeakersInput(CallForSpeakers found)
        {
            EventName = found.EventName;
            Description = found.Description;
            FirstDayOfEvent = found.FirstDayOfEvent;
            LastDayOfEvent = found.LastDayOfEvent;
            LastDayToSubmit = found.LastDayToSubmit;
            LogoUrl = found.LogoUrl;
            Id = found.Id;
        }

        public CallForSpeakersInput() {}

        [DisplayName("Event Name")]
        [Required]
        public string EventName { get; set; }
        
        [Required]
        [DisplayName("Event Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        [DisplayName("First Day Of Event")]
        [DataType(DataType.Date), DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? FirstDayOfEvent { get; set; }

        [Required]
        [DisplayName("Last Day Of Event")]
        [DataType(DataType.Date), DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? LastDayOfEvent { get; set; }
        
        [DisplayName("Last Day To Submit")]
        [DataType(DataType.Date), DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? LastDayToSubmit { get; set; }
        
        [DisplayName("Event Logo URL")]
        [DataType(DataType.ImageUrl)]
        public string LogoUrl { get; set; }

        [HiddenInput(DisplayValue = false)]
        public long? Id { get; set; }
    }



 
}