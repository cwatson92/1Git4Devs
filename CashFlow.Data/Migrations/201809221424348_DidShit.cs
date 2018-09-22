namespace CashFlow.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DidShit : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Expense", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Expense", "Name", c => c.String());
        }
    }
}
