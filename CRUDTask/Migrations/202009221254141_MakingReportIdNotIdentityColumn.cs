namespace CRUDTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakingReportIdNotIdentityColumn : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ReportProducts", "Report_ID", "dbo.Reports");
            DropPrimaryKey("dbo.Reports");
            AlterColumn("dbo.Reports", "ID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Reports", "ID");
            AddForeignKey("dbo.ReportProducts", "Report_ID", "dbo.Reports", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReportProducts", "Report_ID", "dbo.Reports");
            DropPrimaryKey("dbo.Reports");
            AlterColumn("dbo.Reports", "ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Reports", "ID");
            AddForeignKey("dbo.ReportProducts", "Report_ID", "dbo.Reports", "ID", cascadeDelete: true);
        }
    }
}
