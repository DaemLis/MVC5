namespace Vidly_Mvc5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixStepTwoDeleteMembershipTypes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes");
            DropForeignKey("dbo.Customers", "MembershipTypes_Id", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipTypeId" });
            DropIndex("dbo.Customers", new[] { "MembershipTypes_Id" });
            DropColumn("dbo.Customers", "MembershipTypeId");
            DropColumn("dbo.Customers", "MembershipTypes_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "MembershipTypes_Id", c => c.Byte());
            AddColumn("dbo.Customers", "MembershipTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Customers", "MembershipTypes_Id");
            CreateIndex("dbo.Customers", "MembershipTypeId");
            AddForeignKey("dbo.Customers", "MembershipTypes_Id", "dbo.MembershipTypes", "Id");
            AddForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes", "Id", cascadeDelete: true);
        }
    }
}
