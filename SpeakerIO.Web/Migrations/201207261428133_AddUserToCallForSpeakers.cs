namespace SpeakerIO.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserToCallForSpeakers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CallForSpeakers", "User_Id", c => c.Long());
            AddForeignKey("dbo.CallForSpeakers", "User_Id", "dbo.Users", "Id");
            CreateIndex("dbo.CallForSpeakers", "User_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.CallForSpeakers", new[] { "User_Id" });
            DropForeignKey("dbo.CallForSpeakers", "User_Id", "dbo.Users");
            DropColumn("dbo.CallForSpeakers", "User_Id");
        }
    }
}
