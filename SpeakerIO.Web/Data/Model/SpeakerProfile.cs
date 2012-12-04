using System.ComponentModel.DataAnnotations;
using SpeakerIO.Web.Areas.Speaker.Models;

namespace SpeakerIO.Web.Data.Model
{
    public class SpeakerProfile : DataEntity
    {
        public SpeakerProfile() { }

        public SpeakerProfile(CreateSpeakerProfileInput input, User user)
        {
            Maintainer = user;
            Name = input.Name;
            Email = input.Email;
            Twitter = input.Twitter;
            PhoneNumber = input.PhoneNumber;
            Bio = input.Bio;
            ImageUrl = input.ImageUrl;
            HomePageUrl = input.HomePageUrl;
        }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string Tag { get; set; }

        public string Twitter { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [DataType(DataType.MultilineText)]
        public string Bio { get; set; }

        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }

        [DataType(DataType.Url)]
        public string HomePageUrl { get; set; }

        public User Maintainer { get; set; }
    }
}