namespace FirstAppRecall.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitalData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        BrandID = c.Int(nullable: false, identity: true),
                        BrandName = c.String(),
                    })
                .PrimaryKey(t => t.BrandID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Long(nullable: false, identity: true),
                        ProductName = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DateOfPurchase = c.DateTime(nullable: false),
                        AvailabilityStatus = c.String(nullable: false),
                        CategoryID = c.Long(nullable: false),
                        BrandID = c.Long(nullable: false),
                        Active = c.Boolean(),
                        Brand_BrandID = c.Int(),
                        Category_CategoryID = c.Int(),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Brands", t => t.Brand_BrandID)
                .ForeignKey("dbo.Categories", t => t.Category_CategoryID)
                .Index(t => t.Brand_BrandID)
                .Index(t => t.Category_CategoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Category_CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Products", "Brand_BrandID", "dbo.Brands");
            DropIndex("dbo.Products", new[] { "Category_CategoryID" });
            DropIndex("dbo.Products", new[] { "Brand_BrandID" });
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
            DropTable("dbo.Brands");
        }
    }
}
