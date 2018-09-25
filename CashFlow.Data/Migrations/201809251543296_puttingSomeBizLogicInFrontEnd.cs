namespace CashFlow.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class puttingSomeBizLogicInFrontEnd : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Budget", "AvailableBalance");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Budget", "AvailableBalance", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
