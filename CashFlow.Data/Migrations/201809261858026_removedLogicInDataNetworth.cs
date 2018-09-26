namespace CashFlow.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedLogicInDataNetworth : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.NetWorth", "TotalAssets");
            DropColumn("dbo.NetWorth", "TotalLiabilities");
            DropColumn("dbo.NetWorth", "TotalNetWorth");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NetWorth", "TotalNetWorth", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.NetWorth", "TotalLiabilities", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.NetWorth", "TotalAssets", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
