namespace CashFlow.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedDbModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NetWorth", "TotalAssets", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.NetWorth", "TotalLiabilities", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.NetWorth", "TotalNetWorth", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.NetWorth", "TotalNetWorth");
            DropColumn("dbo.NetWorth", "TotalLiabilities");
            DropColumn("dbo.NetWorth", "TotalAssets");
        }
    }
}
