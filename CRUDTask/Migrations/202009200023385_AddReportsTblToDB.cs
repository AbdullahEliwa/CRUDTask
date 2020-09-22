namespace CRUDTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReportsTblToDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reports",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Notes = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ReportProducts",
                c => new
                    {
                        Report_ID = c.Int(nullable: false),
                        Product_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Report_ID, t.Product_ID })
                .ForeignKey("dbo.Reports", t => t.Report_ID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_ID, cascadeDelete: true)
                .Index(t => t.Report_ID)
                .Index(t => t.Product_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReportProducts", "Product_ID", "dbo.Products");
            DropForeignKey("dbo.ReportProducts", "Report_ID", "dbo.Reports");
            DropIndex("dbo.ReportProducts", new[] { "Product_ID" });
            DropIndex("dbo.ReportProducts", new[] { "Report_ID" });
            DropTable("dbo.ReportProducts");
            DropTable("dbo.Reports");
        }
    }
}
