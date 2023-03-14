namespace FirstAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Plant : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Details",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Kind = c.Boolean(nullable: false),
                        treeNameId = c.Byte(nullable: false),
                        diseaseId = c.Byte(nullable: false),
                        imagePath = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Diseases", t => t.diseaseId, cascadeDelete: true)
                .ForeignKey("dbo.treeNames", t => t.treeNameId, cascadeDelete: true)
                .Index(t => t.treeNameId)
                .Index(t => t.diseaseId);
            
            CreateTable(
                "dbo.Diseases",
                c => new
                    {
                        Id = c.Byte(nullable: false, identity: true),
                        Name = c.String(),
                        kindDisease = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.treeNames",
                c => new
                    {
                        Id = c.Byte(nullable: false, identity: true),
                        Name = c.String(),
                        treeKind = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Details", "treeNameId", "dbo.treeNames");
            DropForeignKey("dbo.Details", "diseaseId", "dbo.Diseases");
            DropIndex("dbo.Details", new[] { "diseaseId" });
            DropIndex("dbo.Details", new[] { "treeNameId" });
            DropTable("dbo.treeNames");
            DropTable("dbo.Diseases");
            DropTable("dbo.Details");
        }
    }
}
