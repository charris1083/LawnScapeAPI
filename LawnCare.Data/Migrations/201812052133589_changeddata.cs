namespace LawnCare.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeddata : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contract", "OwnerId", c => c.Guid(nullable: false));
            DropColumn("dbo.Contract", "ContractGuid");
            DropColumn("dbo.Contract", "MyProperty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contract", "MyProperty", c => c.Int(nullable: false));
            AddColumn("dbo.Contract", "ContractGuid", c => c.Guid(nullable: false));
            DropColumn("dbo.Contract", "OwnerId");
        }
    }
}
