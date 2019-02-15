namespace Vidly_Mvc5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataInMembershipTypesTable1 : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT MembershipTypes ON");
            Sql("INSERT INTO MembershipTypes (Id, SignUpFee, DurationInMonths, DiscountRate) VALUES (5, 0, 0, 0)");
            Sql("INSERT INTO MembershipTypes (Id, SignUpFee, DurationInMonths, DiscountRate) VALUES (6, 30, 1, 10)");
            Sql("INSERT INTO MembershipTypes (Id, SignUpFee, DurationInMonths, DiscountRate) VALUES (7, 90, 3, 15)");
            Sql("INSERT INTO MembershipTypes (Id, SignUpFee, DurationInMonths, DiscountRate) VALUES (8, 300, 12, 20)");
            Sql("SET IDENTITY_INSERT MembershipTypes OFF");
        }
        
        public override void Down()
        {
        }
    }
}
