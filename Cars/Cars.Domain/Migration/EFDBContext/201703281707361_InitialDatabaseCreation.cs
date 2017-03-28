namespace Cars.Domain.Migration.EFDBContext
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "MarkID", "dbo.Marks");
            DropIndex("dbo.Cars", new[] { "MarkID" });
            DropTable("dbo.Marks");
            DropTable("dbo.Cars");
        }
    }
}
