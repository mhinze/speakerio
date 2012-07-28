namespace SpeakerIO.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PuntOnUtc2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CallForSpeakers", "LastDayToSubmit", c => c.DateTime());
            AddColumn("dbo.CallForSpeakers", "FirstDayOfEvent", c => c.DateTime());
            AddColumn("dbo.CallForSpeakers", "LastDayOfEvent", c => c.DateTime());
            DropColumn("dbo.CallForSpeakers", "LastDayToSubmitUtc");
            DropColumn("dbo.CallForSpeakers", "FirstDayOfEventUtc");
            DropColumn("dbo.CallForSpeakers", "LastDayOfEventUtc");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CallForSpeakers", "LastDayOfEventUtc", c => c.DateTime());
            AddColumn("dbo.CallForSpeakers", "FirstDayOfEventUtc", c => c.DateTime());
            AddColumn("dbo.CallForSpeakers", "LastDayToSubmitUtc", c => c.DateTime());
            DropColumn("dbo.CallForSpeakers", "LastDayOfEvent");
            DropColumn("dbo.CallForSpeakers", "FirstDayOfEvent");
            DropColumn("dbo.CallForSpeakers", "LastDayToSubmit");
        }
    }
}
