namespace CashFlow.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedDbSetToIdentityModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Budget",
                c => new
                    {
                        BudgetId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        MonthlyIncome = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AvailableBalance = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.BudgetId);
            
            CreateTable(
                "dbo.Expense",
                c => new
                    {
                        ExpenseId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        Budget_BudgetId = c.Int(),
                    })
                .PrimaryKey(t => t.ExpenseId)
                .ForeignKey("dbo.Budget", t => t.Budget_BudgetId)
                .Index(t => t.Budget_BudgetId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Expense", "Budget_BudgetId", "dbo.Budget");
            DropIndex("dbo.Expense", new[] { "Budget_BudgetId" });
            DropTable("dbo.Expense");
            DropTable("dbo.Budget");
        }
    }
}
