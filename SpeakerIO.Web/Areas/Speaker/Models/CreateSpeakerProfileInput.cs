using System.ComponentModel.DataAnnotations;
using SpeakerIO.Web.Data.Model;

namespace SpeakerIO.Web.Areas.Speaker.Models
{
    public class CreateSpeakerProfileInput
    {
        public CreateSpeakerProfileInput() { }

        public CreateSpeakerProfileInput(SpeakerProfile profile)
        {
            Name = profile.Name;
            PhoneNumber = profile.PhoneNumber;
            Twitter = profile.Twitter;
            Bio = profile.Bio;
            ImageUrl = profile.ImageUrl;
            HomePageUrl = profile.HomePageUrl;
            Email = profile.Email;
        }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.MultilineText)]
        public string Bio { get; set; }

        [DataType(DataType.Url)]
        [Display(Name = "Home Page URL")]
        public string HomePageUrl { get; set; }

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        
        public string Twitter { get; set; }
    }
}