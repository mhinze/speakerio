using System.ComponentModel.DataAnnotations;
using SpeakerIO.Web.Data.Model;

namespace SpeakerIO.Web.Models
{
    public class UserDetailsInput
    {
        public UserDetailsInput() {}

        public UserDetailsInput(User user)
        {
            Name = user.Name;
            EmailAddress = user.Email;
        }

        [Required]
        public string Name { get; set; }

        [Required, DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        public string Twitter { get; set; }
    }
}