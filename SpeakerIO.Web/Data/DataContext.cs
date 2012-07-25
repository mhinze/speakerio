using System.Data.Entity;
using SpeakerIO.Web.Data.Model;

namespace SpeakerIO.Web.Data
{
    public class DataContext : DbContext
    {
        public DbSet<CallForSpeakers> CallsForSpeakers { get; set; }
        public DbSet<User> Users { get; set; }
    }
}