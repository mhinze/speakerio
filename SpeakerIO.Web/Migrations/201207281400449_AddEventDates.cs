using System.Data.Entity.Migrations;

namespace SpeakerIO.Web.Migrations
{
    public partial class AddEventDates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CallForSpeakers", "FirstDayOfEventUtc", c => c.DateTime(nullable: false));
            AddColumn("dbo.CallForSpeakers", "LastDayOfEventUtc", c => c.DateTime(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.CallForSpeakers", "LastDayOfEventUtc");
            DropColumn("dbo.CallForSpeakers", "FirstDayOfEvent");
        }
    }
}