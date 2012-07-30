namespace SpeakerIO.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialSubmission : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Submissions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Abstract = c.String(nullable: false),
                        Speaker_Id = c.Long(nullable: false),
                        CallForSpeakers_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Speaker_Id, cascadeDelete: true)
                .ForeignKey("dbo.CallForSpeakers", t => t.CallForSpeakers_Id, cascadeDelete: true)
                .Index(t => t.Speaker_Id)
                .Index(t => t.CallForSpeakers_Id);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Submissions", new[] { "CallForSpeakers_Id" });
            DropIndex("dbo.Submissions", new[] { "Speaker_Id" });
            DropForeignKey("dbo.Submissions", "CallForSpeakers_Id", "dbo.CallForSpeakers");
            DropForeignKey("dbo.Submissions", "Speaker_Id", "dbo.Users");
            DropTable("dbo.Submissions");
        }
    }
}
