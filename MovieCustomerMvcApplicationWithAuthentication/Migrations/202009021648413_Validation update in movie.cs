namespace MovieCustomerMvcApplicationWithAuthentication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Validationupdateinmovie : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false, maxLength: 40));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false));
        }
    }
}
