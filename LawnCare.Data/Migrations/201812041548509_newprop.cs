namespace LawnCare.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newprop : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Mower", "MowerName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Mower", "MowerName");
        }
    }
}
