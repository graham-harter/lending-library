namespace LendingLibrary.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial_migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Medium",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Title",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MediumId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 200),
                        Subtitle = c.String(maxLength: 300),
                        Author = c.String(nullable: false, maxLength: 200),
                        Publisher = c.String(nullable: false, maxLength: 50),
                        Year = c.Short(),
                        ImageURL = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Medium", t => t.MediumId)
                .Index(t => t.MediumId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Title", "MediumId", "dbo.Medium");
            DropIndex("dbo.Title", new[] { "MediumId" });
            DropTable("dbo.Title");
            DropTable("dbo.Medium");
        }
    }
}
