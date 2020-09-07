namespace MovieCustomerMvcApplicationWithAuthentication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateinMovieclass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "Stock", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Stock");
            DropColumn("dbo.Movies", "ReleaseDate");
        }
    }
}
