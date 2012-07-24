namespace SpeakerIO.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCallForSpeakers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CallForSpeakers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        LastDayToSubmitUtc = c.DateTime(),
                        Description = c.String(nullable: false),
                        EventName = c.String(nullable: false),
                        LogoUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CallForSpeakers");
        }
    }
}
