namespace Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class REALTIONSHIPBETWEENTABLESADDEDANDCREATED : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Catagories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        PublishDate = c.DateTime(nullable: false),
                        CatId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Catagories", t => t.CatId, cascadeDelete: false)
                .Index(t => t.CatId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.News", "CatId", "dbo.Catagories");
            DropIndex("dbo.News", new[] { "CatId" });
            DropTable("dbo.News");
            DropTable("dbo.Catagories");
        }
    }
}
