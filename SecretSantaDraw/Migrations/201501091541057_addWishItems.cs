namespace SecretSantaDraw.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addWishItems : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WishItem",
                c => new
                    {
                        WishItemId = c.Int(nullable: false, identity: true),
                        ProfileId = c.Int(nullable: false),
                        Name = c.String(maxLength: 60),
                        Description = c.String(maxLength: 200),
                        DesireLevel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WishItemId)
                .ForeignKey("dbo.Profile", t => t.ProfileId, cascadeDelete: true)
                .Index(t => t.ProfileId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.WishItem", new[] { "ProfileId" });
            DropForeignKey("dbo.WishItem", "ProfileId", "dbo.Profile");
            DropTable("dbo.WishItem");
        }
    }
}
