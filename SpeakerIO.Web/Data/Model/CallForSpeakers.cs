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
            EventName = input.EventName;
            UpdateFrom(input);
            SetSlug(input);
        }

        public CallForSpeakers(CallForSpeakersInput input, User user) : this(input)
        {
            Organizer = user;
        }

        public User Organizer { get; set; }

        public DateTime? LastDayToSubmit { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string EventName { get; set; }

        public DateTime? FirstDayOfEvent { get; set; }

        public DateTime? LastDayOfEvent { get; set; }

        public string LogoUrl { get; set; }

        [Required]
        [StringLength(100)]
        public string Slug { get; set; }

        void SetSlug(CallForSpeakersInput input)
        {
            var eventKey = (input.EventName ?? string.Empty).ToLower().Replace(' ', '-');
            if (eventKey.Length > 26)
            {
                eventKey = eventKey.Substring(0, 26);
            }
            var dateKey = FirstDayOfEvent == null ? "" : FirstDayOfEvent.Value.ToString("-yyyy-MM-dd");
            Slug = string.Format("{0}{1}", eventKey, dateKey);
        }

        public void UpdateFrom(CallForSpeakersInput input)
        {
            LogoUrl = input.LogoUrl;
            Description = input.Description;

            FirstDayOfEvent = input.FirstDayOfEvent;
            LastDayOfEvent = input.LastDayOfEvent;
            LastDayToSubmit = input.LastDayToSubmit;
        }
    }
}