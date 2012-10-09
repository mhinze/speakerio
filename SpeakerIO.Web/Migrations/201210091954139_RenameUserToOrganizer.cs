namespace SpeakerIO.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameUserToOrganizer : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CallForSpeakers", "User_Id", "dbo.Users");
            DropIndex("dbo.CallForSpeakers", new[] { "User_Id" });
            AddColumn("dbo.CallForSpeakers", "Organizer_Id", c => c.Long());
            AddForeignKey("dbo.CallForSpeakers", "Organizer_Id", "dbo.Users", "Id");
            CreateIndex("dbo.CallForSpeakers", "Organizer_Id");
            DropColumn("dbo.CallForSpeakers", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CallForSpeakers", "User_Id", c => c.Long());
            DropIndex("dbo.CallForSpeakers", new[] { "Organizer_Id" });
            DropForeignKey("dbo.CallForSpeakers", "Organizer_Id", "dbo.Users");
            DropColumn("dbo.CallForSpeakers", "Organizer_Id");
            CreateIndex("dbo.CallForSpeakers", "User_Id");
            AddForeignKey("dbo.CallForSpeakers", "User_Id", "dbo.Users", "Id");
        }
    }
}
