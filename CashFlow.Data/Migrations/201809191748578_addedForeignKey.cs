namespace CashFlow.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedForeignKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Expense", "Budget_BudgetId", "dbo.Budget");
            DropIndex("dbo.Expense", new[] { "Budget_BudgetId" });
            RenameColumn(table: "dbo.Expense", name: "Budget_BudgetId", newName: "BudgetId");
            AlterColumn("dbo.Expense", "BudgetId", c => c.Int(nullable: false));
            CreateIndex("dbo.Expense", "BudgetId");
            AddForeignKey("dbo.Expense", "BudgetId", "dbo.Budget", "BudgetId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Expense", "BudgetId", "dbo.Budget");
            DropIndex("dbo.Expense", new[] { "BudgetId" });
            AlterColumn("dbo.Expense", "BudgetId", c => c.Int());
            RenameColumn(table: "dbo.Expense", name: "BudgetId", newName: "Budget_BudgetId");
            CreateIndex("dbo.Expense", "Budget_BudgetId");
            AddForeignKey("dbo.Expense", "Budget_BudgetId", "dbo.Budget", "BudgetId");
        }
    }
}
