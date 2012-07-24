using System;
using NUnit.Framework;
using Should;
using SpeakerIO.Web.Areas.Organizer.Models;
using SpeakerIO.Web.Data.Model;

namespace SpeakerIO.UnitTests.Data.Model
{
    [TestFixture]
    public class CallForSpeakerTests
    {

        [Test]
        public void When_initializing_data_entity_from_user_input()
        {
            var input = new CallForSpeakersInput
            {
                Description = "description", EventName = "event name", LastDayToSubmit = new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), LogoUrl = "logo url"
            };

            var model = new CallForSpeakers(input);

            model.Description.ShouldEqual(input.Description);
            model.EventName.ShouldEqual(input.EventName);
            model.LastDayToSubmitUtc.ShouldEqual(input.LastDayToSubmit);
            model.LogoUrl.ShouldEqual(input.LogoUrl);
        }

        [Test]
        public void When_setting_last_day_to_submit()
        {
            var utcDate = new DateTime(2012, 12, 12, 12, 12, 12, 12, DateTimeKind.Utc);
            DateTime localDate = utcDate.ToLocalTime();

            var model = new CallForSpeakers();

            model.SetLastDayToSubmit(localDate);

            model.LastDayToSubmitUtc.Value.ShouldEqual(utcDate.Date);
        }

        [Test]
        public void When_setting_last_day_to_submit_nullable()
        {
            var utcDate = (DateTime?) new DateTime(2012, 12, 12, 12, 12, 12, 12, DateTimeKind.Utc);
            DateTime localDate = utcDate.Value.ToLocalTime();

            var model = new CallForSpeakers();

            model.SetLastDayToSubmit(localDate);

            model.LastDayToSubmitUtc.Value.ShouldEqual(utcDate.Value.Date);
        }

        [Test]
        public void When_setting_last_day_with_null()
        {
            var model = new CallForSpeakers();
            model.SetLastDayToSubmit(null);
            model.LastDayToSubmitUtc.ShouldBeNull();
        }
    }
}