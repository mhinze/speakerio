using System.Data.Entity.Migrations;

namespace SpeakerIO.Web.Migrations
{
    public partial class SurrogateKeyOnUser : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Users");
            CreateTable(
                        "dbo.Users",
                        c => new
                        {
                            Id = c.Long(nullable: false, identity: true),
                            Identifier = c.String(nullable: false, maxLength:256),
                            Name = c.String(),
                            Email = c.String(),
                            ImageUrl = c.String(),
                        })
                .PrimaryKey(t => t.Id);
            CreateIndex("dbo.Users", "Identifier", unique: true);
        }

        public override void Down()
        {
            DropTable("dbo.Users");
            CreateTable(
                        "dbo.Users",
                        c => new
                        {
                            Id = c.String(nullable: false, maxLength: 128),
                            Name = c.String(),
                            Email = c.String(),
                            ImageUrl = c.String(),
                        })
                .PrimaryKey(t => t.Id);
        }
    }
}