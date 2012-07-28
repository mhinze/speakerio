namespace SpeakerIO.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PuntOnUtc : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CallForSpeakers", "FirstDayOfEventUtc", c => c.DateTime());
            AlterColumn("dbo.CallForSpeakers", "LastDayOfEventUtc", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CallForSpeakers", "LastDayOfEventUtc", c => c.DateTime(nullable: false));
            AlterColumn("dbo.CallForSpeakers", "FirstDayOfEventUtc", c => c.DateTime(nullable: false));
        }
    }
}
