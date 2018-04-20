namespace movie_rental_app.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes(Id, SignUpFee, MonthlyDuration, Discount)" +
                "VALUES(1,0,0,0)");
            Sql("INSERT INTO MembershipTypes(Id, SignUpFee, MonthlyDuration, Discount)" +
                "VALUES(2,5,1,10)");
            Sql("INSERT INTO MembershipTypes(Id, SignUpFee, MonthlyDuration, Discount)" +
                "VALUES(3,25,6,15)");
            Sql("INSERT INTO MembershipTypes(Id, SignUpFee, MonthlyDuration, Discount)" +
                "VALUES(4,50,12,20)");
        }
        
        public override void Down()
        {
        }
    }
}
