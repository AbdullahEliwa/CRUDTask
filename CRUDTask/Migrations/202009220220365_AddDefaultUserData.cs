namespace CRUDTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDefaultUserData : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'69ffbeab-26fc-4194-af4c-f4b4915468ac', N'Task@gmail.com', 0, N'AB/CPIodNbfuD4yPo9JMWuZYZz/9hgnMOfcvQBwb76IdVVKs4fC9lrm5O29vk2YsEQ==', N'57d07e76-a87a-4c91-8fc4-5b288d3610b6', NULL, 0, 0, NULL, 1, 0, N'Task@gmail.com');
            ");
        }
        
        public override void Down()
        {
        }
    }
}
