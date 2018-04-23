namespace movie_rental_app.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateMembershipTypeNames : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET MembershipName ='Free' WHERE MonthlyDuration = 0");
            Sql("UPDATE MembershipTypes SET MembershipName ='Pay as Go' WHERE MonthlyDuration = 1");
            Sql("UPDATE MembershipTypes SET MembershipName ='6-Month Payment' WHERE MonthlyDuration = 6");
            Sql("UPDATE MembershipTypes SET MembershipName ='Year Payment' WHERE MonthlyDuration = 12");
        }
        
        public override void Down()
        {
        }
    }
}
