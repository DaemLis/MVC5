namespace Vidly_Mvc5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixMembershipTypes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "MembershipTypes_Id", c => c.Byte());
            CreateIndex("dbo.Customers", "MembershipTypes_Id");
            AddForeignKey("dbo.Customers", "MembershipTypes_Id", "dbo.MembershipTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "MembershipTypes_Id", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipTypes_Id" });
            DropColumn("dbo.Customers", "MembershipTypes_Id");
        }
    }
}
