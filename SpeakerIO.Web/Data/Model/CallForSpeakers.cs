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
            SetLastDayToSubmit(input.LastDayToSubmit);
        }

        public CallForSpeakers(CallForSpeakersInput input, User user) : this(input)
        {
            User = user;
        }

        public User User { get; set; }

        public DateTime? LastDayToSubmitUtc { get; protected set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string EventName { get; set; }

        public string LogoUrl { get; set; }

        public void SetLastDayToSubmit(DateTime? date)
        {
            LastDayToSubmitUtc = date.HasValue ? (DateTime?) date.Value.ToUniversalTime().Date : null;
        }

        public void SetLastDayToSubmit(DateTime date)
        {
            LastDayToSubmitUtc = date.ToUniversalTime().Date;
        }
    }
}