using System;
using SpeakerIO.Web.Areas.Organizer.Models;

namespace SpeakerIO.Web.Data.Model
{
    public class CallForSpeaker : DataEntity
    {
        public CallForSpeaker() {}

        public CallForSpeaker(CallForSpeakerInput input)
        {
            LogoUrl = input.LogoUrl;
            Name = input.EventName;
            Description = input.Description;
            SetLastDayToSubmit(input.LastDayToSubmit);
        }

        public DateTime? LastDayToSubmitUtc { get; protected set; }
        public string Description { get; set; }
        public string Name { get; set; }
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