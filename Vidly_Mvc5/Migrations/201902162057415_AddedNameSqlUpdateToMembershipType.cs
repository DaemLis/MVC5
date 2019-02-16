namespace Vidly_Mvc5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNameSqlUpdateToMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Name = 'Monthly' WHERE Id IN (2,3,4)");
            Sql("UPDATE MembershipTypes SET Name = 'Pay as you go' WHERE Id = 1");
        }
        
        public override void Down()
        {
        }
    }
}
