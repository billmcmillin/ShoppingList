namespace ShoppingList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Stringify : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.KrogerProducts", "upc", c => c.String());
            AlterColumn("dbo.KrogerProducts", "regularPrice", c => c.String());
            AlterColumn("dbo.KrogerProducts", "salePrice", c => c.String());
            AlterColumn("dbo.KrogerProducts", "offerPrice", c => c.String());
            AlterColumn("dbo.KrogerProducts", "currentPrice", c => c.String());
            DropColumn("dbo.KrogerProducts", "offerType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.KrogerProducts", "offerType", c => c.String());
            AlterColumn("dbo.KrogerProducts", "currentPrice", c => c.Double(nullable: false));
            AlterColumn("dbo.KrogerProducts", "offerPrice", c => c.Double(nullable: false));
            AlterColumn("dbo.KrogerProducts", "salePrice", c => c.Double(nullable: false));
            AlterColumn("dbo.KrogerProducts", "regularPrice", c => c.Double(nullable: false));
            DropColumn("dbo.KrogerProducts", "upc");
        }
    }
}
