using System;
using NUnit.Framework;
using SpeakerIO.Web.Areas.Organizer.Models;
using SpeakerIO.Web.Data.Model;
using Should;

namespace SpeakerIO.UnitTests.Areas.Organizer.Models
{
    [TestFixture]
    public class CallForSpeakersInputTests
    {
        [Test]
        public void Should_map_from_entity()
        {
            var user = new User("foo");

            var entity = new CallForSpeakers
            {
                Description = "description",
                EventName = "event name",
                FirstDayOfEvent = new DateTime(2001,1,2),
                Id = 123,
                LastDayOfEvent = new DateTime(2001,1,3),
                LastDayToSubmit = new DateTime(2001,1,4),
                LogoUrl = "logo url",
                Slug = "asdasd",
                User = user
            };

            var input = new CallForSpeakersInput(entity);
            input.Description.ShouldEqual(entity.Description);
            input.EventName.ShouldEqual(entity.EventName);
            input.FirstDayOfEvent.ShouldEqual(entity.FirstDayOfEvent);
            input.Id.ShouldEqual(entity.Id);
            input.LastDayOfEvent.ShouldEqual(entity.LastDayOfEvent);
            input.LastDayToSubmit.ShouldEqual(entity.LastDayToSubmit);
            input.LogoUrl.ShouldEqual(entity.LogoUrl);
        }
    }
}