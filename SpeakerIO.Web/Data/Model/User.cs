using System.ComponentModel.DataAnnotations;

namespace SpeakerIO.Web.Data.Model
{
    public class User : DataEntity
    {
        protected User() {}

        public User(string identifier)
        {
            Identifier = identifier;
        }

        [Required]
        public string Identifier { get; protected set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }
        public string Twitter { get; set; }
    }
}