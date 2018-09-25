namespace CashFlow.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedPropsToBudget : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Expense", "Budget_BudgetId", "dbo.Budget");
            DropIndex("dbo.Expense", new[] { "Budget_BudgetId" });
            AddColumn("dbo.Budget", "EstimatedAvailableBalance", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Budget", "SavingsAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Expense", "Budget_BudgetId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Expense", "Budget_BudgetId", c => c.Int());
            DropColumn("dbo.Budget", "SavingsAmount");
            DropColumn("dbo.Budget", "EstimatedAvailableBalance");
            CreateIndex("dbo.Expense", "Budget_BudgetId");
            AddForeignKey("dbo.Expense", "Budget_BudgetId", "dbo.Budget", "BudgetId");
        }
    }
}
