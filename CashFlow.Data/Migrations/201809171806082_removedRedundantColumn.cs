namespace CashFlow.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedRedundantColumn : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.NetWorth", "EstimatedIncome");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NetWorth", "EstimatedIncome", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
