namespace CashFlow.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedUpDataModels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Expense", "BudgetId", "dbo.Budget");
            DropIndex("dbo.Expense", new[] { "BudgetId" });
            RenameColumn(table: "dbo.Expense", name: "BudgetId", newName: "Budget_BudgetId");
            AlterColumn("dbo.Expense", "Budget_BudgetId", c => c.Int());
            CreateIndex("dbo.Expense", "Budget_BudgetId");
            AddForeignKey("dbo.Expense", "Budget_BudgetId", "dbo.Budget", "BudgetId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Expense", "Budget_BudgetId", "dbo.Budget");
            DropIndex("dbo.Expense", new[] { "Budget_BudgetId" });
            AlterColumn("dbo.Expense", "Budget_BudgetId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Expense", name: "Budget_BudgetId", newName: "BudgetId");
            CreateIndex("dbo.Expense", "BudgetId");
            AddForeignKey("dbo.Expense", "BudgetId", "dbo.Budget", "BudgetId", cascadeDelete: true);
        }
    }
}
