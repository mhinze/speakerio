using System.Data;
using System.Data.Entity;
using SpeakerIO.Web.Data.Model;

namespace SpeakerIO.Web.Data
{
    public class DataContext : DbContext
    {
        public DataContext() {}

        // TODO: need to investigate context per request or something
        public DataContext(User modelBoundUser)
        {
            Entry(modelBoundUser).State = EntityState.Unchanged;
        }

        public DbSet<CallForSpeakers> CallsForSpeakers { get; set; }
        public DbSet<User> Users { get; set; }
    }
}