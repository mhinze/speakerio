namespace SpeakerIO.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UniqueUrlKeyOnCallForSpeaker : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CallForSpeakers", "UniqueUrlKey", c => c.String(nullable: false, maxLength: 40));
            CreateIndex("dbo.CallForSpeakers", "UniqueUrlKey", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.CallForSpeakers", new[]{"UniqueUrlKey"});
            DropColumn("dbo.CallForSpeakers", "UniqueUrlKey");
        }
    }
}
