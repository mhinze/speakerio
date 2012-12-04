namespace SpeakerIO.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialSpeakerProfile : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SpeakerProfiles",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Twitter = c.String(),
                        PhoneNumber = c.String(),
                        Bio = c.String(),
                        ImageUrl = c.String(),
                        HomePageUrl = c.String(),
                        Maintainer_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Maintainer_Id)
                .Index(t => t.Maintainer_Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.SpeakerProfiles", new[] { "Maintainer_Id" });
            DropForeignKey("dbo.SpeakerProfiles", "Maintainer_Id", "dbo.Users");
            DropTable("dbo.SpeakerProfiles");
        }
    }
}
