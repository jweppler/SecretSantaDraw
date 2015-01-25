namespace SecretSantaDraw.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDraws : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Draw",
                c => new
                    {
                        DrawId = c.Int(nullable: false, identity: true),
                        DrawDate = c.DateTime(nullable: false),
                        SpendLimit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OwnerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DrawId)
                .ForeignKey("dbo.Profile", t => t.OwnerId, cascadeDelete: false)
                .Index(t => t.OwnerId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Draw", new[] { "OwnerId" });
            DropForeignKey("dbo.Draw", "OwnerId", "dbo.Profile");
            DropTable("dbo.Draw");
        }
    }
}
