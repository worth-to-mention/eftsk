namespace EFTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPaymentHierarchy : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CreditCardPayments",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        CardNumber = c.String(maxLength: 16),
                        ValidityPeriod_Month = c.Int(nullable: false),
                        ValidityPeriod_Year = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Payments", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.CashPayments",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Payments", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.PayPalPayments",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Account = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Payments", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.WebMoneyPayments",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        EWAlletNumber = c.String(maxLength: 12),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Payments", t => t.ID)
                .Index(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WebMoneyPayments", "ID", "dbo.Payments");
            DropForeignKey("dbo.PayPalPayments", "ID", "dbo.Payments");
            DropForeignKey("dbo.CashPayments", "ID", "dbo.Payments");
            DropForeignKey("dbo.CreditCardPayments", "ID", "dbo.Payments");
            DropIndex("dbo.WebMoneyPayments", new[] { "ID" });
            DropIndex("dbo.PayPalPayments", new[] { "ID" });
            DropIndex("dbo.CashPayments", new[] { "ID" });
            DropIndex("dbo.CreditCardPayments", new[] { "ID" });
            DropTable("dbo.WebMoneyPayments");
            DropTable("dbo.PayPalPayments");
            DropTable("dbo.CashPayments");
            DropTable("dbo.CreditCardPayments");
        }
    }
}
