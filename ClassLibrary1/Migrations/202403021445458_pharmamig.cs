namespace ClassLibrary1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pharmamig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        CartId = c.Int(nullable: false, identity: true),
                        MedicineId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Mtype = c.String(),
                    })
                .PrimaryKey(t => t.CartId)
                .ForeignKey("dbo.Medicines", t => t.MedicineId, cascadeDelete: true)
                .Index(t => t.MedicineId);
            
            CreateTable(
                "dbo.Medicines",
                c => new
                    {
                        MedicineId = c.Int(nullable: false, identity: true),
                        MName = c.String(),
                        MType = c.String(),
                        Price = c.Double(nullable: false),
                        stock = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MedicineId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Address = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        IsFirstOrder = c.Boolean(nullable: false),
                        IsRegularCustomer = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        MedicineId = c.Int(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        Amount = c.Int(nullable: false),
                        OrderCost = c.Double(nullable: false),
                        IsFirstOrderDiscountApplied = c.Boolean(nullable: false),
                        IsRegularCustomerDiscountApplied = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Medicines", t => t.MedicineId, cascadeDelete: true)
                .Index(t => t.MedicineId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "MedicineId", "dbo.Medicines");
            DropForeignKey("dbo.Carts", "MedicineId", "dbo.Medicines");
            DropIndex("dbo.Orders", new[] { "MedicineId" });
            DropIndex("dbo.Carts", new[] { "MedicineId" });
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
            DropTable("dbo.Medicines");
            DropTable("dbo.Carts");
            DropTable("dbo.Admins");
        }
    }
}
