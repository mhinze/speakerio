namespace SpeakerIO.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SpeakerImageUrl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Submissions", "SpeakerImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Submissions", "SpeakerImageUrl");
        }
    }
}
