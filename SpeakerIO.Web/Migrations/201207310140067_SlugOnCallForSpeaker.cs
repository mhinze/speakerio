using System.Data.Entity.Migrations;

namespace SpeakerIO.Web.Migrations
{
    public partial class SlugOnCallForSpeaker : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CallForSpeakers", "Slug", c => c.String(nullable: false, maxLength: 40));
            DropColumn("dbo.CallForSpeakers", "UniqueUrlKey");
            DropIndex("dbo.CallForSpeakers", new[] { "UniqueUrlKey" });
            CreateIndex("dbo.CallForSpeakers", "Slug", unique: true);
        }

        public override void Down()
        {
            AddColumn("dbo.CallForSpeakers", "UniqueUrlKey", c => c.String(nullable: false, maxLength: 40));
            CreateIndex("dbo.CallForSpeakers", "UniqueUrlKey", unique: true);
            DropColumn("dbo.CallForSpeakers", "Slug");
        }
    }
}