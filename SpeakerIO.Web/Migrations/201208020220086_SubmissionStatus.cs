namespace SpeakerIO.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SubmissionStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Submissions", "RejectionReason", c => c.String());
            AlterColumn("dbo.CallForSpeakers", "Slug", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CallForSpeakers", "Slug", c => c.String(nullable: false, maxLength: 40));
            DropColumn("dbo.Submissions", "RejectionReason");
        }
    }
}
