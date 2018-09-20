namespace CashFlow.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changingShit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Expense", "OwnerId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Expense", "OwnerId");
        }
    }
}
