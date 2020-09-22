namespace CRUDTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSampleCategoryData : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                SET IDENTITY_INSERT [dbo].[Categories] ON
                INSERT INTO [dbo].[Categories] ([ID], [Name]) VALUES (10, N'laptop')
                INSERT INTO [dbo].[Categories] ([ID], [Name]) VALUES (11, N'Mobile')
                INSERT INTO [dbo].[Categories] ([ID], [Name]) VALUES (12, N'TV')
                SET IDENTITY_INSERT [dbo].[Categories] OFF

            ");
        }
        
        public override void Down()
        {
        }
    }
}
