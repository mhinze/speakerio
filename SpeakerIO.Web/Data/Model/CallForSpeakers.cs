using System;
using System.ComponentModel.DataAnnotations;
using SpeakerIO.Web.Areas.Organizer.Models;

namespace SpeakerIO.Web.Data.Model
{
    public class CallForSpeakers : DataEntity
    {
        public CallForSpeakers() {}

        public CallForSpeakers(CallForSpeakersInput input)
        {
            LogoUrl = input.LogoUrl;
            EventName = input.EventName;
            Description = input.Description;

            FirstDayOfEventUtc = input.FirstDayOfEvent.GetValueOrDefault(new DateTime(1900, 1, 1));
            LastDayOfEventUtc = input.LastDayOfEvent.GetValueOrDefault(new DateTime(1900, 1, 1));
            LastDayToSubmitUtc = input.LastDayToSubmit.GetValueOrDefault(new DateTime(1900, 1, 1));
        }

        public CallForSpeakers(CallForSpeakersInput input, User user) : this(input)
        {
            User = user;
        }

        public User User { get; set; }

        public DateTime? LastDayToSubmitUtc { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string EventName { get; set; }

        public DateTime? FirstDayOfEventUtc { get; set; }

        public DateTime? LastDayOfEventUtc { get; set; }

        public string LogoUrl { get; set; }
    }
}