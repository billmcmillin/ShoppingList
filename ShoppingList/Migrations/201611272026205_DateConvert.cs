namespace ShoppingList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateConvert : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.KrogerProducts", "offerEndDate", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.KrogerProducts", "offerEndDate", c => c.DateTime(nullable: false));
        }
    }
}
