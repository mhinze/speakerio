using System.Data.Entity.Migrations;

namespace SpeakerIO.Web.Migrations
{
    public partial class SlugOnCallForSpeaker : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CallForSpeakers", "Slug", c => c.String(nullable: false, maxLength: 40));
            DropIndex("dbo.CallForSpeakers", new[] { "UniqueUrlKey" });
            DropColumn("dbo.CallForSpeakers", "UniqueUrlKey");
            CreateIndex("dbo.CallForSpeakers", "Slug", unique: true);
        }

        public override void Down()
        {
            AddColumn("dbo.CallForSpeakers", "UniqueUrlKey", c => c.String(nullable: false, maxLength: 40));
            CreateIndex("dbo.CallForSpeakers", "UniqueUrlKey", unique: true);
            DropIndex("dbo.CallForSpeakers", new[] { "Slug" });
            DropColumn("dbo.CallForSpeakers", "Slug");
        }
    }
}