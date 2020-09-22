namespace CRUDTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSampleProductData : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                    SET IDENTITY_INSERT [dbo].[Products] ON
                    INSERT INTO [dbo].[Products] ([ID], [Name], [Quantity], [UnitPrice], [CategoryID]) VALUES (10, N'Lenovo', 100, 100000, 10)
                    INSERT INTO [dbo].[Products] ([ID], [Name], [Quantity], [UnitPrice], [CategoryID]) VALUES (11, N'SamSung', 50, 5000, 11)
                    INSERT INTO [dbo].[Products] ([ID], [Name], [Quantity], [UnitPrice], [CategoryID]) VALUES (12, N'LG Tv', 20, 1000, 12)
                    SET IDENTITY_INSERT [dbo].[Products] OFF

               ");
        }
        
        public override void Down()
        {
        }
    }
}
