namespace CRUDTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakesNoteNotRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reports", "Notes", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reports", "Notes", c => c.String(nullable: false, maxLength: 500));
        }
    }
}
