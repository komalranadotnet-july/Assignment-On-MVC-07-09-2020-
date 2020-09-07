namespace MovieCustomerMvcApplicationWithAuthentication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'5abc6ff4-94b0-461d-afcb-d251688b8c6b', N'guestuser@gmail.com', 0, N'AMGldR68AcvLuKEa3/RHOilqa4Nt6AAUq2udhrpWKRgxwjJB3CCNDxKY4wgE6JcHAw==', N'0e9a05a9-d3da-40b2-ba98-fca2aa906554', NULL, 0, 0, NULL, 1, 0, N'guestuser@gmail.com')


INSERT INTO[dbo].[AspNetUsers]([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'e7c9e8c0-c384-434d-bf82-51b8a4edf3fb', N'adminuser@gmail.com', 0, N'ANhqZo7dtsj0BEf9mOLt8bsRZPueu8Pj8gyNR0XivNnujC39g6ZS6BwRQAHoF0VGtA==', N'a12744e0-8fc4-4fd0-83e5-2fa4246440ab', NULL, 0, 0, NULL, 1, 0, N'adminuser@gmail.com')


                INSERT INTO[dbo].[AspNetRoles] ([Id], [Name]) VALUES(N'ace280da-2b29-49b5-a4e5-04224d7e509a', N'CanManageMovie')



                INSERT INTO[dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES(N'e7c9e8c0-c384-434d-bf82-51b8a4edf3fb', N'ace280da-2b29-49b5-a4e5-04224d7e509a')




");


        }
        
        public override void Down()
        {
        }
    }
}
