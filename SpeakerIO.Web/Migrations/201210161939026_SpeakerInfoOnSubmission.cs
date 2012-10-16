namespace SpeakerIO.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SpeakerInfoOnSubmission : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Submissions", "SpeakerName", c => c.String());
            AddColumn("dbo.Submissions", "SpeakerBio", c => c.String());
            AddColumn("dbo.Submissions", "SpeakerTwitter", c => c.String());
            AddColumn("dbo.Submissions", "SpeakerEmail", c => c.String());
            AddColumn("dbo.Submissions", "SpeakerPhone", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Submissions", "SpeakerPhone");
            DropColumn("dbo.Submissions", "SpeakerEmail");
            DropColumn("dbo.Submissions", "SpeakerTwitter");
            DropColumn("dbo.Submissions", "SpeakerBio");
            DropColumn("dbo.Submissions", "SpeakerName");
        }
    }
}
