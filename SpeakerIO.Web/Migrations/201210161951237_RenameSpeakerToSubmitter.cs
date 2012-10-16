namespace SpeakerIO.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameSpeakerToSubmitter : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Submissions", "Speaker_Id", "dbo.Users");
            DropIndex("dbo.Submissions", new[] { "Speaker_Id" });
            AddColumn("dbo.Submissions", "Submitter_Id", c => c.Long(nullable: false));
            AddForeignKey("dbo.Submissions", "Submitter_Id", "dbo.Users", "Id", cascadeDelete: true);
            CreateIndex("dbo.Submissions", "Submitter_Id");
            DropColumn("dbo.Submissions", "Speaker_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Submissions", "Speaker_Id", c => c.Long(nullable: false));
            DropIndex("dbo.Submissions", new[] { "Submitter_Id" });
            DropForeignKey("dbo.Submissions", "Submitter_Id", "dbo.Users");
            DropColumn("dbo.Submissions", "Submitter_Id");
            CreateIndex("dbo.Submissions", "Speaker_Id");
            AddForeignKey("dbo.Submissions", "Speaker_Id", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
