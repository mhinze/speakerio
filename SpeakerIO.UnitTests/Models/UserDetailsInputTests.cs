using NUnit.Framework;
using SpeakerIO.Web.Data.Model;
using SpeakerIO.Web.Models;
using Should;

namespace SpeakerIO.UnitTests.Models
{
    [TestFixture]
    public class UserDetailsInputTests
    {
        [Test]
        public void Should_map_from_entity()
        {
            var entity = new User("foo")
            {
                Email = "email",
                Id = 2,
                Twitter = "twitter",
                ImageUrl = "image url",
                Name = "name"
            };

            var input = new UserDetailsInput(entity);

            input.EmailAddress.ShouldEqual(entity.Email);
            input.Name.ShouldEqual(entity.Name);
            input.Twitter.ShouldEqual(entity.Twitter);
        }
    }
}