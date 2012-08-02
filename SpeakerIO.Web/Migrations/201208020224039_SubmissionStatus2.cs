namespace SpeakerIO.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SubmissionStatus2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Submissions", "Status", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Submissions", "Status");
        }
    }
}
