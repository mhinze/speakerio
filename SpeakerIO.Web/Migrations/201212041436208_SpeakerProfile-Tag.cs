namespace SpeakerIO.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SpeakerProfileTag : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SpeakerProfiles", "Tag", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SpeakerProfiles", "Tag");
        }
    }
}
