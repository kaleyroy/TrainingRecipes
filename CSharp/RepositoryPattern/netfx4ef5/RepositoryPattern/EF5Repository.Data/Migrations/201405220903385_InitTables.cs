namespace EF5Repository.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        CategoryName = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        ProductName = c.String(),
                        QuantityPerUnit = c.String(),
                        UnitPrice = c.Decimal(precision: 18, scale: 2),
                        UnitsInStock = c.Int(nullable: false),
                        UnitsOnOrder = c.Int(nullable: false),
                        Discontinued = c.Boolean(nullable: false),
                        CategoryID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Category", t => t.CategoryID)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.OrderDetail",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        Discount = c.Single(nullable: false),
                        OrderID = c.Guid(),
                        ProductID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Order", t => t.OrderID)
                .ForeignKey("dbo.Product", t => t.ProductID)
                .Index(t => t.OrderID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        CustomerID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customer", t => t.CustomerID)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        Region = c.String(),
                        PostalCode = c.String(),
                        Country = c.String(),
                        Phone = c.String(),
                        Fax = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Order", new[] { "CustomerID" });
            DropIndex("dbo.OrderDetail", new[] { "ProductID" });
            DropIndex("dbo.OrderDetail", new[] { "OrderID" });
            DropIndex("dbo.Product", new[] { "CategoryID" });
            DropForeignKey("dbo.Order", "CustomerID", "dbo.Customer");
            DropForeignKey("dbo.OrderDetail", "ProductID", "dbo.Product");
            DropForeignKey("dbo.OrderDetail", "OrderID", "dbo.Order");
            DropForeignKey("dbo.Product", "CategoryID", "dbo.Category");
            DropTable("dbo.Customer");
            DropTable("dbo.Order");
            DropTable("dbo.OrderDetail");
            DropTable("dbo.Product");
            DropTable("dbo.Category");
        }
    }
}
