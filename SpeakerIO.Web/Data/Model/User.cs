namespace SpeakerIO.Web.Data.Model
{
    public class User : DataEntity<string>
    {
        protected User() {}

        public User(string id)
        {
            Id = id;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }
    }
}