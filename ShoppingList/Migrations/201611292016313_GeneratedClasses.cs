namespace ShoppingList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GeneratedClasses : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.KrogerProducts", "imageUrl", c => c.String());
            AddColumn("dbo.KrogerProducts", "soldBy", c => c.String());
            AddColumn("dbo.KrogerProducts", "orderBy", c => c.String());
            AddColumn("dbo.KrogerProducts", "priceSizingDescription", c => c.String());
            AddColumn("dbo.KrogerProducts", "currentPriceIsYellowTag", c => c.Boolean(nullable: false));
            DropColumn("dbo.KrogerProducts", "offerQuantity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.KrogerProducts", "offerQuantity", c => c.Int(nullable: false));
            DropColumn("dbo.KrogerProducts", "currentPriceIsYellowTag");
            DropColumn("dbo.KrogerProducts", "priceSizingDescription");
            DropColumn("dbo.KrogerProducts", "orderBy");
            DropColumn("dbo.KrogerProducts", "soldBy");
            DropColumn("dbo.KrogerProducts", "imageUrl");
        }
    }
}
