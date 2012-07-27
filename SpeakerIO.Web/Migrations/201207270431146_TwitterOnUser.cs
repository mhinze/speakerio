namespace SpeakerIO.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TwitterOnUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Twitter", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Twitter");
        }
    }
}
