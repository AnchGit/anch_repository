namespace Cars.Domain.Migrations.EFDBContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabaseCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        CarID = c.Int(nullable: false, identity: true),
                        MarkID = c.Int(nullable: false),
                        Model = c.String(nullable: false),
                        Color = c.String(nullable: false),
                        Engine = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IssueDate = c.DateTime(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsAvailable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CarID)
                .ForeignKey("dbo.Marks", t => t.MarkID, cascadeDelete: true)
                .Index(t => t.MarkID);
            
            CreateTable(
                "dbo.Marks",
                c => new
                    {
                        MarkID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.MarkID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false),
                        CarID = c.Int(nullable: false),
                        UserID = c.String(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Cars", t => t.OrderID)
                .Index(t => t.OrderID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "OrderID", "dbo.Cars");
            DropForeignKey("dbo.Cars", "MarkID", "dbo.Marks");
            DropIndex("dbo.Orders", new[] { "OrderID" });
            DropIndex("dbo.Cars", new[] { "MarkID" });
            DropTable("dbo.Orders");
            DropTable("dbo.Marks");
            DropTable("dbo.Cars");
        }
    }
}
