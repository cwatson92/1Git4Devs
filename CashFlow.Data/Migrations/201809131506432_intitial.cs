namespace CashFlow.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intitial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminUsers",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.NetWorth",
                c => new
                    {
                        NetWorthId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        SavingsAccount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CheckingAccount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MoneyMarketAccount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SavingsBonds = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CertificateOfDeposits = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IRA = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RothIRA = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Retirement401K = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SepIRA = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Pension = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Annuity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RealEstate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PrincipalHome = c.Decimal(nullable: false, precision: 18, scale: 2),
                        VacationHome = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CarsTrucksBoats = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HomeFurnishings = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OtherAssets = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalAssets = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreditCardBalance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EstimatedIncome = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EstimatedIncomeTaxOwed = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OtherOutstandingBills = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HomeMortgage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HomeEquityLoan = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MortgagesOnRentals = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CarLoans = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StudentLoans = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LifeInsurancePolicyLoans = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OtherLongTermDebt = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalLiabilities = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalNetWorth = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.NetWorthId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.RoleId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.UserInfo",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        LastFour = c.Int(nullable: false),
                        Username = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.UserInfo");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.NetWorth");
            DropTable("dbo.AdminUsers");
        }
    }
}
