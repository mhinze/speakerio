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
        public void Should_generate_unique_url_key()
        {
            var input = new CallForSpeakersInput
            {
                Description = "description",
                EventName = "event name",
                LastDayToSubmit = new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                FirstDayOfEvent = new DateTime(2001, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                LastDayOfEvent = new DateTime(2001, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                LogoUrl = "logo url"
            };

            var call = new CallForSpeakers(input);

            call.UniqueUrlKey.ShouldEqual("event-name-2001-02-01");
        }

        [Test]
        public void When_initializing_data_entity_from_user_input()
        {
            var input = new CallForSpeakersInput
            {
                Description = "description",
                EventName = "event name",
                LastDayToSubmit = new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                FirstDayOfEvent = new DateTime(2001, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                LastDayOfEvent = new DateTime(2001, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                LogoUrl = "logo url"
            };

            var model = new CallForSpeakers(input);

            model.Description.ShouldEqual(input.Description);
            model.EventName.ShouldEqual(input.EventName);
            model.LastDayToSubmit.ShouldEqual(input.LastDayToSubmit);
            model.FirstDayOfEvent.ShouldEqual(input.FirstDayOfEvent);
            model.LastDayOfEvent.ShouldEqual(input.LastDayOfEvent);
            model.LogoUrl.ShouldEqual(input.LogoUrl);
        }
    }
}