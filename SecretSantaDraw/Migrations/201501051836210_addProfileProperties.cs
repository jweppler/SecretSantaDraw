namespace SecretSantaDraw.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addProfileProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Profile", "EmailAddress", c => c.String(nullable: false));
            AddColumn("dbo.Profile", "DOB", c => c.DateTime(nullable: false));
            AddColumn("dbo.Profile", "Gender", c => c.Int(nullable: false));
            AddColumn("dbo.Profile", "ShoeSize", c => c.Int(nullable: false));
            AlterColumn("dbo.Profile", "DisplayName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Profile", "DisplayName", c => c.String());
            DropColumn("dbo.Profile", "ShoeSize");
            DropColumn("dbo.Profile", "Gender");
            DropColumn("dbo.Profile", "DOB");
            DropColumn("dbo.Profile", "EmailAddress");
        }
    }
}
