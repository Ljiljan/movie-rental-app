namespace movie_rental_app.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDobToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Dob", c => c.DateTime(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Dob");
        }
    }
}
